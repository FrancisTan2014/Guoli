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
        <el-menu :default-active="onRoutes" class="el-menu-vertical-demo" theme="dark" unique-opened router>

          <!-- 一级菜单 -->
          <template v-for="item in menus">

            <!-- 二级菜单 -->
            <template v-if="item.subs">

              <el-submenu :index="item.index">
                  <template slot="title">
                        <i :class="item.icon"></i>{{ item.title }}</template>

                <!-- 三级菜单 -->
                <template v-for="(child, i) in item.subs">

                  <template v-if="child.subs">
                    <el-submenu :index="child.index">
                      <template slot="title">
                        <i :class="child.icon"></i>{{ child.title }}</template>
                      <el-menu-item v-for="(grand, j) in child.subs" :key="j" :index="grand.index">{{ grand.title }}
                      </el-menu-item>
                    </el-submenu>
                  </template>
                  <template v-else>
                    <el-menu-item :index="child.index">{{ child.title }}</el-menu-item>
                  </template>

                </template>
                <!-- 三级菜单 -->

              </el-submenu>

            </template>
            <template v-else>

              <el-menu-item :index="item.index">
                <i :class="item.icon"></i>{{ item.title }}
              </el-menu-item>

            </template>
            <!-- 二级菜单 -->

          </template>
          <!-- 一级菜单 -->

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
                {{ item.desc }}
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
      sysUserName: '',

      menus: [
        {
          icon: 'el-icon-menu',
          index: '1',
          title: '行车资料',
          subs: [
            { index: 'files', title: '文件管理' }
          ]
        },

        {
          icon: 'el-icon-menu',
          index: '2',
          title: '指导司机',
          subs: [
            {
              index: '2-1',
              title: '工作记录',
              icon: 'el-icon-menu',
              subs: [
                { index: 'keyperson', title: '关键人管理' },
                { index: 'temptake', title: '添乘信息单' },
                { index: 'analysis', title: '监控分析单' },
                { index: 'check', title: '抽查信息单' },
                { index: 'repair', title: '机破临修记录' },
                { index: 'quality', title: '机车质量登记' },
                { index: 'good', title: '防止事故及好人好事记录' },
                { index: 'peccany', title: '违章违纪记录' },
                { index: 'teach', title: '授课培训记录' },
                { index: 'plan', title: '工作总结计划' },
                { index: 'accept', title: '标准化验收' },
              ]
            }
          ]
        },

        {
          icon: 'el-icon-menu',
          index: '3',
          title: '司机手账',
          subs: [
            { index: 'drive', title: '司机报单' }
          ]
        },

        {
          icon: 'el-icon-menu',
          index: '4',
          title: '考试管理',
          subs: [
            { index: 'examlib', title: '题库管理' },
            { index: 'examnotify', title: '考试通知' },
            { index: 'examresult', title: '考试结果' },
          ]
        },
        {
          icon: 'el-icon-menu',
          index: '5',
          title: '通知公告',
          subs: [
            { index: 'announce', title: '公告管理' }
          ]
        },
        {
          icon: 'el-icon-menu',
          index: '6',
          title: '系统',
          subs: [
            { index: 'account', title: '账户管理' },
            { index: 'log', title: '操作日志' },
          ]
        },

      ]
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
    },

  }, // end methods

  computed: {
    onRoutes: function () {
      this.$route.path.replace('/', '');
    }
  },

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

