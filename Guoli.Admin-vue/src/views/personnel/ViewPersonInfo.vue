



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.Name.value" placeholder="姓名"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.Spell.value" placeholder="拼音"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.WorkNo.value" placeholder="工号"></el-input>
        </el-form-item>
        <el-form-item>
          <el-select v-model="conditions.DepartmentId.value" placeholder="所属部门" clearable>
            <el-option v-for="item in departs" :key="item.DepartmentName" :label="item.DepartmentName" :value="item.Id"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-select v-model="conditions.PostId.value" placeholder="职务" clearable>
            <el-option v-for="item in posts" :key="item.PostName" :label="item.PostName" :value="item.Id"></el-option>
          </el-select>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="showAddForm" icon="plus">添加员工</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="Name" label="姓名"></el-table-column>
      <el-table-column prop="Sex" label="性别" :formatter="SexFormatter"></el-table-column>
      <el-table-column prop="Spell" label="拼音"></el-table-column>
      <el-table-column prop="WorkNo" label="工号"></el-table-column>
      <el-table-column prop="DepartmentName" label="所属部门"></el-table-column>
      <el-table-column prop="PostName" label="职务"></el-table-column>

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
    <el-dialog :title="editFormModel.Id > 0 ? '修改员工信息' : '添加员工'" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item prop="Name" label="姓名：">
          <el-input v-model="editFormModel.Name"></el-input>
        </el-form-item>

        <el-form-item prop="Sex" label="性别：">
          <el-radio-group v-model.number="editFormModel.Sex">
            <el-radio-button label="1">男</el-radio-button>
            <el-radio-button label="2">女</el-radio-button>
          </el-radio-group>
        </el-form-item>

        <el-form-item prop="WorkNo" label="工号：">
          <el-input v-model="editFormModel.WorkNo"></el-input>
        </el-form-item>

        <el-form-item prop="DepartmentId" label="所属部门：">
          <el-cascader :options="cascaderOptions" v-model="editFormModel.DepartmentId" clearable expand-trigger="hover" placeholder="请选择部门" :show-all-levels="false"></el-cascader>
        </el-form-item>

        <el-form-item prop="PostId" label="职务：">
          <el-select v-model="editFormModel.PostId" placeholder="请选择职务" clearable>
            <el-option v-for="item in posts" :key="item.PostName" :label="item.PostName" :value="item.Id"></el-option>
          </el-select>
        </el-form-item>

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="editFormVisible = false" :loading="editFormLoading">取消</el-button>
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

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'ViewPersonInfo',
      order: 'Id',
      desc: true,
      conditions: {
        Name: { value: undefined, type: 'like' },
        Spell: { value: undefined, type: 'like' },
        WorkNo: { value: undefined, type: 'like' },
        DepartmentId: { value: undefined, type: 'equal' },
        PostId: { value: undefined, type: 'equal' },
      },
      departs: [],
      posts: [],

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 编辑表单
      editFormVisible: false,
      editFormLoading: false,
      editFormModelOrigin: {
        Name: '',
        Sex: 1,
        WorkNo: '',
        DepartmentId: undefined,
        PostId: undefined
      },
      editFormModel: {
        Name: '',
        Sex: 1,
        WorkNo: '',
        DepartmentId: undefined,
        PostId: undefined
      },
      editFormRules: {
        Name: [
          { required: true, message: '请输入姓名', trigger: 'blur' },
          { max: 20, message: '姓名不能超过20个字', trigger: 'blur' },
        ],
        WorkNo: [
          { required: true, message: '请输入工号', trigger: 'blur' },
          { max: 20, message: '工号不能超过20个字母或数字', trigger: 'blur' },
        ],
        DepartmentId: [{ required: true, type: 'array', message: '请选择部门', trigger: 'change' }],
        PostId: [{ required: true, type: 'number', message: '请选择职务', trigger: 'change' }]
      },
      cascaderOptions: [],
      currentEditModel: {},
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

    SexFormatter: function (row) { return row.Sex === 1 ? '男' : '女'; },

    handlePageChange: function (page) {
      this.page = page;
      this.load();
    },

    showAddForm: function () {
      this.editFormVisible = true;
      this.editFormModel = clone(this.editFormModelOrigin);
    },

    showEditForm: function (model) {
      this.currentEditModel = model;
      this.editFormModel = clone(model);

      let selected = [];
      this.findParents(this.departs, model.DepartmentId, selected);
      this.editFormModel.DepartmentId = selected;

      this.editFormVisible = true;
    },

    findChildren: function (array, parentId) {
      let sub = _.filter(array, item => item.ParentId === parentId);
      if (sub.length === 0) {
        return [];
      }

      let result = [];
      sub.forEach(item => {
        // 递归遍历具有层级关系的部门列表
        // 并将其包装为符合el-cascader组件所需要的数据格式后返回
        let children = this.findChildren(array, item.Id);

        let obj = { label: item.DepartmentName, value: item.Id };
        if (children.length > 0) {
          obj.children = children;
        }
        result.push(obj);
      });

      return result;
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

    syncUpdate: function (model) {
      let m = this.currentEditModel;
      m.Name = model.Name;
      m.Sex = model.Sex;
      m.WorkNo = model.WorkNo;

      m.PostId = model.PostId;
      m.PostName = _.find(this.posts, item => item.Id === model.PostId).PostName;

      m.DepartmentId = model.DepartmentId;
      m.DepartmentName = _.find(this.departs, item => item.Id === model.DepartmentId).DepartmentName;
    },

    submit: function () {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          this.editFormLoading = true;
          NProgress.start();

          let model = clone(this.editFormModel);
          model.DepartmentId = _.last(model.DepartmentId);

          server.post('/People/PersonEdit', { person: model }, this)
            .then(res => {
              this.editFormLoading = false;
              NProgress.done();

              let successMsg = model.Id > 0 ? '修改员工信息成功(:=' : '添加员工信息成功(:=';
              let failureMsg = model.Id > 0 ? '修改员工信息失败，请稍后重试(:=' : '添加员工信息失败，请稍后重试(:=';
              if (res.code === 100) {
                if (model.Id > 0) {
                  // 若是修改员工信息
                  // 则成功之后将更新之后的信息直接同步到表格中
                  this.syncUpdate(model);
                } else {
                  // 若是添加员工信息
                  // 则成功之后重新加载表格
                  this.load();
                }

                this.editFormVisible = false;
                this.$message({ type: 'success', message: successMsg });
              } else if (res.code === 118) {
                this.$message({ type: 'error', message: '存在相同工号的员工，操作失败(:=' });
              } else {
                this.$message({ type: 'error', message: failureMsg });
              }
            });
        }
      });
    }
  },

  mounted() {
    server.post('/Common/GetDeparts', {}, this).then(res => {
      let { code, data } = res;
      this.departs = data;
      this.cascaderOptions = this.findChildren(data, 0);
    });
    server.post('/Common/GetPositions', {}, this).then(res => {
      let { code, data } = res; this.posts = data;
    });

    this.load();
  }
};
</script>
<style scoped lang="scss">

</style>

