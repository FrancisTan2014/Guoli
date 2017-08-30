/**
 * 获取element-ui中自定义的表单验证规则
 * @param {RegExp|String} pattern 正则表达式对象或者字符串
 * @param {String} emptyMsg 当表单元素的值为空时显示的提示信息
 * @param {String} failedMsg 当自定义规则验证失败时显示的提示信息
 */
export default function (pattern, emptyMsg, failedMsg) {
  return (rule, value, callback) => {
    if (!value) {
      callback(new Error(emptyMsg));
    } else {
      let regex = (pattern instanceof RegExp) ? pattern : new RegExp(pattern);
      if (!regex.test(value)) {
        callback(new Error(failedMsg));
      } else {
        callback();
      }
    }
  };
};
