<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">
        <el-form-item>
          <el-input v-model="conditions.Name.value" placeholder="姓名"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.TrainCode.value" placeholder="车次"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.TakeDate.value" type="datetimerange" :picker-options="pickerOptions" placeholder="添乘时间" align="right">
          </el-date-picker>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <!-- <el-button type="primary" v-on:click="print">打印</el-button> -->
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">
      <el-table-column type="index" width="80" label="序号"></el-table-column>
      <el-table-column prop="Name" label="指导司机"></el-table-column>
      <el-table-column prop="DepartmentName" label="所属单位"></el-table-column>
      <el-table-column prop="TrainCode" label="添乘车次"></el-table-column>
      <el-table-column prop="TakeDate" label="添乘时间" :formatter="timeFomatter"></el-table-column>
      <el-table-column prop="TakeSection" label="添乘区段"></el-table-column>
      <el-table-column prop="DriverName" label="主班司机"></el-table-column>
      <el-table-column label="操作" min-width="150">
        <template scope="scope">
          <el-button size="small" type="text" @click="detailPreview(scope.$index, scope.row)">查看详情</el-button>
        </template>
      </el-table-column>
    </el-table>

    <!--工具条-->
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

    <el-dialog :visible="detailVisible" size="large">
      <el-row id="preview">
        <el-col :span="24">
          <p class="preview-fujian">附件 12</p>
          <h3 class="preview-title">添&nbsp;&nbsp;&nbsp;&nbsp;乘&nbsp;&nbsp;&nbsp;&nbsp;信&nbsp;&nbsp;&nbsp;&nbsp;息&nbsp;&nbsp;&nbsp;&nbsp;单</h3>
        </el-col>
        <el-col :span="24" class="preview-time">
          2017 年 8 月 6 日
        </el-col>
        <el-col :span="24" class="preview-content">
          <el-col class="normal-height" :span="3">机车（动车组）型号</el-col>
          <el-col class="normal-height" :span="3"></el-col>
          <el-col class="normal-height" :span="2">司机</el-col>
          <el-col class="normal-height" :span="6"></el-col>
          <el-col class="normal-height" :span="6">（副）司机</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="normal-height" :span="3">车次</el-col>
          <el-col class="normal-height" :span="3"></el-col>
          <el-col class="normal-height" :span="2">辆数</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="normal-height" :span="2">总重</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="normal-height" :span="2">计长</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="normal-height" :span="3">添乘者姓名</el-col>
          <el-col class="normal-height" :span="3"></el-col>
          <el-col class="normal-height" :span="2">职务</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="normal-height" :span="2">区段</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="normal-height" :span="2">时间</el-col>
          <el-col class="normal-height" :span="4"></el-col>
          <el-col class="large-height" :span="24">
            添乘目的：
            <p>为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全为了加强安全</p>
          </el-col>
          <el-col class="large-height" :span="24">发现的主要问题：</el-col>
          <el-col class="large-height" :span="24">指导意见：</el-col>
          <el-col class="normal-height" :span="24">司机签认：</el-col>
        </el-col>
      </el-row>
      <span slot="footer" class="dialog-footer">
        <el-button @click="detailVisible = false">取 消</el-button>
        <el-button type="primary" @click="print">确 定</el-button>
      </span>
    </el-dialog>

  </section>
</template>

<script>
import moment from 'moment';
import server from '@/store/server';
import { timepickerOptions, convertCSharpTime, print } from '@/utils';

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      api: '/Instructor/GetListForVue',
      table: 'ViewInstructorTempTake',
      order: 'TakeDate',
      desc: true,
      conditions: {
        Name: { value: '', type: 'like' },
        TrainCode: { value: '', type: 'equal' },
        TakeDate: { value: [], type: 'between' }
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 时间选择器配置
      pickerOptions: timepickerOptions,

      // 查看详情
      detailVisible: false
    };
  },

  methods: {
    load: function () {
      let o = {
        page: this.page,
        size: this.size,
        table: this.table,
        order: this.order,
        desc: this.desc,
        conditions: this.conditions
      };
      server.post(this.api, { json: JSON.stringify(o) }).then(res => {
        let { data } = res;
        if (data) {
          let { total, list } = data;
          this.total = total;
          this.data = list;
        }
      });
    },

    timeFomatter: function (row, col) {
      return moment(row.TakeDate).format('YYYY-MM-DD');
    },

    handlePageChange: function (page) {
      this.page = page;
      this.load();
    },

    detailPreview: function (index, row) {
      // this.detailVkisible = true;
      this.$router.push({ path: '/temptake-prev?id=' + row.Id, params: { data: row } });
    },

    print: function () {
      print('table');
    }
  },

  mounted() {
    this.load();
  }
};
</script>

<style scoped lang="scss" id="style">
#preview {

  font-family: 'Microsoft YaHei';
}

.preview-fujian {
  text-align: left;
}

.preview-title {
  text-align: center;
  font-size: 1.8rem;
  font-weight: 800;
}

.preview-time {
  text-align: right;
}

.preview-content {
  border: 2px solid #000;
  margin-top: 8px;

  .normal-height {
    height: 2rem;
    line-height: 2rem;
    text-align: center;
    border-right: 1px solid #000;
    border-bottom: 1px solid #000;

    &:nth-child(6),
    &:nth-child(14),
    &:nth-child(22) {
      border-right: none
    }
  }

  .large-height {
    padding: 8px;
    border-bottom: 1px solid #000;
    height: 10rem;

    &:nth-child(2) {
      height: 17rem;
    }

    p {
      padding-left: 16px;
    }
  }
}
</style>

