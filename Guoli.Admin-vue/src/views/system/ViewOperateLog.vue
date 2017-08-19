



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-select v-model="conditions.TargetTable.value" placeholder="日志类别" clearable>
            <el-option v-for="item in TargetTableSelectData" :key="item.key" :label="item.key" :value="item.value"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-select v-model="conditions.OperateType.value" placeholder="操作类型" clearable>
            <el-option v-for="item in OperateTypeSelectData" :key="item.key" :label="item.key" :value="item.value"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.Name.value" placeholder="管理员姓名"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.Account.value" placeholder="登录账户"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.OperateTime.value" type="daterange" placeholder="操作时间" align="right">
          </el-date-picker>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="Name" label="操作人"></el-table-column>
      <el-table-column prop="Account" label="登录账户"></el-table-column>
      <el-table-column prop="LogContent" label="操作日志" min-width="250"></el-table-column>
      <el-table-column prop="OperateType" label="操作类型" :formatter="OperateTypeFormatter"></el-table-column>
      <el-table-column prop="TargetTable" label="日志分类" :formatter="TargetTableFormatter"></el-table-column>
      <el-table-column prop="DepartmentName" label="所属部门"></el-table-column>
      <el-table-column prop="OperateTime" label="操作时间" :formatter="OperateTimeFormatter"></el-table-column>

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

  </section>
</template>
<script>

import moment from 'moment';
import _ from 'underscore';
import server from '@/store/server';
import { timepickerOptions } from '@/utils';

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'ViewOperateLog',
      order: 'OperateTime',
      desc: true,
      conditions: {
        TargetTable: { value: undefined, type: 'equal' },
        OperateType: { value: undefined, type: 'equal' },
        Name: { value: undefined, type: 'like' },
        Account: { value: undefined, type: 'like' },
        OperateTime: { value: undefined, type: 'between' },
      },
      TargetTableSelectData: [{ key: '账户管理', value: 'SystemUser' }, { key: '文件管理-目录', value: 'TraficFileType' }, { key: '文件管理-文件', value: 'TraficFiles' }, { key: '题库管理', value: 'ExamFiles' }, { key: '考试通知', value: 'ExamNotify' }, { key: '题库分类', value: 'ExamType' }, { key: '部门管理', value: 'DepartInfo' }, { key: '人员管理', value: 'PersonInfo' }, { key: '职务管理', value: 'Posts' }, { key: '通知公告', value: 'Announcement' }],
      OperateTypeSelectData: [{ key: '新增', value: 1 }, { key: '修改', value: 2 }, { key: '删除', value: 3 }],

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,
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

    OperateTypeFormatter: function (row) {
      let type = { '1': '新增', '2': '修改', '3': '删除' };
      return type[row.OperateType];
    },
    TargetTableFormatter: function (row) {
      let temp = _.find(this.TargetTableSelectData, item => item.value === row.TargetTable);
      return temp.key;
    },
    OperateTimeFormatter: function (row) { return moment(row.OperateTime).format('YYYY-MM-DD HH:mm:ss'); },

    handlePageChange: function (page) {
      this.page = page;
      this.load();
    }
  },

  mounted() {

    this.load();
  }
};
</script>
<style scoped lang="scss">

</style>

