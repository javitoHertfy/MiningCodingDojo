using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Javito.MiningCodingDojo.ServiceLibrary;

namespace Javito.MiningCodingDojo.WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly MinerManagementAppService minerManagementAppService;

        public WebApiApplication()
        {
            minerManagementAppService = new MinerManagementAppService();
        }

        protected void Application_Start()
        {
            Timer randomlogOutTimer;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            randomlogOutTimer = new Timer();
            randomlogOutTimer.Elapsed += new ElapsedEventHandler(randomlogOutTimer_Tick);
            randomlogOutTimer.Interval = 120000; // in miliseconds
            randomlogOutTimer.Start();
        }

        private void randomlogOutTimer_Tick(object sender, EventArgs e)
        {
            int count = minerManagementAppService.GetMinersLogged().Count;          
            if (count > 0)
            {
                Random random = new Random();
                int number = random.Next(0, count - 1);
                string name = minerManagementAppService.GetMinersLogged()[number].Name;
                minerManagementAppService.LogoutMine(name);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string urlReferred = Request.UrlReferrer != null ? Request.UrlReferrer.AbsolutePath : "";
            string path = Request.FilePath;
            if (urlReferred.Contains("swagger") && !path.Contains("swagger") && !path.Contains("GetResults") && !path.Contains("GetGoldLeft"))
            {
                throw new Exception("Swagger is a tool for documentation do not use it to win the tournament");
            }            
        }
    }
}
