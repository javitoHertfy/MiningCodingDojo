using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Javito.MiningCodingDojo.Domain;
using Javito.MiningCodingDojo.ServiceLibrary;
using Swashbuckle.Swagger.Annotations;

namespace Javito.MiningCodingDojo.WebApp.Controllers
{
    [RoutePrefix("v1/login")]
    public class LoginController : ApiController
    {
        private readonly MinerManagementAppService minerManagementAppService;

        public LoginController()
        {
            minerManagementAppService = new MinerManagementAppService();
        }

        /// <summary>
        /// Creates a miner on the system
        /// </summary>
        /// <param name="name">The name of the miner</param>
        [Route("CreateMiner/{name}")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void CreateMiner(string name)
        {
            this.minerManagementAppService.InsertMiner(name);
        }

        /// <summary>
        /// Log in a miner in the Mine
        /// </summary>
        /// <param name="name">The name of the miner</param>
        [Route("LoginMine/{name}")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public void LoginMine(string name)
        {
            this.minerManagementAppService.LoginMine(name);
        }

        /// <summary>
        /// Get all the miners in the system
        /// </summary>
        /// <returns></returns>
        [Route("GetMiners")]
        [HttpGet]
        public IEnumerable<string> GetMiners()
        {
            return this.minerManagementAppService.GetMiners().Select(x => x.Name);
        }

        /// <summary>
        /// Get the Miner details by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("GetMinerByName/{name}")]
        [HttpGet]
        public Miner GetMinerByName(string name)
        {
            return this.minerManagementAppService.GetMiners().FirstOrDefault(x=>x.Name == name);
        }
    }
}
