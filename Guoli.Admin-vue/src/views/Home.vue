<template>
  <el-row :gutter="10" class="container">

    <!-- header start -->
    <el-col :span="24" class="header">
      <el-col :span="20" class="logo">
        <img src="../assets/logo.png" />
        <span>机务运用管控系统后台管理</span>
      </el-col>
      <el-col :span="4" class="userinfo">
        <el-dropdown trigger="click">
          <span class="el-dropdown-link userinfo-inner">
            <img :src="sysUserPhoto" v-if="!!sysUserPhoto" />
            <img src="../assets/logo.png" v-if="!sysUserPhoto" /> {{sysUserName || '管理员'}}</span>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item @click.native="logout">退出登录</el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </el-col>
    </el-col>
    <!-- header end -->

    <!-- main start -->
    <el-col :span="24" class="main">

      <!-- menu start -->
      <aside>
        <el-menu :default-active="$route.path" class="el-menu-vertical-demo" theme="dark" unique-opened router>
          <el-submenu :key="index" :index="index+''" v-for="(item,index) in $router.options.routes" v-if="showOrNot(item)">

            <el-menu-item v-for="child in item.children" :key="child.path" :index="child.path" v-if="showOrNot(child) && !child.children">{{ item.name }}</el-menu-item>

            <template slot="title">
              <i :class="item.iconCls"></i>{{item.name}}</template>
            <el-submenu v-for="child in item.children" :key="child.name" :index="child.path" v-if="showOrNot(child) && child.children">
              <template slot="title">
              <i :class="child.iconCls"></i>{{child.name}}</template>
              <el-menu-item v-for="grand in child.children" :key="grand.name" :index="grand.path" v-if="showOrNot(grand)">{{grand.name}}</el-menu-item>
            </el-submenu>
          </el-submenu>
        </el-menu>
      </aside>
      <!-- menu end -->

      <!-- content start -->
      <section class="content-container">
        <div class="grid-content bg-purple-light">
          <el-col :span="24" class="breadcrumb-container">
            <!--<strong class="title">{{$route.name}}</strong>-->
            <el-breadcrumb separator="/" class="breadcrumb-inner">
              <el-breadcrumb-item v-for="item in $route.matched" :key="item.name">
                {{ item.name }}
              </el-breadcrumb-item>
            </el-breadcrumb>
          </el-col>
          <el-col :span="24" class="content-wrapper">
            <transition>
              <router-view></router-view>
            </transition>
          </el-col>
        </div>
      </section>
      <!-- content end -->

    </el-col>
    <!-- main end -->

  </el-row>
</template>

<script>
import local from '../store/local';

export default {
  data() {
    return {
      // isSuperAdminLogin: store.isSuperAdminLogin(),

      sysUserPhoto: '',
      sysUserName: ''
    };
  }, // end data()

  methods: {
    showOrNot: function (item) {
      return !item.hidden;
    },

    logout() {
      this.$confirm('确认退出吗？', '提示', {
        // type: 'warning'
      }).then(() => {
        local.removeItem('token');
        this.$router.push('/login');
      });
    }
  }, // end methods

  mounted() {
    // let user = store.getLoginUser();
    // if (user && user.Id > 0) {
    //   let account = store.getLoginAccount();
    //   this.sysUserName = user.Name || account;
    //   if (!!user.HeadPortraitPath) {
    //     this.sysUserPhoto = config.fileServer + user.HeadPortraitPath;
    //   }
    // }
  } // end mounted
};
</script>

<style scoped lang="scss">
.container {
  position: absolute;
  top: 0px;
  bottom: 0px;
  width: 100%;
  .header {
    height: 60px;
    line-height: 60px;
    background: #1F2D3D;
    color: #c0ccda;
    .userinfo {
      text-align: right;
      padding-right: 35px;
      .userinfo-inner {
        color: #c0ccda;
        cursor: pointer;
        img {
          width: 40px;
          height: 40px;
          border-radius: 20px;
          margin: 10px 0px 10px 10px;
          float: right;
        }
      }
    }
    .logo {
      font-size: 22px;
      img {
        width: 40px;
        float: left;
        margin: 10px 10px 10px 18px;
      }
      .txt {
        color: #20a0ff
      }
    }
  }
  .main {
    background: #324057;
    position: absolute;
    top: 60px;
    bottom: 0px;
    overflow: hidden;
    aside {
      width: 230px;
    }
    .content-container {
      background: #f1f2f7;
      position: absolute;
      right: 0px;
      top: 0px;
      bottom: 0px;
      left: 230px;
      overflow-y: scroll;
      padding: 20px;
      .breadcrumb-container {
        margin-bottom: 15px;
        .title {
          width: 200px;
          float: left;
          color: #475669;
        }
        .breadcrumb-inner {
          float: left;
        }
      }
      .content-wrapper {
        background-color: #fff;
        box-sizing: border-box;
        padding-bottom: 20px;
      }
    }
  }
}
</style>

