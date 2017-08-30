



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.Location.value" placeholder="所在地点"></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="showEditForm(emptyModel)" icon="plus">添加路由器</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="BssId" label="MAC地址"></el-table-column>
      <el-table-column prop="Location" label="所在地点"></el-table-column>
      <el-table-column prop="Ip" label="IP地址"></el-table-column>
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
    <el-dialog :title="editFormTitle" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item prop="BssId" label="Mac地址：">
          <el-input v-model="editFormModel.BssId" placeholder="xx-xx-xx-xx-xx-xx"></el-input>
        </el-form-item>
        <el-form-item prop="Ip" label="Ip地址：">
          <el-input v-model="editFormModel.Ip" placeholder="xxx.xxx.xxx.xxx"></el-input>
        </el-form-item>
        <el-form-item prop="Location" label="所在地点：">
          <el-input v-model="editFormModel.Location"></el-input>
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

import moment from 'moment';
import NProgress from 'nprogress';
import server from '@/store/server';
import { buildValidator } from '@/utils';
import clone from 'clone';

let macValidator = buildValidator(/([A-Za-z0-9]{2}-){5}[A-Za-z0-9]{2}/, '请输入Mac地址', '请输入格式为 xx-xx-xx-xx-xx-xx 的Mac地址');
let ipValidator = buildValidator(/(\d{1,3}\.){3}\d{1,3}/, '请输入Ip地址', '请输入格式正确的Ip地址');

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'InstructorRouterPosition',
      order: 'Id',
      desc: false,
      conditions: {
        Location: { value: undefined, type: 'like' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 表单
      editFormVisible: false,
      editFormLoading: false,
      editFormTitle: '添加路由器',
      emptyModel: { BssId: '', Ip: '', Location: '' },
      originModel: {},
      editFormModel: {
        BssId: '',
        Ip: '',
        Location: ''
      },
      editFormRules: {
        BssId: { validator: macValidator, trigger: 'blur' },
        Ip: { validator: ipValidator, trigger: 'blur' },
        Location: [
          { required: true, message: '请输入路由器所在地名称', trigger: 'blur' },
          { max: 20, message: '请输入少于20位的路由器所在地名称', trigger: 'blur' }
        ]
      }
    };
  },

  methods: {
    load() {
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

    AddTimeFormatter(row) { return moment(row.AddTime).format('YYYY-MM-DD HH:mm:ss'); },

    handlePageChange(page) {
      this.page = page;
      this.load();
    },

    showEditForm(model) {
      this.editFormTitle = model.Id > 0 ? '修改路由器信息' : '添加路由器';
      this.editFormModel = clone(model);
      this.editFormVisible = true;
    },

    submit() {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          NProgress.start();
          this.editFormLoading = true;

          let m = this.editFormModel;
          server.post('/System/AddOrUpdateRouter', { model: m }, this)
            .then(res => {
              NProgress.done()
              this.editFormLoading = false;

              let successMsg = m.Id > 0 ? '路由器信息修改成功(:=' : '路由器添加成功';
              let failedMsg = m.Id > 0 ? '信息修改失败，请稍后重试(:=' : '路由器添加失败，请稍后重试(:=';
              if (res.code === 100) {
                this.load();
                this.editFormVisible = false;
                this.$success(successMsg);
              } else {
                this.$error(failedMsg);
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

