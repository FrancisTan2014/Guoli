



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.ParentName.value" placeholder="部门名称"></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="editFormVisible = true" icon="plus">新增部门</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="DepartmentName" label="部门名称"></el-table-column>
      <el-table-column prop="ParentName" label="上级部门"></el-table-column>
      <el-table-column prop="AddTime" label="添加时间" :formatter="AddTimeFormatter"></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text" @click="showEditForm(scope.row)">修改</el-button>
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
    <el-dialog :title="editFormModel.Id > 0 ? '修改部门名称' : '添加部门'" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <el-alert title="关于选择上级部门的操作问题" type="info" description="当您看到输入框已经出现文字，表明您已经选择成功了。如：鼠标滑过集宁机务段，则集宁机务段已经选择成功了，这时您如果不想再选择集宁机务段下面的车间，则只需要鼠标点击空白区域，即可进行其他操作。" show-icon style="margin-bottom: 30px;"></el-alert>

      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item prop="ParentId" label="上级部门：">
          <el-cascader :options="cascaderOptions" v-model="editFormModel.ParentId" clearable expand-trigger="hover" change-on-select placeholder="可选择任意一级或者不选"></el-cascader>
        </el-form-item>

        <el-form-item prop="DepartmentName" label="部门名称：">
          <el-input v-model="editFormModel.DepartmentName"></el-input>
        </el-form-item>

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="editFormVisible = false">取消</el-button>
        <el-button type="primary" @click="submit" :loading="editFormLoading">确定</el-button>
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
import { timepickerOptions } from '@/utils';

export default {
  data() {
    return {
      isLoading: false,
      data: [],
      departs: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'ViewDepartInfo',
      order: 'Id',
      desc: true,
      conditions: {
        ParentName: { value: undefined, type: 'like' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 编辑部门表单
      editFormVisible: false,
      editFormLoading: false,
      editFormModel: {
        DepartmentName: '',
        ParentId: undefined
      },
      editFormRules: {
        DepartmentName: [
          { required: true, message: '请输入部门名称', trigger: 'blur' },
          { max: 20, message: '部门名称不能超过20个字', trigger: 'blur' }
        ]
      },
      cascaderOptions: []
    };
  },

  methods: {
    load: function () {
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

    loadDeparts: function () {
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

    AddTimeFormatter: function (row) { return moment(row.AddTime).format('YYYY-MM-DD HH:mm:ss'); },

    handlePageChange: function (page) {
      this.page = page;
      this.load();
    },

    findParents: function (array, id, result) {
      let obj = _.find(array, elem => elem.Id === id);
      result.splice(0, 0, id);

      if (obj.ParentId === 0) {
        result.splice(0, 0, obj.ParentId);
        return;
      }

      this.findParents(array, obj.ParentId, result);
    },

    showEditForm: function (model) {
      this.editFormModel = clone(model);

      let selected = [];
      this.findParents(this.departs, model.ParentId, selected);
      this.editFormModel.ParentId = selected;

      this.editFormVisible = true;
    },

    submit: function () {
      this.$refs.editForm.validate(valid => {
        let model = clone(this.editFormModel);
        // 将上级部门Id从级联选择器选择结果中提取出来
        model.ParentId = _.isArray(model.ParentId) ? _.last(model.ParentId) : 0;

        this.editFormLoading = true;
        NProgress.start();
        server.post('/People/AddOrUpdateDepart', { depart: model }, this)
          .then(res => {
            this.editFormLoading = false;
            NProgress.done();

            let { code } = res;
            let successMsg = model.Id > 0 ? '修改成功(:=' : '添加成功(:=';
            let failureMsg = model.Id > 0 ? '修改失败，请稍后重试(:=' : '添加失败，请稍后重试(:=';
            if (code === 100) {
              this.load();
              this.editFormVisible = false;
              this.$message({ type: 'success', message: successMsg });
            } else if (code === 108) {
              this.$message({ type: 'error', message: '部门名称已存在(:=' });
            } else {
              this.$message({ type: 'error', message: failureMsg });
            }
          });
      });
    }
  },

  mounted() {
    this.load();
    this.loadDeparts();
  }
};
</script>
<style scoped lang="scss">

</style>

