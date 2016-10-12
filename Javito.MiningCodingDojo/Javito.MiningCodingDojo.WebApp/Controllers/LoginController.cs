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
            this.minerManagementAppService = new MinerManagementAppService();
        }

        // POST api/values
        [SwaggerOperation("CreateMiner")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void CreateMiner([FromBody]string name)
        {

        }

        // POST api/values
        [SwaggerOperation("LoginMine")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public void LoginMine([FromBody]string name)
        {

        }

        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
