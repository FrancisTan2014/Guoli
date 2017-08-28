<template>
  <div>
    <el-form v-if="isLogin" :model="loginUser" :rules="validator" ref="loginUser" label-position="left" label-width="0px" class="demo-ruleForm login-container" @submit.native.prevent="login">
      <h3 class="title">系统登录</h3>
      <el-form-item prop="Account">
        <el-input type="text" v-model="loginUser.Account" placeholder="账号"></el-input>
      </el-form-item>
      <el-form-item prop="Password">
        <el-input type="password" v-model="loginUser.Password" placeholder="密码"></el-input>
      </el-form-item>
      <!-- <el-checkbox v-model="checked" checked class="remember">记住密码</el-checkbox> -->
      <el-form-item class="w100p">
        <el-button type="primary" class="w100p" @click.native.prevent="login" :loading="loading">登 录</el-button>
        <el-button type="text" class="fr" @click="showChangeForm">修改密码</el-button>
      </el-form-item>
    </el-form>

    <el-form v-if="!isLogin" :model="changeUser" :rules="changeValidator" ref="changePwd" label-position="left" label-width="0px" class="demo-ruleForm login-container" @submit.native.prevent="changePassword">
      <h3 class="title">修改密码</h3>
      <el-form-item prop="account">
        <el-input type="text" v-model="changeUser.account" placeholder="账号"></el-input>
      </el-form-item>
      <el-form-item prop="oldPwd">
        <el-input type="password" v-model="changeUser.oldPwd" placeholder="旧密码"></el-input>
      </el-form-item>
      <el-form-item prop="newPwd">
        <el-input type="password" v-model="changeUser.newPwd" placeholder="新密码"></el-input>
      </el-form-item>
      <el-form-item class="w100p">
        <el-button type="primary" class="w100p" @click.native.prevent="changePassword" :loading="loading">确 定</el-button>
        <el-button class="fr" type="text" @click="isLogin = true">登 录</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import NProgress from 'nprogress';
import server from '../store/server';
import local from '../store/local';

let apiUrl = '/Home/Login';

export default {
  data() {
    return {
      isLogin: true,
      loginUser: {
        Account: '',
        Password: ''
      },

      validator: {
        Account: { required: true, message: '请输入账号', trigger: 'change' },
        Password: [{ required: true, message: '请输入密码', trigger: 'change' },
        { min: 6, max: 16, message: '密码长度必须在6~16之间', trigger: 'change' }]
      },

      changeUser: {
        account: '',
        oldPwd: '',
        newPwd: ''
      },

      changeValidator: {
        account: { required: true, message: '请输入账号', trigger: 'blur' },
        oldPwd: [{ required: true, message: '请输入新密码', trigger: 'blur' },
        { min: 6, max: 16, message: '密码长度必须在6~16之间', trigger: 'blur' }],
        newPwd: [{ required: true, message: '请输入新密码', trigger: 'blur' },
        { min: 6, max: 16, message: '密码长度必须在6~16之间', trigger: 'blur' }]
      },

      checked: true,
      loading: false
    }
  },

  methods: {
    // 登录
    login() {
      this.$refs.loginUser.validate(valid => {
        if (valid) {
          let u = this.loginUser;
          if (u.Account === '499166435@qq.com' && u.Password === '123456789') {
            // 特殊账号登录，进入app更新页面
            this.$router.push('/app');
            return;
          }

          this.loading = true;
          NProgress.start();

          server.post(apiUrl, this.loginUser).then(res => {
            this.loading = false;
            NProgress.done();

            let { code, data } = res;

            if (code !== 102) {
              // 登录失败
              this.$notify({
                title: '提示',
                message: '用户名或者密码错误(:=',
                type: 'error'
              });
            } else {
              let { token, user } = data;
              local.setItem('token', token);
              local.setItem('user', user);

              let _this = this;
              _this.$notify({
                title: '提示',
                message: '登录成功',
                type: 'success',
                duration: 2000,
                onClose: () => {
                  let backPath = _this.$route.query.back || _this.$route.params.back || '/';
                  _this.$router.replace(backPath);
                }
              });
            }
          });
        }
      });
    },

    showChangeForm() {
      this.isLogin = false;
      this.changeUser.account = '';
      this.changeUser.oldPwd = '';
      this.changeUser.newPwd = '';
    },

    // 修改密码
    changePassword() {
      this.$refs.changePwd.validate(valid => {
        if (valid) {
          let { account, oldPwd, newPwd } = this.changeUser;
          // BUG，element-ui框架没有验证newPwd字段
          if (!newPwd) {
            this.$error('请输入新密码(:=');
            return;
          }

          this.loading = true;
          NProgress.start();

          server.post('/System/ChangePwd', { account, oldPwd, newPwd }, this)
            .then(res => {
              this.loading = false;
              NProgress.done();

              if (res.code === 100) {
                this.$success('密码修改成功(:=');
                this.isLogin = true;

                // 清除登录状态
                local.removeItem('token');
                local.removeItem('user');
              } else if (res.code === 123) {
                this.$error('密码不正确(:=');
              } else {
                this.$error('账户不存在(:=');
              }
            });
        }
      });
    }

  }, // end methods,

  mounted() {
    // 从其他页面跳转至本页面时
    // 若想打开修改密码的表单
    // 则需传入参数changePwd且值为true
    this.isLogin = !this.$route.params.changePwd;
  }

} // end export
</script>

<style lang="scss" scoped>
.login-container {
  /*box-shadow: 0 0px 8px 0 rgba(0, 0, 0, 0.06), 0 1px 0px 0 rgba(0, 0, 0, 0.02);*/
  -webkit-border-radius: 5px;
  border-radius: 5px;
  -moz-border-radius: 5px;
  background-clip: padding-box;
  margin-bottom: 20px;
  background-color: #F9FAFC;
  margin: 180px auto;
  border: 2px solid #8492A6;
  width: 350px;
  padding: 35px 35px 15px 35px;
  .title {
    margin: 0px auto 40px auto;
    text-align: center;
    color: #505458;
  }
  .remember {
    margin: 0px 0px 35px 0px;
  }
  .w100p {
    width: 100%;
  }
  .fr {
    float:right;
  }
}
</style>
