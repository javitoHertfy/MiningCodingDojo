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
    public class MiningController : ApiController
    {
        private readonly MineAppService mineAppService;
        private readonly MinerManagementAppService minerManagementAppService;

        public MiningController()
        {
            minerManagementAppService = new MinerManagementAppService();
            mineAppService = new MineAppService();
        }

        [Route("CollectGold")]
        [SwaggerOperation("CollectGold")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public int CollectGold(Guid minerId)
        {
            return 1;
        }

        [Route("SaveGold")]
        [SwaggerOperation("SaveGold")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPut]
        public void SaveGold(Guid minerId, int goldQuantity)
        {

        }
    }
}
