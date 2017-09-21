



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.Name.value" placeholder="姓名"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.Account.value" placeholder="登录账户"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.CreateTime.value" type="daterange" placeholder="创建时间" align="right">
          </el-date-picker>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="showEditForm(null)" icon="plus">添加账户</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="Account" label="登录账户"></el-table-column>
      <el-table-column prop="Name" label="姓名"></el-table-column>
      <el-table-column prop="DepartmentName" label="所属部门"></el-table-column>
      <el-table-column prop="CreatorId" label="创建者" :formatter="CreatorIdFormatter"></el-table-column>
      <el-table-column prop="CreateTime" label="创建时间" :formatter="CreateTimeFormatter" sortable></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text" @click="showEditForm(scope.row)">修改</el-button>
          <el-button type="text" @click="handleDelete(scope.row)">删除</el-button>
        </template>
      </el-table-column>

    </el-table>

    <!--分页工具条-->
    <el-col :span="24" class="toolbar">
      共
      <span>{{ total }}</span> 条， 每页显示
      <el-select v-model="size" size="small" style="width: 70px;" @change="load">
        <el-option v-for="item in sizes" :value="item" :label="item" :key="item"></el-option>
      </el-select>
      条
      <el-pagination layout="prev, pager, next" @current-change="handlePageChange" :page-size="size" :total="total" style="float:right;">
      </el-pagination>
    </el-col>

    <!-- 弹窗 -->
    <el-dialog title="添加账户" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <el-alert title="关于登录密码" type="info" description="当您填写好登录账户后，登录密码默认与登录账户一致，我们建议您将登录账户设置为员工的工号" show-icon class="password-tips">
      </el-alert>

      <!-- 账户编辑表单 -->
      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item>
          <el-autocomplete v-model="searchSelected" :props="{ label: 'label', value: 'label' }" :fetch-suggestions="querySearchAsync" placeholder="输入工号|姓名从人名库搜索" @select="handleSelect" icon="search"></el-autocomplete>
        </el-form-item>

        <el-form-item prop="Name" label="姓名：">
          <el-input v-model="editFormModel.Name"></el-input>
        </el-form-item>

        <el-form-item prop="Account" label="登录账户：" @keyup.native="accountChange">
          <el-input v-model="editFormModel.Account" placeholder="建议用工号登录"></el-input>
        </el-form-item>

        <el-form-item prop="Password" label="登录密码：">
          <el-input v-model="editFormModel.Password" type="password"></el-input>
        </el-form-item>

        <el-form-item prop="DepartmentId" label="所属部门：">
          <el-cascader :options="cascaderOptions" v-model="editFormModel.DepartmentId" clearable expand-trigger="hover" :show-all-levels="false" @change="handleDepartChange"></el-cascader>
          <el-button type="text">添加部门</el-button>
        </el-form-item>

        <!-- 权限设置 -->
        <el-form-item label="权限设置：">
          <el-collapse accordion v-if="menus.length > 0">

            <!-- 一级菜单 -->
            <el-collapse-item v-for="menu in menus" :key="menu.Id">
              <template slot="title">
                <el-checkbox @change="selectChanged(menu.Id)" :checked="menu.checked">{{menu.Name}}</el-checkbox>
              </template>

              <el-collapse accordion v-if="menu.children">

                <!-- 二级菜单 -->
                <el-collapse-item v-for="sub in menu.children" :key="sub.Id">
                  <template slot="title">
                    <el-checkbox @change="selectChanged(sub.Id)" :checked="sub.checked">{{sub.Name}}</el-checkbox>
                  </template>

                  <el-collapse accordion v-if="sub.children">

                    <!-- 三级级菜单 -->
                    <el-collapse-item v-for="grand in menu.children" :key="grand.Id">
                      <template slot="title">
                        <el-checkbox @change="selectChanged(grand.Id)" :checked="grand.checked">{{grand.Name}}</el-checkbox>
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
        </el-form-item>
        <!-- 权限设置 -->

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="editFormVisible = false">取消</el-button>
        <el-button type="primary" @click.native="submit" :loading="editFormLoading">确定</el-button>
      </div>

    </el-dialog>

  </section>
</template>
<script>

import moment from 'moment';
import _ from 'underscore';
import clone from 'clone';
import NProgress from 'nprogress';
import server from '@/store/server';
import local from '@/store/local';
import { timepickerOptions } from '@/utils';
import Vue from 'vue';

