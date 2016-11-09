using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.dfyw.entity;

namespace com.dfyw.web.Global
{
    public class LoginManager
    {
        public static void SetCurrentUser(Member member)
        {
            HttpContext.Current.Session["CurrentUser"] = member ?? null;
        }

        public static Member GetCurrentUser()
        {
            return (Member)HttpContext.Current.Session["CurrentUser"] ?? null;
        }

        public static void Clean()
        {
            HttpContext.Current.Session["CurrentUser"] = null;
        }

    }
}