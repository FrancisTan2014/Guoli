<template>
  <section>
    <el-row id="preview">
      <el-col :span="24">
        <h3 class="preview-title">指导司机 LKJ 运行记录数据分析登记表</h3>
      </el-col>
      <el-col :span="24" class="preview-content">
        <el-col class="normal-height" :span="2">运行日期</el-col>
        <el-col class="normal-height" :span="4">{{ data.RunDate | moment("YYYY-MM-DD") }}</el-col>
        <el-col class="normal-height" :span="2">运行区段</el-col>
        <el-col class="normal-height" :span="4">{{ data.RunSection }}</el-col>
        <el-col class="normal-height" :span="2">机车</el-col>
        <el-col class="normal-height" :span="4">{{ data.LocomotiveType }}</el-col>
        <el-col class="normal-height" :span="3">车次</el-col>
        <el-col class="normal-height" :span="3">{{ data.TrainCode }}</el-col>
        <el-col class="normal-height" :span="2">司机</el-col>
        <el-col class="normal-height" :span="4">{{ data.DriverName }}</el-col>
        <el-col class="normal-height" :span="2">学习司机</el-col>
        <el-col class="normal-height" :span="4">{{ data.ViceDriverName }}</el-col>
        <el-col class="normal-height" :span="2">分析日期</el-col>
        <el-col class="normal-height" :span="4">{{ data.AnalysisStart | moment("YYYY-MM-DD") }}</el-col>
        <el-col class="normal-height" :span="3">是否为关键人</el-col>
        <el-col class="normal-height" :span="3">{{ isKeyPerson ? '是' : '否' }}</el-col>
        <el-col class="large-height" :span="1">发现问题登记</el-col>
        <el-col class="large-height" :span="23">{{ data.Problems }}</el-col>
        <el-col class="large-height last" :span="1">指导意见</el-col>
        <el-col class="large-height last" :span="23">{{ data.Suggests }}</el-col>
      </el-col>
    </el-row>
  </section>
</template>

<script>
import server from '@/store/server';
import moment from 'moment';
import {convertCSharpTime} from '@/utils';

export default {
  data() {
    return {
      data: {},
      isKeyPerson: false
    };
  },

  methods: {
    load: function () {
      let id = this.$route.query.id;
      if (!id) {
        this.$router.push('/404');
      } else {
        server.post('/Instructor/GetSingle', { id: id, target: 'ViewInstructorAnalysis' })
          .then(res => {
            let {data} = res;
            this.data = data || {};
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
$border: 1px solid #000;

#preview {
  background: #fff;
  font-family: 'Microsoft YaHei';
  padding: 50px;
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
    height: 3rem;
    line-height: 3rem;
    text-align: center;
    border-right: $border;
    border-bottom: $border;

    &:nth-child(8) {
      border-right: none;
    }
    &:nth-child(16) {
      border-right: none;
    }
  }

  .large-height {
    padding: 8px;
    border-bottom: $border;
    height: 8rem;

    &:nth-child(2n+1) {
      border-right: $border;
    }
    &.last {
      border-bottom: none;
    }

    p {
      padding-left: 16px;
    }
  }
}
</style>

