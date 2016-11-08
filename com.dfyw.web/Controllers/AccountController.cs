using com.dfyw.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.dfyw.web.Global;
using com.dfyw.Ibll;
using com.dfyw.entity;
using com.dfyw.common;

namespace com.dfyw.web.Controllers
{
    public class AccountController:Controller
    {
        private IMemberBLL _memberBLL;
        public AccountController(IMemberBLL memberBLL)
        {
            _memberBLL = memberBLL;
        }
 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            AjaxResult result = new Global.AjaxResult();
            
            if (model == null)
            {
                result.state = ResultType.error.ToString();
                result.message = "提交的数据为空，登陆失败";

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            Member member = new Member();
            var state = _memberBLL.Login(model.Account, model.Password, ref member);

            if (state == LoginState.empty)
            {
                result.state = ResultType.error.ToString();
                result.message = "提交的数据为空，登陆失败";
            }
            else if (state == LoginState.account_error)
            {
                result.state = ResultType.error.ToString();
                result.message = "提交的账号不存在，登陆失败";
            }
            else if (state == LoginState.password_error)
            {
                result.state = ResultType.error.ToString();
                result.message = "密码错误，登陆失败";
            }
            else if (state == LoginState.failed)
            {
                result.state = ResultType.error.ToString();
                result.message = "系统错误，登陆失败";
            }
            else if(state == LoginState.success)
            {
                result.state = ResultType.success.ToString();
                result.message = "登陆成功";

                if (member.Role == 0)
                {
                    result.data = "/Admin/Index";
                }
                else if (member.Role == 1)
                {
                    result.data = "/TeamLeader/Index";
                }
                else
                {
                    result.data = "/Member/Index";
                }

                LogHelper.writeLog_info("账号" + member.Account + "于" + DateTime.Now.ToString() + "登陆成功。");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result.state = ResultType.error.ToString();
                result.message = "系统错误，登陆失败";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}