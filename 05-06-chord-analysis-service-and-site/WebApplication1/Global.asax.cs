using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        private static int _totalSessionCount = 0;
        private static int _totalRequestCount = 0;

        protected void Application_Start(object sender, EventArgs e)
        {
            // Default MVC/WebForms infrastructure initialization
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize global counters
            _totalSessionCount = 0;
            _totalRequestCount = 0;

            Application["TotalSessionCount"] = _totalSessionCount;
            Application["TotalRequestCount"] = _totalRequestCount;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            _totalSessionCount++;
            Application["TotalSessionCount"] = _totalSessionCount;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            _totalRequestCount++;
            Application["TotalRequestCount"] = _totalRequestCount;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();
     
        }
    }
}