export default {
  data() {
    return {
      isLoading: false,
      data: [],
      departs: [],
      menus: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'SystemUser',
      order: 'CreateTime',
      desc: true,
      conditions: {
        Name: { value: undefined, type: 'like' },
        Account: { value: undefined, type: 'like' },
        CreateTime: { value: undefined, type: 'between' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 账户编辑表单
      editFormVisible: false,
      editFormLoading: false,
      editFormModel: {
        Id: 0,
        Name: '',
        Account: '',
        Password: '',
        DepartmentId: [],
        DepartmentName: ''
      },
      emptyFormModel: {
        Id: 0,
        Name: '',
        Account: '',
        Password: '',
        DepartmentId: [],
        DepartmentName: ''
      },
      editFormRules: {
        Name: [
          { required: true, message: '请输入姓名', trigger: 'blur' },
          { max: 20, message: '姓名不能超过20个字', trigger: 'blur' }
        ],
        Account: [
          { required: true, message: '请输入登录账户', trigger: 'blur' },
          { max: 20, message: '登录账户不能超过20个字符', trigger: 'blur' }
        ],
        Password: [
          { required: true, message: '请输入登录密码', trigger: 'blur' },
          { min: 6, max: 20, message: '登录密码必须在6~20个字符之间', trigger: 'blur' }
        ],
        DepartmentId: [{ required: true, type: 'array', message: '请选择此账户所属部门', trigger: 'change' }]
      },
      cascaderOptions: [],
      searchSelected: '',

      // 权限设置
      permission: []
    };
  },

  methods: {
    load: function() {
      let o = {
        page: this.page,
        size: this.size,
        order: this.order,
        desc: this.desc,
        table: this.table,
        conditions: this.conditions
      };
      server.post(this.apiUrl, { json: JSON.stringify(o) }).then(res => {
        let { data } = res;
        if (data) {
          let { total, list } = data;
          this.total = total;
          this.data = list;
        }
      });
    },

    loadDeparts: function() {
      let findChildren = (array, parentId) => {
        let sub = _.filter(array, item => item.ParentId === parentId);
        if (sub.length === 0) {
          return [];
        }

        let result = [];
        sub.forEach(item => {
          // 递归遍历具有层级关系的部门列表
          // 并将其包装为符合el-cascader组件所需要的数据格式后返回
          let children = findChildren(array, item.Id);

          let obj = { label: item.DepartmentName, value: item.Id };
          if (children.length > 0) {
            obj.children = children;
          }
          result.push(obj);
        });

        return result;
      };

      server.post('/Common/GetDeparts', {}, this)
        .then(res => {
          let { data } = res;
          if (_.isArray(data)) {
            this.departs = data;
            this.cascaderOptions = findChildren(data, 0);
          }
        });
    },

    CreatorIdFormatter: function(row) { return '超级管理员'; }, CreateTimeFormatter: function(row) { return moment(row.CreateTime).format('YYYY-MM-DD HH:mm:ss'); },

    handlePageChange: function(page) {
      this.page = page;
      this.load();
    },

    accountChange: function(value) {
      this.editFormModel.Password = this.editFormModel.Account;
    },

    // 级联选择器选项改变时
    // 将部门名称赋值给DepartmentName字段
    handleDepartChange: function(selected) {
      let departId = _.last(selected);
      let depart = _.find(this.departs, item => item.Id === departId);
      this.editFormModel.DepartmentName = depart.DepartmentName;
    },

    // 根据用户输入的工号
    // 从服务器匹配人员信息列表
    // 为智能提示控件提供数据源
    querySearchAsync: function(query, callback) {
      if (!query) {
        callback([]);
      }

      server.post('/Common/GetList', { TableName: 'ViewPersonInfo', Conditions: `WorkNo LIKE '${query}%' OR [Name] LIKE '${query}%'` }, this).then(res => {
        let { data } = res, queryResults = [];
        if (_.isArray(data)) {
          data.forEach(item => item.label = `${item.Name} | ${item.WorkNo} | ${item.DepartmentName}`);
          queryResults = data;
        }

        callback(queryResults);
      });
    },

    findParents: function(array, id, result) {
      let obj = _.find(array, elem => elem.Id === id);
      result.splice(0, 0, id);

      if (obj.ParentId === 0) {
        result.splice(0, 0, obj.ParentId);
        return;
      }

      this.findParents(array, obj.ParentId, result);
    },

    // 当用户从智能提示下拉框中选择一个人员信息时
    // 将此人员相关信息自动填充到表单相应控件中
    handleSelect: function(item) {
      let m = this.editFormModel;
      m.Name = item.Name;
      m.Account = item.WorkNo;
      m.Password = item.WorkNo;
      m.DepartmentName = item.DepartmentName;

      // 根据选择的人员的部门Id
      // 从部门列表中递归遍历其父级Id
      // 最终组成一个数组
      // 填充到部门级联选择控件中
      let selectedDepartmentIds = [];
      this.findParents(this.departs, item.DepartmentId, selectedDepartmentIds);
      m.DepartmentId = selectedDepartmentIds;

      this.$refs.editForm.validate();
    },

    showEditForm: function(model) {
      this.editFormModel = clone(model || this.emptyFormModel);

      // 递归
      let self = this;
      let recursion = function(arr) {
        arr.forEach((item, index) => {
          let exists = _.contains(self.permission, item.Id);
          if (exists) {
            item.checked = true;
          } else {
            item.checked = false;
          }

          if (item.children) {
            recursion(item.children);
          }
        });
      };

      if (model) {
        let selected = [];
        this.findParents(this.departs, model.DepartmentId, selected);
        this.editFormModel.DepartmentId = selected;
        this.editFormModel.Password = model.Account;

        // this.loadPermissions(model.Id).then(() => {
        //   // 设置当前表单中
        //   // 的checkebox的选中状态
        //   recursion(this.menus);
        //   this.editFormVisible = true;
        // });

        Promise.all([this.loadMenus(), this.loadPermissions(model.Id)]).then(res => {
          // 设置当前表单中
          // 的checkebox的选中状态
          recursion(res[0]);
          this.menus = res[0];
          this.editFormVisible = true;
        });
      } else {
        this.loadMenus().then(res => {
          this.permission = [];
          recursion(res);
          this.menus = res;
          this.editFormVisible = true;
        });
      }

    },

    handleDelete: function(model) {

    },

    loadMenus() {
      return server.post('/System/GetMenuList', {}, this)
        .then((res, resolve) => {
          let menus = this.findChildren(res.data, 0, item => {
            item.checked = false;
          });

          return menus;
        });
    },

    findChildren(array, parentId, callback) {
      let sub = _.filter(array, item => item.ParentId === parentId);
      if (sub.length === 0) {
        return [];
      }

      let result = [];
      sub.forEach(item => {
        // 递归遍历具有层级关系的部门列表
        // 并将其包装为符合el-cascader组件所需要的数据格式后返回
        let children = this.findChildren(array, item.Id, callback);

        if (children.length > 0) {
          item.children = children;
        }

        if (callback && typeof (callback) === 'function') {
          callback(item);
        }

        result.push(item);
      });

      return result;
    },

    selectChanged(id) {
      let arr = this.permission;
      let index = _.indexOf(arr, id);
      if (index === -1) {
        arr.push(id);
      } else {
        arr.splice(index, 1);
      }
    },

    loadPermissions(userId) {
      return server.post('/System/GetPermissions', { userId: userId }, this)
        .then(res => {
          let list = [];
          res.data.forEach((value, index) => {
            list.push(value.MenuId);
          });

          this.permission = list;
        });
    },

    // 提交账户添加/修改到服务器
    submit: function() {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          let model = clone(this.editFormModel);

          // 将级联选择器结果的最后一项作为账户的部门Id
          model.DepartmentId = _.last(model.DepartmentId);

          this.editFormLoading = true;
          NProgress.start();
          server.post('/System/AddOrUpdate', { user: model, menus: this.permission }, this)
            .then(res => {
              this.editFormLoading = false;
              NProgress.done();

              let successMsg = model.Id > 0 ? '账户修改成功(:=' : '账户添加成功(:=';
              let errorMsg = model.Id > 0 ? '修改失败，请稍后重试(:=' : '添加失败，请稍后重试(:=';
              if (res.code === 100) {
                this.load();
                this.editFormVisible = false;
                this.$message({ type: 'success', message: successMsg });
              } else if (res.code === 118) {
                this.$message({ type: 'error', message: '添加失败，账户已存在(:=' });
              } else {
                this.$message({ type: 'error', message: errorMsg });
              }
            });
        }
      });
    }
  },

  mounted() {
    this.loadDeparts();
    this.load();
    this.loadMenus();
  }
};
</script>
<style scoped lang="scss">
.password-tips {
  margin-bottom: 30px;
}
</style>

