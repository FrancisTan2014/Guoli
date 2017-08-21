<template>
  <section>
    <el-row id="preview">
      <el-col :span="24">
        <h3 class="preview-title">违&nbsp;&nbsp;&nbsp;&nbsp;章&nbsp;&nbsp;&nbsp;&nbsp;违&nbsp;&nbsp;&nbsp;&nbsp;纪&nbsp;&nbsp;&nbsp;&nbsp;记&nbsp;&nbsp;&nbsp;&nbsp;录</h3>
      </el-col>
      <el-col :span="24" class="preview-content">
        <el-col class="normal-height" :span="2">日期</el-col>
        <el-col class="normal-height" :span="2">姓名</el-col>
        <el-col class="normal-height" :span="2">职务</el-col>
        <el-col class="normal-height" :span="3">性质</el-col>
        <el-col class="normal-height" :span="5">概况</el-col>
        <el-col class="normal-height" :span="5">分析情况</el-col>
        <el-col class="normal-height" :span="5">处理意见</el-col>

        <template v-for="item in data">
          <el-col class="normal-height" :span="2">{{ item.WriteDate | moment('YYYY-MM-DD') }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.DriverName }}</el-col>
          <el-col class="normal-height" :span="2">{{ item.DriverPostName }}</el-col>
          <el-col class="normal-height" :span="3" :key="item.Id">{{ item.PeccanyType }}</el-col>
          <el-col class="normal-height" :span="5">{{ item.GeneralSituation }}</el-col>
          <el-col class="normal-height" :span="5">{{ item.Analysis }}</el-col>
          <el-col class="normal-height" :span="5">{{ item.Suggests }}</el-col>
        </template>

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
      // let id = this.$route.query.id;
      // if (!id) {
      //   this.$router.push('/404');
      // } else {
      //   server.post('/Instructor/GetSingle', { id: id, target: 'ViewInstructorKeyPerson' })
      //     .then(res => {
      //       let { data } = res;
      //       this.data = data;
      //     });
      // }
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

  .normal-height {
    height: 2rem;
    line-height: 2rem;
    text-align: center;
    border-right: 1px solid #000;
    border-bottom: 1px solid #000;

    &:nth-child(7n) {
      border-right: none;
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

