



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.Name.value" placeholder="指导司机"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.WriteDate.value" type="daterange" placeholder="登记日期" align="right">
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

      <el-table-column prop="Name" label="指导司机"></el-table-column>
      <el-table-column prop="DepartmentName" label="所属单位"></el-table-column>
      <el-table-column prop="WorkSummary" label="工作总结"></el-table-column>
      <el-table-column prop="WorkPlans" label="工作计划"></el-table-column>
      <el-table-column prop="WriteDate" label="登记日期" :formatter="WriteDateFormatter"></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text" @click="showDetail(scope.row)">查看详情</el-button>
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
    <el-dialog :title="`授课培训记录`" :visible="dialogVisible" :before-close="() => dialogVisible = false">
      <el-form label-width="120px">
        <el-form-item label="指导司机：">
          <span>{{ model.Name }}</span>
        </el-form-item>
        <el-form-item label="填写日期：">
          <span>{{ model.WriteDate | moment('YYYY-MM-DD') }}</span>
        </el-form-item>
        <el-form-item label="本月工作完成情况：">
          <span>{{ model.WorkSummary }}</span>
        </el-form-item>
        <el-form-item label="存在问题分析：">
          <span>{{ model.Problems }}</span>
        </el-form-item>
        <el-form-item label="下月工作计划：">
          <span>{{ model.WorkPlans }}</span>
        </el-form-item>
      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false" type="primary">关闭</el-button>
      </div>
    </el-dialog>
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
      table: 'ViewInstructorPlan',
      order: 'WriteDate',
      desc: true,
      conditions: {
        Name: { value: undefined, type: 'like' },
        WriteDate: { value: undefined, type: 'between' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 弹窗
      dialogVisible: false,
      model: {}
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

    WriteDateFormatter: function(row) {
      let d = moment(row.WriteDate);
      if (d.year() === 1900) {
        return '';
      }

      return d.format('YYYY-MM-DD');
    },

    handlePageChange: function(page) {
      this.page = page;
      this.load();
    },

    timeFormatter(time) {
      let d = moment(time);
      if (d.year() < 2000) {
        return '';
      }

      return d.format('YYYY-MM-DD HH:mm:ss');
    },

    showDetail(model) {
      this.model = model;
      this.dialogVisible = true;
    }
  },

  mounted() {

    this.load();
  }
};
</script>
<style scoped lang="scss">

</style>

