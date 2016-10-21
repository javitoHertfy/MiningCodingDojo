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
        public IHttpActionResult CreateMiner(string name)
        {
            try
            {
                this.minerManagementAppService.InsertMiner(name);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Log in a miner in the Mine
        /// </summary>
        /// <param name="name">The name of the miner</param>
        [Route("LoginMine/{name}")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public IHttpActionResult LoginMine(string name)
        {
            try
            {
                this.minerManagementAppService.LoginMine(name);
                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
       
        }

        /// <summary>
        /// Get all the miners in the system
        /// </summary>
        /// <returns></returns>
        [Route("GetMiners")]
        [HttpGet]
        public IEnumerable<string> GetMiners()
        {
            return this.minerManagementAppService.GetMinersLogged().Select(x => x.Name);
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
            return this.minerManagementAppService.GetMinersLogged().FirstOrDefault(x => x.Name == name);
        }
    }
}
