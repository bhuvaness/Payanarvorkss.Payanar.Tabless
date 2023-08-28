using Payanarvorkss.Payanar.Tabless.Api.DataModelss;
using Payanarvorkss.Payanar.Tabless.Api.DtoModelss;
using Payanarvorkss.Payanar.Tabless.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payanarvorkss.Payanar.Tabless.Api.Business
{
    public class PayanarAppBusiness
    {
        public async Task<PayanarResponse<IEnumerable<DataModelss.HierarchicalPayanarType>>> Start(PayanarApplicationContext context)
        {
            PayanarAppRepository repository = new PayanarAppRepository();
            return await repository.Start(context);
        }
    }
}
