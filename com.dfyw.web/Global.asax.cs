using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using com.dfyw.entity;
using com.dfyw.Idal;
using com.dfyw.Ibll;
using com.dfyw.bll;
using com.dfyw.dal;
using com.dfyw.web.Global;

namespace com.dfyw.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Configs/log4net.config")));
            RolesManager.LoadXmlConfig(Server.MapPath("~/Configs/roles.config"));
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<MemberDAL>().As<IMemberDAL>();
            builder.RegisterType<MemberBLL>().As<IMemberBLL>();
        }
    }
}
