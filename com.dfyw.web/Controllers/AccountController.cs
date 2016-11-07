using com.dfyw.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            Global.JsonResult js = new Global.JsonResult();
            if (model == null)
            {
                js.Result = "提交的数据为空，登陆失败";

                return Json(js,JsonRequestBehavior.AllowGet);
            }



            return View();
        }

    }
}