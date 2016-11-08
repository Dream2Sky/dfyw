using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dfyw.common
{
    /// <summary>
    /// 登陆状态
    /// </summary>
    public enum LoginState
    {
        /// <summary>
        /// 账号为空
        /// </summary>
        empty,
        /// <summary>
        /// 登陆成功
        /// </summary>
        success,
        /// <summary>
        /// 不存在的账号
        /// </summary>
        account_error,
        /// <summary>
        /// 密码错误
        /// </summary>
        password_error,
        /// <summary>
        /// 登陆失败
        /// </summary>
        failed
    }
}
