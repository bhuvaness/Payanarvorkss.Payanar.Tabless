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
        public async Task<HierarchicalPayanarTypeDesign> Create([FromBody] HierarchicalPayanarTypeDesign tableDesign)
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTypeDesign>("HierarchicalPayanarTypess");
            ////var tableDesign = JsonSerializer.Deserialize<PayanarTableDesign>(json);
            await payanarTabless.InsertOneAsync(tableDesign);
            return tableDesign;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<HierarchicalPayanarTypeColumnDesign>>> Read(string id)
        {
            IEnumerable<HierarchicalPayanarTypeColumnDesign> results = new List<HierarchicalPayanarTypeColumnDesign>();
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTypess = database.GetCollection<HierarchicalPayanarTypeDesign>("HierarchicalPayanarTypess");
            var payanarTableDesignss = database.GetCollection<PayanarTableDesign>("PayanarTableDesignss");
            var query = await payanarTypess.FindAsync(x => x.ParentUniqueId.Equals(id));
            var query2 = await payanarTableDesignss.FindAsync(x => x.ParentUniqueId.Equals(id));

            var hierarchicalTypess = query.ToList();
            var tableDesignss = query2.ToList();

            hierarchicalTypess?.ForEach(x =>
            {
                (results as IList<HierarchicalPayanarTypeColumnDesign>).Add(new HierarchicalPayanarTypeColumnDesign() { UniqueId = x.UniqueId, ParentUniqueId = x.ParentUniqueId, Name = x.Name, IsPayanarTableDesign = false });
            });

            tableDesignss?.ForEach(x =>
            {
                (results as IList<HierarchicalPayanarTypeColumnDesign>).Add(new HierarchicalPayanarTypeColumnDesign() { UniqueId = x.UniqueId, ParentUniqueId = x.ParentUniqueId, Name = x.Name, IsPayanarTableDesign = true });
            });

            return Ok(results);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HierarchicalPayanarTypeColumnDesign>>> Read()
        {
            IEnumerable<HierarchicalPayanarTypeColumnDesign> results = new List<HierarchicalPayanarTypeColumnDesign>();
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTypess = database.GetCollection<HierarchicalPayanarTypeDesign>("HierarchicalPayanarTypess");
            var payanarTableDesignss = database.GetCollection<PayanarTableDesign>("PayanarTableDesignss");
            var query = await payanarTypess.FindAsync(x => !string.IsNullOrEmpty(x.UniqueId));
            var query2 = await payanarTableDesignss.FindAsync(x => !string.IsNullOrEmpty(x.UniqueId));

            var hierarchicalTypess = query.ToList();
            var tableDesignss = query2.ToList();

            hierarchicalTypess?.ForEach(x =>
            {
                (results as IList<HierarchicalPayanarTypeColumnDesign>).Add(new HierarchicalPayanarTypeColumnDesign() { UniqueId = x.UniqueId, ParentUniqueId = x.ParentUniqueId, Name = x.Name, IsPayanarTableDesign = false });
            });

            tableDesignss?.ForEach(x =>
            {
                (results as IList<HierarchicalPayanarTypeColumnDesign>).Add(new HierarchicalPayanarTypeColumnDesign() { UniqueId = x.UniqueId, ParentUniqueId = x.ParentUniqueId, Name = x.Name, IsPayanarTableDesign = true });
            });

            return Ok(results);
        }
        [HttpPatch]
        public IEnumerable<HierarchicalPayanarTypeDesign> Update()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTypeDesign>("HierarchicalPayanarTypess");

            return null;
        }
        [HttpDelete]
        public IEnumerable<HierarchicalPayanarTypeDesign> Delete()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTabless = database.GetCollection<HierarchicalPayanarTypeDesign>("HierarchicalPayanarTypess");

            return null;
        }
    }
}
