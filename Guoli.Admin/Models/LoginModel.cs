

using System.ComponentModel.DataAnnotations;

namespace Guoli.Admin.Models
{
    /// <summary>
    /// 登录表单实体
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-14</since>
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [StringLength(16)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        /// <summary>
        /// 七天免登录开关
        /// </summary>
        public string Switch { get; set; }

        /// <summary>
        /// 标识是否需要记住密码
        /// </summary>
        public bool Remember => null != Switch && Switch.ToLower() == "on";
    }
}