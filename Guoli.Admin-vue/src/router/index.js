import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'
import NotFound from '@/views/NotFound'
import Forbidden from '@/views/Forbidden'
import Files from '@/views/Files'
import Login from '@/views/Login'
import Take from '@/views/instructor/Take'
import TakePrev from '@/views/instructor/TakePrev'
import AnalysisPrev from '@/views/instructor/AnalysisPrev'
import ViewInstructorAnalysis from '@/views/instructor/ViewInstructorAnalysis'

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
          name: '日常工作记录',
          component: ViewInstructorAnalysis,
          iconCls: 'el-icon-menu',
          children: [
            { path: '/temptake', name: '添乘信息单', component: Take },
            { path: '/analysis', name: '监控分析单', component: ViewInstructorAnalysis },
          ]
        }
      ]
    },
    { path: '/temptake-prev', name: '添乘信息单打印预览', component: TakePrev, hidden:true },
    { path: '/analysis-prev', name: '监控分析单打印预览', component: AnalysisPrev, hidden:true },
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
