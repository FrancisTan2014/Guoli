


<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.FullName.value" placeholder="车次"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.DriverName.value" placeholder="司机姓名"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.LocomotiveType.value" placeholder="机车型号"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.LineName.value" placeholder="运行线路"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.AttendTime.value" type="daterange" placeholder="运行日期" align="right">
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

      <el-table-column prop="DriverName" label="司机" :formatter="DriverNameFormatter"></el-table-column>
      <el-table-column prop="ViceDriverName" label="副司机" :formatter="ViceDriverNameFormatter"></el-table-column>
      <el-table-column prop="FullName" label="车次"></el-table-column>
      <el-table-column prop="LineName" label="运行线路"></el-table-column>
      <el-table-column prop="LocomotiveType" label="机车型号"></el-table-column>
      <el-table-column prop="AttendTime" label="出勤时间" :formatter="AttendTimeFormatter" sortable></el-table-column>
      <el-table-column prop="RecordEndTime" label="退勤时间" :formatter="RecordEndTimeFormatter" sortable></el-table-column>
      <el-table-column prop="AddTime" label="添加时间" :formatter="AddTimeFormatter" sortable></el-table-column>

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
    <el-dialog :title="(`司机报单：${record.FullName} | ${record.LineName} | ${timeFormatter(record.AttendTime)}`)" :visible="dialogVisible" :before-close="() => dialogVisible = false">

      <el-tabs v-model="activeName">
        <el-tab-pane label="出勤信息" name="first">
          <el-row class="row">
            <el-col :span="6">车次：{{ record.FullName }}</el-col>
            <el-col :span="6">机车型号：{{ record.LocomotiveType }}</el-col>
          </el-row>
          <el-row class="row">
            <el-col :span="6">线路：{{ record.LineName }}</el-col>
            <el-col :span="6">出勤时间：{{ timeFormatter(record.AttendTime) }}</el-col>
          </el-row>
          <el-row class="row">
            <el-col :span="6">司机：{{ record.DriverName }}</el-col>
            <el-col :span="6">接车时间：{{ timeFormatter(record.GetTrainTime) }}</el-col>
          </el-row>
          <el-row class="row">
            <el-col :span="6">副司机：{{ record.ViceDriverName }}</el-col>
            <el-col :span="6">出本段时间：{{ timeFormatter(record.LeaveDepotTime1) }}</el-col>
          </el-row>
          <el-row class="row">
            <el-col :span="6">学员：{{ record.StuDriverName }}</el-col>
            <el-col :span="6">出外段时间：{{ timeFormatter(record.LeaveDepotTime2) }}</el-col>
          </el-row>
          <el-row class="row">
            <el-col :span="24">出勤会：{{ record.AttendForecast }}</el-col>
          </el-row>
        </el-tab-pane>
        <el-tab-pane label="运行及编组" name="second">
          <el-table :data="signs" style="width: 100%">
            <el-table-column prop="StationName" label="站名" width="150"></el-table-column>
            <el-table-column prop="ArriveTime" label="到达" :formatter="ArriveTimeFormatter"></el-table-column>
            <el-table-column prop="LeaveTime" label="出发" :formatter="LeaveTimeFormatter"></el-table-column>
            <el-table-column prop="EarlyMinutes" label="早点" :formatter="EarlyMinutesFormatter"></el-table-column>
            <el-table-column prop="LateMinutes" label="晚点" :formatter="LateMinutesFormatter"></el-table-column>
            <el-table-column prop="EarlyOrLateReason" label="原因"></el-table-column>
            <el-table-column prop="CarryingCapacity" label="辆数"></el-table-column>
            <el-table-column prop="CarriageCount" label="吨数"></el-table-column>
            <el-table-column prop="Length" label="计长"></el-table-column>
          </el-table>
        </el-tab-pane>
        <el-tab-pane label="退勤信息" name="third">
          <el-row>
            <el-col span="8">
              <el-col :span="24" class="end-title">时间点</el-col>
              <el-col :span="24" class="center mt8">入本段时间：{{ timeFormatter(record.ArriveDepotTime1) }}</el-col>
              <el-col :span="24" class="center mt8">入外段时间：{{ timeFormatter(record.ArriveDepotTime2) }}</el-col>
              <el-col :span="24" class="center mt8">交车时间：{{ timeFormatter(record.GiveTrainTime) }}</el-col>
              <el-col :span="24" class="center mt8">退勤时间：{{ timeFormatter(record.RecordEndTime) }}</el-col>
            </el-col>
            <el-col span="8">
              <el-col :span="24" class="end-title">能源消耗</el-col>
              <el-col :span="24" class="center mt8">运转使用油/电量：{{ record.OperateConsume }}</el-col>
              <el-col :span="24" class="center mt8">段内打温时间：{{ record.StopConsume }}</el-col>
              <el-col :span="24" class="center mt8">接收量：{{ record.RecieveEnergy }}</el-col>
              <el-col :span="24" class="center mt8">交出量：{{ record.LeftEnergy }}</el-col>
            </el-col>
            <el-col span="8">
              <el-col :span="24" class="end-title">重联机车</el-col>
              <el-col :span="24" class="center mt8">机务段：{{ record.MultiLocoDepot }}</el-col>
              <el-col :span="24" class="center mt8">机车型号：{{ record.MultiLocoType }}</el-col>
              <el-col :span="24" class="center mt8">附挂区间：{{ record.MultiLocoSection }}</el-col>
              <el-col :span="24" class="center mt8">无</el-col>
            </el-col>
            <el-col span="8">
              <el-col :span="24" class="end-title">油脂消耗</el-col>
              <el-col :span="24" class="center mt8">机油：{{ record.EngineOil }}</el-col>
              <el-col :span="24" class="center mt8">风泵油：{{ record.AirCompressorOil }}</el-col>
              <el-col :span="24" class="center mt8">透平油：{{ record.TurbineOil }}</el-col>
              <el-col :span="24" class="center mt8">齿轮油：{{ record.GearOil }}</el-col>
              <el-col :span="24" class="center mt8">调速器油：{{ record.GovernorOil }}</el-col>
              <el-col :span="24" class="center mt8">其他油类：{{ record.OtherOil }}</el-col>
              <el-col :span="24" class="center mt8">棉丝：{{ record.Staple }}</el-col>
            </el-col>
            <el-col span="8">
              <el-col :span="24" class="end-title">退勤会</el-col>
              <el-col :span="24" class="center mt8">{{ record.EndSummary }}</el-col>
            </el-col>
          </el-row>
        </el-tab-pane>
      </el-tabs>

      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false" type="primary">关闭</el-button>
      </div>

    </el-dialog>

  </section>
