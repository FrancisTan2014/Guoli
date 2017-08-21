<template>
  <section>
    <el-row id="preview">
      <el-col :span="24">
        <h3 class="preview-title">机&nbsp;&nbsp;&nbsp;&nbsp;车&nbsp;&nbsp;&nbsp;&nbsp;质&nbsp;&nbsp;&nbsp;&nbsp;量&nbsp;&nbsp;&nbsp;&nbsp;登&nbsp;&nbsp;&nbsp;&nbsp;记&nbsp;&nbsp;&nbsp;&nbsp;(包&nbsp;&nbsp;&nbsp;&nbsp;乘&nbsp;&nbsp;&nbsp;&nbsp;制）</h3>
      </el-col>
      <el-col :span="24" class="preview-content">
        <el-row class="preview-head">
          <el-col :span="12" class="head-left">
            <el-col class="th" :span="4">机车型号</el-col>
            <el-col class="th" :span="4">修程</el-col>
            <el-col class="th" :span="4">保养及质量</el-col>
            <el-col class="th" :span="4">评定成绩</el-col>
            <el-col class="th" :span="8">惯性故障处所</el-col>
          </el-col>
          <el-col :span="12" class="head-right">
            <el-col class="th-up" :span="24">机&nbsp;&nbsp;破&nbsp;&nbsp;临&nbsp;&nbsp;修&nbsp;&nbsp;记&nbsp;&nbsp;录</el-col>
            <el-col :span="24">
              <el-col class="th-down" :span="4">日期</el-col>
              <el-col class="th-down" :span="4">司机</el-col>
              <el-col class="th-down" :span="4">车次</el-col>
              <el-col class="th-down" :span="4">概况</el-col>
              <el-col class="th-down" :span="4">故障处所及原因</el-col>
              <el-col class="th-down" :span="4">责任</el-col>
            </el-col>
          </el-col>
        </el-row>

        <el-row v-for="item in data" :key="item.Id" class="preview-row">
          <el-col class="normal-height" :span="2">{{ item.LocomotiveType }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.RepairClass }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.MaintenanceStatus }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.Score }}</el-col>
          <el-col class="normal-height" :span="4">{{ item.FaultLocation }}</el-col>

          <el-col class="normal-height" :span="2">{{ item.RegistDate | moment('YYYY-MM-DD') }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.DriverName }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.TrainCode }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.GeneralSituation }}</el-col>
          <el-col class="normal-height" :span="2"></el-col>
          <el-col class="normal-height" :span="2"></el-col>
        </el-row>

      </el-col>
    </el-row>
  </section>
</template>

<script>
import server from '@/store/server';
import moment from 'moment';

export default {
  data() {
    return {
      data: {}
    };
  },

  methods: {
    load: function () {
      this.data = this.$route.params.data;
    }
  },

  mounted() {
    this.load();
  }
};
</script>

<style scoped lang="scss">
#preview {
  background: #fff;
  font-family: 'Microsoft YaHei';
  padding: 10px;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
}

.preview-title {
  text-align: center;
  font-size: 1.8rem;
  font-weight: 800;
  margin: 24px 0 0 0;
}

.preview-content {
  border: 2px solid #000;
  margin-top: 8px;

  .preview-head {
    text-align: center;
    height: 4.8rem;
    border-bottom: 1px solid #000;

    .head-left {
      .th {
        height: 4.8rem;
        line-height: 4.8rem;
        border-right: 1px solid #000;
      }
    }

    .head-right {
      .th-up {
        height: 1.6rem;
        line-height: 1.6rem;
        border-bottom: 1px solid #000;
      }

      .th-down {
        height: 3.2rem;
        line-height: 3.2rem;
        border-right: 1px solid #000;

        &::last-child {
          border-right: none;
        }
      }
    }

    &:last-child {
      .normal-height {
        border-bottom: none;
      }
    }
  }

  .normal-height {
    height: 2rem;
    line-height: 2rem;
    text-align: center;
    border-right: 1px solid #000;
    border-bottom: 1px solid #000;

    &:nth-child(11n) {
      border-right: none;
    }
  }
}
</style>

