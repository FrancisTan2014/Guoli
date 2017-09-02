import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'
import NotFound from '@/views/NotFound'
import Forbidden from '@/views/Forbidden'
import Files from '@/views/Files'
import Login from '@/views/Login'

// 部门人员
import ViewDepartInfo from '@/views/personnel/ViewDepartInfo'
import Posts from '@/views/personnel/Posts'
import ViewPersonInfo from '@/views/personnel/ViewPersonInfo'

// 指导司机
import Take from '@/views/instructor/Take'
import ViewInstructorAnalysis from '@/views/instructor/ViewInstructorAnalysis'
import ViewInstructorCheck from '@/views/instructor/ViewInstructorCheck'
import ViewInstructorRepair from '@/views/instructor/ViewInstructorRepair'
import ViewInstructorKeyPerson from '@/views/instructor/ViewInstructorKeyPerson'
import ViewInstructorLocoQuality from '@/views/instructor/ViewInstructorLocoQuality'
import ViewInstructorGoodJob from '@/views/instructor/ViewInstructorGoodJob'
import ViewInstructorPeccancy from '@/views/instructor/ViewInstructorPeccancy'
import ViewInstructorTeach from '@/views/instructor/ViewInstructorTeach'
import ViewInstructorPlan from '@/views/instructor/ViewInstructorPlan'
import ViewInstructorAccept from '@/views/instructor/ViewInstructorAccept'

// 指导司机工作记录预览
import TakePrev from '@/views/instructor/preview/TakePrev'
import AnalysisPrev from '@/views/instructor/preview/AnalysisPrev'
import KeyPersonPrev from '@/views/instructor/preview/KeyPersonPrev'
import PeccanyPrev from '@/views/instructor/preview/PeccanyPrev'
import GooPrev from '@/views/instructor/preview/GooPrev'
import QualityPrev from '@/views/instructor/preview/QualityPrev'


// 司机手账
import ViewDriveRecord from '@/views/driver/ViewDriveRecord'

// 考试管理
import ViewExamNotify from '@/views/exam/ViewExamNotify'
import ViewExamRecords from '@/views/exam/ViewExamRecords'
import ViewExamFiles from '@/views/exam/ViewExamFiles'

// 通知公告
import Announcement from '@/views/notify/Announcement'

// 系统设置
import SystemUser from '@/views/system/SystemUser'
import ViewOperateLog from '@/views/system/ViewOperateLog'
import AppUpdate from '@/views/system/AppUpdate'
import InstructorRouterPosition from '@/views/system/InstructorRouterPosition'
import MobileDevice from '@/views/system/MobileDevice'

Vue.use(Router)

export default new Router({
  // 不配置此项的url像这样：http://localhost:18082/#/login
  // 配置之后像这样：http://localhost:18082/login
  // mode: 'history',
  routes: [
    { path: '/', name: 'home', desc: '首页', component: Home },
    {
      path: '/',
      name: 'personnel',
      desc: '部门人员',
      component: Home,
      children: [
        { path: '/depart', name: 'depart', desc: '部门管理', component: ViewDepartInfo },
        { path: '/post', name: 'post', desc: '职务管理', component: Posts },
        { path: '/staff', name: 'staff', desc: '员工管理', component: ViewPersonInfo },
      ]
    },
    {
      path: '/',
      name: 'resources',
      desc: '行车资料',
      component: Home,
      children: [
        { path: '/files', name: 'files', desc: '文件管理', component: Files }
      ]
    },
    {
      path: '/',
      name: 'instructor',
      desc: '指导司机',
      component: Home,
      children: [
        { path: '/temptake', name: 'temptake', desc: '添乘信息单', component: Take },
        { path: '/temptake-prev', name: 'temptake-prev', desc: '添乘信息单打印预览', component: TakePrev, hidden: true },

        { path: '/analysis', name: 'analysis', desc: '监控分析单', component: ViewInstructorAnalysis },
        { path: '/analysis-prev', name: 'analysis-prev', desc: '监控分析单打印预览', component: AnalysisPrev, hidden: true },

        { path: '/check', name: 'check', desc: '抽查信息单', component: ViewInstructorCheck },

        { path: '/repair', name: 'repair', desc: '机破临修记录', component: ViewInstructorRepair },

        { path: '/keyperson', name: 'keyperson', desc: '关键人管理', component: ViewInstructorKeyPerson },
        { path: '/keyperson-prev', name: 'keyperson-prev', desc: '关键人管理打印预览', component: KeyPersonPrev, hidder: true },

        { path: '/quality', name: 'quality', desc: '机车质量登记', component: ViewInstructorLocoQuality },
        { path: '/quality-prev', name: 'quality-prev', desc: '违章违纪记录打印预览', component: QualityPrev, hidder: true },

        { path: '/good', name: 'good', desc: '防止事故及好人好事记录', component: ViewInstructorGoodJob },
        { path: '/good-prev', name: 'good-prev', desc: '防止事故及好人好事记录打印预览', component: GooPrev, hidder: true },

        { path: '/peccany', name: 'peccany', desc: '违章违纪记录', component: ViewInstructorPeccancy },
        { path: '/peccany-prev', name: 'peccany-prev', desc: '违章违纪记录打印预览', component: PeccanyPrev, hidder: true },

        { path: '/teach', name: 'teach', desc: '授课培训记录', component: ViewInstructorTeach },

        { path: '/plan', name: 'plan', desc: '工作总结计划', component: ViewInstructorPlan },

        { path: '/accept', name: 'accept', desc: '标准化验收', component: ViewInstructorAccept },
      ]
    },
    {
      path: '/',
      name: 'driver',
      desc: '司机手账',
      component: Home,
      children: [
        { path: '/drive', name: 'drive', desc: '司机报单', component: ViewDriveRecord },
      ]
    },
    {
      path: '/',
      name: 'exammanagement',
      desc: '考试管理',
      component: Home,
      children: [
        { path: '/examlib', name: 'examlib', desc: '题库管理', component: ViewExamFiles },
        { path: '/examnotify', name: 'examnotify', desc: '考试通知', component: ViewExamNotify },
        { path: '/examresult', name: 'examresult', desc: '考试结果', component: ViewExamRecords },
      ]
    },
    {
      path: '/',
      name: 'notifymanagement',
      desc: '通知公告',
      component: Home,
      children: [
        { path: '/announce', name: 'announce', desc: '公告管理', component: Announcement }
      ]
    },
    {
      path: '/',
      name: 'system',
      desc: '系统',
      component: Home,
      children: [
        { path: '/account', name: 'account', desc: '账户管理', component: SystemUser },
        { path: '/log', name: 'log', desc: '操作日志', component: ViewOperateLog },
        { path: '/router', name: 'router', desc: '路由器管理', component: InstructorRouterPosition },
        { path: '/device', name: 'device', desc: '移动设备管理', component: MobileDevice },
        { path: '/app', name: 'app', desc: 'app更新', component: AppUpdate }
      ]
    },
    {
      path: '/login',
      name: 'login',
      desc: '登录',
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
