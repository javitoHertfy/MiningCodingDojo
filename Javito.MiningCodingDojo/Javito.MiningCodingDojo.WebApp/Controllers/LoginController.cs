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
    public class LoginController : ApiController
    {
        private readonly MinerManagementAppService minerManagementAppService;

        public LoginController()
        {
            minerManagementAppService = new MinerManagementAppService();
        }      
        
        [SwaggerOperation("CreateMiner")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void CreateMiner(string name)
        {
            this.minerManagementAppService.InsertMiner(name);
        }
        
        
        [SwaggerOperation("LoginMine")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public void LoginMine(string name)
        {
            this.minerManagementAppService.LoginMine(name);
        }
       
        //[SwaggerOperation("GetMiners")]
        //public IEnumerable<string> GetMiners()
        //{
        //    return this.minerManagementAppService.GetMiners().Select(x => x.Name);
        //}
        
        [SwaggerOperation("GetMinerByName")]
        [HttpGet]
        public Miner GetMinerByName(string name)
        {
            return this.minerManagementAppService.GetMiners().FirstOrDefault(x=>x.Name == name);
        }
    }
}