</template>
<script>

import moment from 'moment';
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
      table: 'ViewDriveRecord',
      order: 'AddTime',
      desc: true,
      conditions: {
        FullName: { value: undefined, type: 'like' },
        DriverName: { value: undefined, type: 'like' },
        LocomotiveType: { value: undefined, type: 'like' },
        LineName: { value: undefined, type: 'like' },
        AttendTime: { value: undefined, type: 'between' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 弹窗
      dialogVisible: false,
      record: {},
      signs: [],
      activeName: 'first'
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

    DriverNameFormatter: function(row) { return `${row.DriverName}-${row.DriverWorkNo}`; },

    ViceDriverNameFormatter: function(row) {
      if (row.ViceDriverName) {
        return `${row.ViceDriverName}-${row.ViceDriverWorkNo}`;
      }

      return '';
    },

    AttendTimeFormatter: function(row) {
      let d = moment(row.AttendTime);
      if (d.year() === 1900) {
        return '';
      }

      return d.format('YYYY-MM-DD HH:mm');
    },

    RecordEndTimeFormatter: function(row) {
      let d = moment(row.RecordEndTime);
      if (d.year() === 1900) {
        return '';
      }

      return d.format('YYYY-MM-DD HH:mm');
    },

    AddTimeFormatter: function(row) {
      let d = moment(row.AddTime);
      if (d.year() === 1900) {
        return '';
      }

      return d.format('YYYY-MM-DD HH:mm');
    },

    timeFormatter(time) {
      let d = moment(time);
      if (d.year() < 2000) {
        return '';
      }

      return d.format('YYYY-MM-DD HH:mm:ss');
    },

    ArriveTimeFormatter(row) {
      let d = moment(row.ArriveTime);
      if (d.year() === 1970 || !d.isValid()) {
        return '';
      }

      return d.format('HH:mm');
    },

    LeaveTimeFormatter(row) {
      let d = moment(row.LeaveTime);
      if (d.year() === 1970 || !d.isValid()) {
        return '';
      }

      return d.format('HH:mm');
    },

    EarlyMinutesFormatter(row) {
      if (row.EarlyMinutes > 0) {
        return row.EarlyMinutes;
      }

      return '';
    },

    LateMinutesFormatter(row) {
      if (row.LateMinutes > 0) {
        return row.LateMinutes;
      }

      return '';
    },

    handlePageChange: function(page) {
      this.page = page;
      this.load();
    },

    showDetail(model) {
      NProgress.start();
      server.post('/Common/GetDriverRecord', { id: model.Id }, this)
        .then(res => {
          NProgress.done();

          if (res.code === 108) {
            this.record = res.data.record;
            this.signs = res.data.signs;
            this.dialogVisible = true;
          } else {
            this.$error('数据获取失败(:=');
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
.row {
  margin-top: 8px;
}

.end-title {
  font-size: 16px;
  text-align: center;
  padding: 16px;
  margin-top: 8px;
}

.center {
  text-align: center;
}

.mt8 {
  margin-top: 8px;
}
</style>

