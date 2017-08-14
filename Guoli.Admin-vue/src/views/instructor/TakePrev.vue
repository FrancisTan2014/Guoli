<template>
  <section>
    <el-row id="preview">
      <el-col :span="24">
        <p class="preview-fujian">附件 12</p>
        <h3 class="preview-title">添&nbsp;&nbsp;&nbsp;&nbsp;乘&nbsp;&nbsp;&nbsp;&nbsp;信&nbsp;&nbsp;&nbsp;&nbsp;息&nbsp;&nbsp;&nbsp;&nbsp;单</h3>
      </el-col>
      <el-col :span="24" class="preview-time">
        年&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;日
      </el-col>
      <el-col :span="24" class="preview-content">
        <el-col class="normal-height" :span="5">机车（动车组）型号</el-col>
        <el-col class="normal-height" :span="3">{{ data.LocomotiveType }}</el-col>
        <el-col class="normal-height" :span="2">司机</el-col>
        <el-col class="normal-height" :span="4">{{ data.DriverName }}</el-col>
        <el-col class="normal-height" :span="6">（副）司机</el-col>
        <el-col class="normal-height" :span="4">{{ data.ViceDriverName }}</el-col>
        <el-col class="normal-height" :span="3">车次</el-col>
        <el-col class="normal-height" :span="3">{{ data.TrainCode }}</el-col>
        <el-col class="normal-height" :span="2">辆数</el-col>
        <el-col class="normal-height" :span="4">{{ data.CarCount }}</el-col>
        <el-col class="normal-height" :span="2">总重</el-col>
        <el-col class="normal-height" :span="4">{{ data.WholeWeight }}</el-col>
        <el-col class="normal-height" :span="2">计长</el-col>
        <el-col class="normal-height" :span="4">{{ data.Length }}</el-col>
        <el-col class="normal-height" :span="3">添乘者姓名</el-col>
        <el-col class="normal-height" :span="3">{{ data.Name }}</el-col>
        <el-col class="normal-height" :span="2">职务</el-col>
        <el-col class="normal-height" :span="4">{{ data.PostName }}</el-col>
        <el-col class="normal-height" :span="2">区段</el-col>
        <el-col class="normal-height" :span="4">{{ data.TakeSection }}</el-col>
        <el-col class="normal-height" :span="2">时间</el-col>
        <el-col class="normal-height" :span="4">{{ data.TakeDate | moment('YYYY-MM-DD') }}</el-col>
        <el-col class="large-height" :span="24">
          添乘目的：
          <p>{{ data.TakeAims }}</p>
        </el-col>
        <el-col class="large-height second" :span="24">发现的主要问题：
          <p>{{ data.Problems }}</p>
        </el-col>
        <el-col class="large-height third" :span="24">指导意见：
          <p>{{ data.Suggests }}</p>
        </el-col>
        <el-col class="normal-height last" :span="24">司机签认：</el-col>
      </el-col>
    </el-row>
  </section>
</template>

<script>
import server from '@/store/server';
import moment from 'moment';
import { convertCSharpTime } from '@/utils';

export default {
  data() {
    return {
      data: {}
    };
  },

  methods: {
    load: function () {
      let id = this.$route.query.id;
      if (!id) {
        this.$router.push('/404');
      } else {
        server.post('/Instructor/GetSingle', { id: id, target: 'ViewInstructorTempTake' })
          .then(res => {
            let { data } = res;
            this.data = data;
            console.info(data);
          });
      }
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

.preview-fujian {
  text-align: left;
}

.preview-title {
  text-align: center;
  font-size: 1.8rem;
  font-weight: 800;
  margin: 0;
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

    &:nth-child(6) {
      border-right: none;
    }
    &:nth-child(14) {
      border-right: none;
    }
    &:nth-child(22) {
      border-right: none;
    }

    &.last {
      border-right: none;
      border-bottom: none;
    }
  }

  .large-height {
    padding: 8px;
    border-bottom: 1px solid #000;
    height: 7rem;

    &.second {
      height: 21rem;
    }
    &.third {
      height: 14rem;
    }

    p {
      padding-left: 16px;
    }
  }
}
</style>

