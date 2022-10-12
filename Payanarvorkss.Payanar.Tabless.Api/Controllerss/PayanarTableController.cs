using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using Payanarvorkss.Payanar.Tabless.Api.Business;
using Payanarvorkss.Payanar.Tabless.Api.DtoModelss;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace Payanarvorkss.Payanar.Tabless.Api.Controllerss
{
    [Route("vtree/api/[controller]")]
    [ApiController]
    public class PayanarTableController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<PayanarTable>> Create([FromBody] PayanarTable table)
        {
            PayanarTableBusiness business = new PayanarTableBusiness();
            await business.Create(table);
            return Ok(table);
        }
        [HttpPost("read")]
        public async Task<ActionResult<PayanarTable>> Read([FromBody] DtoModelss.PayanarTableDesign tableDesign)
        {
            PayanarTableBusiness business = new PayanarTableBusiness();
            DtoModelss.PayanarTable table = null;//// await business.Read(tableDesign);
            return Ok(table);
        }
        /*
        [HttpPatch]
        public async Task<PayanarTableDesign> Update()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<PayanarTableDesign>("PayanarTableDesignss");

            return null;
        }
        [HttpDelete]
        public async Task<PayanarTableDesign> Delete()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<PayanarTableDesign>("PayanarTableDesignss");

            return null;
        }
        */
    }
}
