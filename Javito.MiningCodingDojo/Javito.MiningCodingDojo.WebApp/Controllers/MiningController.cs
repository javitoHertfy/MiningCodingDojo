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
    [RoutePrefix("v1/Mining")]
    public class MiningController : ApiController
    {
        private readonly MineAppService mineAppService;
        private readonly MinerManagementAppService minerManagementAppService;

        public MiningController()
        {
            minerManagementAppService = new MinerManagementAppService();
            mineAppService = new MineAppService();
        }
        /// <summary>
        /// Gets a piece of gold from the miner given the minerId
        /// </summary>
        /// <param name="minerId"></param>
        /// <returns></returns>
        [Route("CollectGold/{minerId}")]        
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public int CollectGold(Guid minerId)
        {
            
            return mineAppService.CollectGold(minerId);
        }

        /// <summary>
        /// Save gold in your pocket
        /// </summary>
        /// <param name="minerId">The id of the miner</param>
        /// <param name="goldQuantity">The amount of gold</param>
        [Route("SaveGold/{minerId}/{goldQuantity}")]        
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public void SaveGold(Guid minerId, int goldQuantity)
        {
            mineAppService.SaveGold(minerId, goldQuantity);
        }
    }
}
