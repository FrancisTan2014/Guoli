import axios from 'axios';
import local from './local';

// let base = 'http://localhost:8002';
let base = 'http://192.168.0.110:8002';
// let base = 'http://localhost:56147';

/**
 * 在向服务器发送请求前对接口url进行处理
 * 可在此拼接向需要额外向服务器发送的数据
 *
 * @param {String} path 请求接口的相对地址
 */
let apiUrlHandler = path => {
  let extra = {
    async: true,
    token: local.getItem('token')
  };

  let url = `${base}${path}?`;
  let params = [];
  for (let key in extra) {
    params.push(`${key}=${extra[key]}`);
  }

  return url + params.join('&');
};

/**
 * 检查服务器返回的数据
 * 若返回的code为104
 * 则提示用户需要登录
 * 同时跳转到登录页面
 *
 * @param {Object} data 服务器返回的数据
 * @param {Vue} $vue 调用接口的Vue组件对象
 */
let loginFilter = (data, $vue) => {
  let { code } = data;
  if (code && code === 104) {
    $vue.$message({
      title: '提示',
      message: '未登录或者登录已失效，请先登录(:=',
      type: 'error',
      duration: 3500,
      onClose: () => {
        console.info($vue);
        $vue.$router.push({path: '/login', params: { back: $vue.$route.path }});
      }
    });

    throw new Error('中断后续代码的执行！！！');
  }
};

/**
 * 针对特殊的业务逻辑（如登录失效检查）
 * 检查服务器返回的数据
 *
 * @param {Object} data 服务器返回的数据
 * @param {Vue} $vue 调用接口的Vue组件对象
 */
let filters = (data, $vue) => {
  loginFilter(data, $vue);
  return data;
};

export default {
  base,

  /**
   * 以post请求的方式从指定接口获取数据
   *
   * @param {String} path 接口相对地址
   * @param {Object} params 调用接口所需要的参数
   * @param {Vue} $vue 调用接口的Vue组件对象
   * @param {Object} config axios配置信息
   */
  post: (path, params, $vue, config) => axios.post(apiUrlHandler(path), params, config || {})
    .then(res => filters(res.data, $vue))
    .then(res => res)
    .catch(err => console.info(err))
};
