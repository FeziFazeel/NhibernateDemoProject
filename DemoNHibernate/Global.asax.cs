using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DemoNHibernate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static public ISessionFactory SF = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SF = SessionFactory.GetSF();

        }

        public override void Init()
        {
            base.Init();
            //just write this.BeginRequest += and press "Tab button" one times

            this.BeginRequest += MvcApplication_BeginRequest;
            //just write this.EndRequest += and press "Tab button" one times
            this.EndRequest += MvcApplication_EndRequest;


        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            /*
      Take session back from request
      dispose/close that session
        */

            ISession S = CurrentSessionContext.Unbind(SF);
            S.Dispose();

        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            //Bind session when request initiate
            CurrentSessionContext.Bind(SF.OpenSession());
        }
    }
}
