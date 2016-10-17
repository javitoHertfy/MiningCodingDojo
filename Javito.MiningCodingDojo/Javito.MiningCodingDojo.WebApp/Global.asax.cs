using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Javito.MiningCodingDojo.WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Timer randomlogOutTimer;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            randomlogOutTimer = new Timer();
            randomlogOutTimer.Elapsed += new ElapsedEventHandler(randomlogOutTimer_Tick);
            randomlogOutTimer.Interval = 10000; // in miliseconds
            randomlogOutTimer.Start();
        }

        private void randomlogOutTimer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
