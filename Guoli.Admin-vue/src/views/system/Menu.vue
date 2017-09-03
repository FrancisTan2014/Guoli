<template>
  <section>

    <el-row>
      <el-col :span="24">
        <el-button type="primary" icon="plus" @click="showEditForm(0, null)">添加一级菜单</el-button>
      </el-col>
    </el-row>

    <el-row>
      <el-col :span="24">

        <el-collapse accordion v-if="menus.length > 0">

          <!-- 一级菜单 -->
          <el-collapse-item v-for="menu in menus" :key="menu.Id">
            <template slot="title">
              {{ menu.Name }}
              <el-button type="text" icon="delete" class="fr" @click="removeMenu(menu.Id, menu.Name)">删除</el-button>
              <el-button type="text" icon="edit" class="fr" @click="showEditForm(menu.ParentId, menu)">修改</el-button>
              <el-button type="text" icon="plus" class="fr" @click="showEditForm(menu.Id)">添加子菜单</el-button>
            </template>

            <el-collapse accordion v-if="menu.children">

              <!-- 二级菜单 -->
              <el-collapse-item v-for="sub in menu.children" :key="sub.Id">
                <template slot="title">
                  {{ sub.Name }}
                  <el-button type="text" icon="delete" class="fr" @click="removeMenu(sub.Id, sub.Name)">删除</el-button>
                  <el-button type="text" icon="edit" class="fr" @click="showEditForm(sub.ParentId, sub)">修改</el-button>
                  <el-button type="text" icon="plus" class="fr" @click="showEditForm(sub.Id)">添加子菜单</el-button>
                </template>

                <el-collapse accordion v-if="sub.children">

                  <!-- 三级级菜单 -->
                  <el-collapse-item v-for="grand in sub.children" :key="grand.Id">
                    <template slot="title">
                      {{ grand.Name }}
                      <el-button type="text" icon="delete" class="fr" @click.native.stop="removeMenu(grand.Id, grand.Name)">删除</el-button>
                      <el-button type="text" icon="edit" class="fr" @click.native.stop="showEditForm(grand.ParentId, grand)">修改</el-button>
                      <el-button type="text" icon="plus" class="fr" @click="showEditForm(grand.Id)">添加子菜单</el-button>
                    </template>
                  </el-collapse-item>
                  <!-- 三级菜单 -->

                </el-collapse>

              </el-collapse-item>
              <!-- 二级菜单 -->

            </el-collapse>

          </el-collapse-item>
          <!-- 一级菜单 -->

        </el-collapse>

      </el-col>
    </el-row>

    <!-- 弹窗 -->
    <el-dialog :title="editFormTitle" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item prop="Name" label="菜单名称：">
          <el-input v-model="editFormModel.Name"></el-input>
        </el-form-item>
        <el-form-item prop="Path" label="页面地址：">
          <el-input v-model="editFormModel.Path"></el-input>
        </el-form-item>

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="editFormVisible = false">取消</el-button>
        <el-button type="primary" @click.native="submit" :loading="editFormLoading">确定</el-button>
      </div>

    </el-dialog>

  </section>
</template>

<script>
import NProgress from 'nprogress';
import clone from 'clone';
import server from '@/store/server';
import _ from 'underscore';

export default {
  data() {
    return {
      menus: [],

      // 编辑菜单
      editFormTitle: '',
      editFormVisible: false,
      editFormLoading: false,
      emptyModel: { Name: '', Path: '', ParentId: 0 },
      editFormModel: {
        Name: '',
        Path: '',
        ParentId: 0
      },
      editFormRules: {
        Name: [
          { required: true, message: '请输入菜单名称', trigger: 'blur' },
          { max: 20, message: '菜单名称不能超过20个字', trigger: 'blur' }
        ],
        Path: [
          { required: true, message: '请输入页面页面', trigger: 'blur' }
        ]
      }
    };
  },

  methods: {
    load() {
      server.post('/System/GetMenuList', {}, this)
        .then(res => {
          this.menus = this.findChildren(res.data, 0);
          console.info(this.menus);
        });
    },

    findChildren(array, parentId) {
      let sub = _.filter(array, item => item.ParentId === parentId);
      if (sub.length === 0) {
        return [];
      }

      let result = [];
      sub.forEach(item => {
        // 递归遍历具有层级关系的部门列表
        // 并将其包装为符合el-cascader组件所需要的数据格式后返回
        let children = this.findChildren(array, item.Id);

        if (children.length > 0) {
          item.children = children;
        }
        result.push(item);
      });

      return result;
    },

    showEditForm(parent, model) {
      if (model) {
        this.editFormTitle = '修改菜单信息';
        this.editFormModel = clone(model);
      } else {
        this.editFormTitle = '添加菜单';
        this.editFormModel = clone(this.emptyModel);
        this.editFormModel.ParentId = parent;
        console.info(this.editFormModel);
      }

      this.editFormVisible = true;
    },

    submit() {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          NProgress.start();
          this.editFormLoading = true;

          let model = this.editFormModel;
          server.post('/System/EditMenu', { menu: model }, this)
            .then(res => {
              NProgress.done();
              this.editFormLoading = false;

              if (res.code === 108) {
                this.$success(model.Id > 0 ? '修改成功(:=' : '添加成功(:=');
                this.editFormVisible = false;
                this.load();
              } else {
                this.$error(model.Id > 0 ? '修改失败，请稍后重试(:=' : '添加失败，请稍后重试(:=');
              }
            });
        }
      })
    },

    removeMenu(id, name) {
      this.$confirm(`您确定要删除菜单'${name}'吗？`)
        .then(() => {
          NProgress.start();
          server.post('/System/DeleteMenu', { id: id }, this)
            .then(res => {
              NProgress.done();
              if (res.code === 100) {
                this.$success('删除成功(:=');
                this.load();
              } else if (res.code === 114) {
                this.$error('此菜单存在子菜单，无法删除(:=');
              } else {
                this.$error('删除失败，请稍后重试(:=');
              }
            });
        })
        .catch(() => { /* 取消 */ });
    }
  },

  mounted() {
    this.load();
  }
}
</script>

<style>
.fr {
  float: right;
  margin-right: 16px;
}
</style>
