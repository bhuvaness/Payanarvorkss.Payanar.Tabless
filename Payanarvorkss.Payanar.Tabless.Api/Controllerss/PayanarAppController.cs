using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payanarvorkss.Payanar.Tabless.Api.Business;
using Payanarvorkss.Payanar.Tabless.Api.DataModelss;
using Payanarvorkss.Payanar.Tabless.Api.DtoModelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payanarvorkss.Payanar.Tabless.Api.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayanarAppController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Start([FromBody] PayanarApplicationContext context)
        {
            PayanarAppBusiness business = new PayanarAppBusiness();
            return Ok(await business.Start(context));
        }
    }
}
