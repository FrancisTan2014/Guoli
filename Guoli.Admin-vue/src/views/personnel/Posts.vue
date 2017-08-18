



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.PostName.value" placeholder="职务名称"></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="showAddForm" icon="plus">添加职务</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="Id" label="Id"></el-table-column>
      <el-table-column prop="PostName" label="职务名称"></el-table-column>

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
    <el-dialog :title="editFormModel.Id > 0 ? '修改职务名称' : '添加职务'" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" @submit.prevent="submit" label-width="120px">
        <el-form-item prop="PostName" label="职务名称">
          <el-input v-model="editFormModel.PostName"></el-input>
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
      table: 'Posts',
      order: 'Id',
      desc: true,
      conditions: {
        PostName: { value: undefined, type: 'like' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 编辑表单
      editFormVisible: false,
      editFormLoading: false,
      editFormModel: {
        PostName: ''
      },
      editFormRules: {
        PostName: [
          { required: true, message: '请输入职务名称', trigger: 'blur' },
          { max: 20, message: '职务名称不能超过20个字', trigger: 'blur' }
        ]
      }
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

    handlePageChange: function (page) {
      this.page = page;
    },

    showAddForm: function () {
      this.editFormVisible = true;
      this.$refs.editForm.resetFields();
    },

    showEditForm: function (model) {
      this.editFormModel = clone(model);
      this.editFormVisible = true;
    },

    submit: function () {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          let model = clone(this.editFormModel);

          this.editFormLoading = true;
          NProgress.start();
          server.post('/People/AddOrUpdatePost', { model: model }, this)
            .then(res => {
              this.editFormLoading = false;
              NProgress.done();

              let successMsg = model.Id > 0 ? '职务名称修改成功(:=' : '职务添加成功(:=';
              let failureMsg = model.Id > 0 ? '职务名称修改失败，请稍后重试(:=' : '职务添加失败，请稍后重试(:=';
              if (res.code === 100) {
                this.load();
                this.editFormVisible = false;
                this.$message({ type: 'success', message: successMsg });
              } else if (res.code === 108) {
                this.$message({ type: 'error', message: '职务名称已存在(:=' });
              } else {
                this.$message({ type: 'error', message: failureMsg });
              }
            });
        }
      });
    }
  },

  mounted() {

    this.load();
  }
};
</script>
<style scoped lang="scss">

</style>

