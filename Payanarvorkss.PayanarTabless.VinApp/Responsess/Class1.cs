using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Modelss;

namespace WinFormsApp1.Responsess
{
    public class GetHierarchicalPayanarTypeColumnssResponse
    {
        public IEnumerable<HierarchicalPayanarTypeColumn> HierarchicalPayanarTypeColumnss { get; set; }
        public IEnumerable<PayanarTableDesign> TableDesignss { get; set; }
    }
}
