



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.Name.value" placeholder="指导司机"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.KeyPersonName.value" placeholder="关键人"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.ConfirmDate.value" type="daterange" placeholder="确定日期" align="right">
          </el-date-picker>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.ActualRemoveTime.value" type="daterange" placeholder="实际解除日期" align="right">
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

      <el-table-column prop="Name" label="包保人"></el-table-column>
      <el-table-column prop="DepartmentName" label="所属单位"></el-table-column>
      <el-table-column prop="KeyPersonName" label="关键人"></el-table-column>
      <el-table-column prop="PostName" label="关键人职务"></el-table-column>
      <el-table-column prop="ConfirmDate" label="确定日期" :formatter="ConfirmDateFormatter"></el-table-column>
      <el-table-column prop="ExpectRemoveTime" label="预计解除日期" :formatter="ExpectRemoveTimeFormatter"></el-table-column>
      <el-table-column prop="ActualRemoveTime" label="实际解除日期" :formatter="ActualRemoveTimeFormatter"></el-table-column>
      <el-table-column label="操作" min-width="150">
        <template scope="scope">
          <el-button size="small" type="text" @click="detailPreview(scope.$index, scope.row)">查看详情</el-button>
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

  </section>
</template>
<script>

import moment from 'moment';

import server from '@/store/server';
import { timepickerOptions } from '@/utils';

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'ViewInstructorKeyPerson',
      order: 'ConfirmDate',
      desc: true,
      conditions: {
        Name: { value: undefined, type: 'like' },
        KeyPersonName: { value: undefined, type: 'like' },
        ConfirmDate: { value: undefined, type: 'between' },
        ActualRemoveTime: { value: undefined, type: 'between' },
      },

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

    ConfirmDateFormatter: function (row) { return moment(row.ConfirmDate).format('YYYY-MM-DD'); }, ExpectRemoveTimeFormatter: function (row) { return moment(row.ExpectRemoveTime).format('YYYY-MM-DD'); }, ActualRemoveTimeFormatter: function (row) {
      let d = moment(row.ActualRemoveTime);
      if (d.year() === 1900) {
        return '';
      }

      return d.format('YYYY-MM-DD');
    },

    handlePageChange: function (page) {
      this.page = page;
      this.load();
    },

    detailPreview: function (index, row) {
      this.$router.push({ path: '/keyperson-prev?id=' + row.Id, params: { data: row } });
    },
  },

  mounted() {

    this.load();
  }
};
</script>
<style scoped lang="scss">

</style>

