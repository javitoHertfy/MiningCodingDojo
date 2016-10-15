using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Javito.MiningCodingDojo.ServiceLibrary;
using Swashbuckle.Swagger.Annotations;

namespace Javito.MiningCodingDojo.WebApp.Controllers
{
    public class LoginController : ApiController
    {
        private readonly MinerManagementAppService minerManagementAppService;

        public LoginController()
        {
            minerManagementAppService = new MinerManagementAppService();
        }

        // POST api/values
        [SwaggerOperation("CreateMiner")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void CreateMiner(string name)
        {
            this.minerManagementAppService.InsertMiner(name);
        }

        // POST api/values
        [SwaggerOperation("LoginMine")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public void LoginMine(string name)
        {
            this.minerManagementAppService.LoginMine(name);
        }

        // GET api/values
        [SwaggerOperation("GetAllMiners")]
        public IEnumerable<string> GetMiners()
        {
            return this.minerManagementAppService.GetMiners().Select(x=>x.Name);
        }
    }
}
