using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using Payanarvorkss.Payanar.Tabless.Api.DataModelss;
using System.Text.Json;

namespace Payanarvorkss.Payanar.Tabless.Api.Controllerss
{
    [Route("vtree/api/[controller]")]
    [ApiController]
    public class HierarchicalPayanarTypeController : ControllerBase
    {
        [HttpPost]
        public async Task<HierarchicalPayanarTableDesign> Create([FromBody] HierarchicalPayanarTableDesign tableDesign)
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTableDesign>("HierarchicalPayanarTypess");
            ////var tableDesign = JsonSerializer.Deserialize<PayanarTableDesign>(json);
            await payanarTabless.InsertOneAsync(tableDesign);
            return tableDesign;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HierarchicalPayanarTableDesign>>> Read()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTableDesign>("HierarchicalPayanarTypess");
            var query = await payanarTabless.FindAsync(x => !string.IsNullOrEmpty(x.UniqueId));
            ////var totalTask = await query.CountAsync();
            ////var itemsTask = query.Skip(0).Limit(10).ToListAsync();
            ////await Task.WhenAll(totalTask, itemsTask);
            ////return new Page { Total = totalTask.Result, Items = itemsTask.Result };
            var result = query.ToList();
            return Ok(result);
        }
        [HttpPatch]
        public IEnumerable<HierarchicalPayanarTableDesign> Update()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTableDesign>("HierarchicalPayanarTypess");

            return null;
        }
        [HttpDelete]
        public IEnumerable<HierarchicalPayanarTableDesign> Delete()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTableDesign>("HierarchicalPayanarTypess");

            return null;
        }
    }
}
