<template>
  <section>
    <el-row id="preview">
      <el-col :span="24">
        <h3 class="preview-title">安&nbsp;&nbsp;&nbsp;&nbsp;全&nbsp;&nbsp;&nbsp;&nbsp;关&nbsp;&nbsp;&nbsp;&nbsp;键&nbsp;&nbsp;&nbsp;&nbsp;管&nbsp;&nbsp;&nbsp;&nbsp;理</h3>
      </el-col>
      <el-col :span="24" class="preview-content">
        <el-col class="normal-height" :span="4">关键人姓名</el-col>
        <el-col class="normal-height" :span="4">确定原因</el-col>
        <el-col class="normal-height" :span="8">帮救措施</el-col>
        <el-col class="normal-height" :span="4">转变情况</el-col>
        <el-col class="normal-height" :span="4">解除意见</el-col>
        <el-col class="normal-height" :span="4">{{ data.KeyPersonName }}</el-col>
        <el-col class="normal-height" :span="4">{{ data.PersonConfirmReason }}</el-col>
        <el-col class="normal-height" :span="8">{{ data.HelpMethod }}</el-col>
        <el-col class="normal-height" :span="4">{{ data.Changes }}</el-col>
        <el-col class="normal-height" :span="4">{{ data.PersonRemoveSuggests }}</el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="8"></el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="4">关键点</el-col>
        <el-col class="normal-height" :span="4">确定原因</el-col>
        <el-col class="normal-height" :span="8">盯控措施</el-col>
        <el-col class="normal-height" :span="4">落实情况</el-col>
        <el-col class="normal-height" :span="4">解除意见</el-col>
        <el-col class="normal-height" :span="4">{{ data.KeyLocation }}</el-col>
        <el-col class="normal-height" :span="4">{{ data.LocationConfirmReason }}</el-col>
        <el-col class="normal-height" :span="8">{{ data.ControlMethod }}</el-col>
        <el-col class="normal-height" :span="4">{{ data.ActualControl }}</el-col>
        <el-col class="normal-height" :span="4">{{ data.LocationRemoveSuggests }}</el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="8"></el-col>
        <el-col class="normal-height" :span="4"></el-col>
        <el-col class="normal-height" :span="4"></el-col>
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
      let id = this.$route.query.id;
      if (!id) {
        this.$router.push('/404');
      } else {
        server.post('/Instructor/GetSingle', { id: id, target: 'ViewInstructorKeyPerson' })
          .then(res => {
            let { data } = res;
            this.data = data;
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

    &:nth-child(5n) {
      border-right: none;
    }

    // 第11到第15个元素
    &:nth-child(n+11):not(:nth-child(n+16)) {
      border-bottom: 2px solid #000;
    }

    &:nth-child(n+26) {
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

