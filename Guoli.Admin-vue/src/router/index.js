import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'
import NotFound from '@/views/NotFound'
import Forbidden from '@/views/Forbidden'
import Files from '@/views/Files'
import Login from '@/views/Login'
import Take from '@/views/Take'

Vue.use(Router)

export default new Router({
  // 不配置此项的url像这样：http://localhost:18082/#/login
  // 配置之后像这样：http://localhost:18082/login
  // mode: 'history',
  routes: [
    // {
    //   path: '/',
    //   name: '账户管理',
    //   component: Home,
    //   iconCls: 'el-icon-menu',
    //   children: [
    //     { path: '/department', name: '部门管理', component: Department, super: true },
    //     { path: '/person', name: '人员管理', component: Person }
    //   ]
    // },
    {
      path: '/',
      name: '行车资料',
      component: Home,
      iconCls: 'el-icon-menu',
      children: [
        { path: '/files', name: '文件管理', component: Files }
      ]
    },
    {
      path: '/',
      name: '指导司机',
      component: Home,
      iconCls: 'el-icon-menu',
      children: [
        {
          path: '/temptake',
          name: '工作记录',
          component: Take,
          iconCls: 'el-icon-menu',
          children: [
            { path: '/temptake', name: '添乘信息单', component: Take }
          ]
        }
      ]
    },
    {
      path: '/login',
      name: '登录',
      hidden: true,
      component: Login
    },
    {
      path: '/404',
      hidden: true,
      component: NotFound
    },
    {
      path: '/403',
      hidden: true,
      component: Forbidden
    },
    {
      path: '*',
      hidden: true,
      redirect: { path: '/404' }
    }
  ]
});
