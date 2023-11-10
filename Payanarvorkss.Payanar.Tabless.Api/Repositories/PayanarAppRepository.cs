using Payanarvorkss.Payanar.Tabless.Api.DtoModelss;
using MongoDB.Driver;
using Payanarvorkss.Payanar.Tabless.Api.DataModelss;

namespace Payanarvorkss.Payanar.Tabless.Api.Repositories
{
    public class PayanarAppRepository
    {
        public async Task<PayanarResponse<IEnumerable<DataModelss.HierarchicalPayanarType>>> Start(PayanarApplicationContext context)
        {
            PayanarResponse<IEnumerable<DataModelss.HierarchicalPayanarType>> response = new PayanarResponse<IEnumerable<DataModelss.HierarchicalPayanarType>>();
            DataModelss.PayanarApplicationContext ctx = new DataModelss.PayanarApplicationContext();
            MongoClient client = null;
            try
            {
                client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
                var database = client.GetDatabase("PayanarApplications");
                var payanarTabless = database.GetCollection<DataModelss.PayanarApplicationContext>("PayanarApplications");
                if (!string.IsNullOrEmpty(context.ApplicationId))
                {
                    var query = await payanarTabless.FindAsync(x => !string.IsNullOrEmpty(x.ApplicationId) && x.ApplicationId.Equals(context.ApplicationId));
                    ctx = query.FirstOrDefault();
                }
                else if (!string.IsNullOrEmpty(context.EmailId))
                {
                    var query = await payanarTabless.FindAsync(x => !string.IsNullOrEmpty(x.ApplicationId) && x.EmailId.Equals(context.EmailId));
                    ctx = query.FirstOrDefault();
                }

                if (ctx == null)
                {
                    ctx = new DataModelss.PayanarApplicationContext();
                    ctx.ApplicationId = Guid.NewGuid().ToString();
                    ctx.EmailId = context.EmailId;
                    ctx.DatabaseName = ctx.ApplicationId.Replace("-", string.Empty);
                    ctx.RootParentId = "00000000-0000-0000-0000-000000000000";
                    await payanarTabless.InsertOneAsync(ctx);
                    context.DatabaseName = ctx.DatabaseName;
                }
                else
                {
                    context.ApplicationId = ctx.ApplicationId;
                    context.EmailId = ctx.EmailId;
                    context.DatabaseName = ctx.DatabaseName;
                    context.RootParentId = ctx.RootParentId;
                }

                response.IsSuccess = true;
                response.Data = await ReadHierarchicalPayanarType(context, client);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
            }
            return response;
        }

        private async Task<IEnumerable<DataModelss.HierarchicalPayanarType>> ReadHierarchicalPayanarType(PayanarApplicationContext context, MongoClient client)
        {
            IEnumerable<Task> tasks = new List<Task>();
            var database = client.GetDatabase(context.DatabaseName);
            var payanarTypess = database.GetCollection<DataModelss.HierarchicalPayanarType>("HierarchicalPayanarTypess");
            var query = await payanarTypess.FindAsync(x => !string.IsNullOrEmpty(x.ParentUniqueId) && x.ParentUniqueId.Equals(context.RootParentId));
            var hierarchicalTypess = query.ToList().OrderBy(x => x.Name).ToList();
            ReadHierarchicalPayanarType(tasks, payanarTypess, hierarchicalTypess);
            Task.WaitAll(tasks.ToArray());
            return hierarchicalTypess;
        }

        private async Task ReadHierarchicalPayanarType(IEnumerable<Task> tasks, IMongoCollection<DataModelss.HierarchicalPayanarType> mongoCollection, IEnumerable<DataModelss.HierarchicalPayanarType> hierarchicalPayanarTypes)
        {
            if (hierarchicalPayanarTypes != null)
            {
                foreach (var item in hierarchicalPayanarTypes)
                {
                    (tasks as IList<Task>).Add(ReadHierarchicalPayanarType(tasks, mongoCollection, item, item.UniqueId));
                }
            }
        }

        private async Task ReadHierarchicalPayanarType(IEnumerable<Task> tasks, IMongoCollection<DataModelss.HierarchicalPayanarType> mongoCollection, DataModelss.HierarchicalPayanarType hierarchicalPayanarType, string parentId)
        {
            var query = await mongoCollection.FindAsync(x => !string.IsNullOrEmpty(x.ParentUniqueId) && x.ParentUniqueId.Equals(parentId));
            var hierarchicalTypess = query.ToList().OrderBy(x => x.Name).ToList();
            if (hierarchicalTypess != null && hierarchicalTypess.Count > 0)
            {
                hierarchicalPayanarType.Children = new List<DataModelss.HierarchicalPayanarType>();
                (hierarchicalPayanarType.Children as List<DataModelss.HierarchicalPayanarType>).AddRange(hierarchicalTypess);
                ReadHierarchicalPayanarType(tasks, mongoCollection, hierarchicalTypess);
            }
        }
    }
}
