using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Payanarvorkss.Payanar.Tabless.Api.Utilitiess;

namespace Payanarvorkss.Payanar.Tabless.Api.DtoModelss
{
    public interface IPayanarType
    {
        string ParentUniqueId { get; set; }
        string UniqueId { get; set; }
        string Name { get; set; }
        bool IsSystemType { get; set; }
    }
    public class PayanarType : IPayanarType
    {
        public string UniqueId { get; set; } = String.Empty;
        public string ParentUniqueId { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public bool IsSystemType { get; set; }
    }
    public interface IHierarchicalPayanarType : IPayanarType
    {
        IEnumerable<IHierarchicalPayanarType> Children { get; set; }
    }
    public class HierarchicalPayanarType : PayanarType, IHierarchicalPayanarType
    {
        public IEnumerable<IHierarchicalPayanarType> Children { get; set; }
    }
    public interface IHierarchicalPayanarTypeColumn : IPayanarType
    {
        bool IsPayanarTableDesign { get; set; }
        IEnumerable<HierarchicalPayanarTypeColumn> Children { get; set; }
    }
    public class HierarchicalPayanarTypeColumn : PayanarType, IHierarchicalPayanarTypeColumn
    {
        private static object _ogj = new object();
        public HierarchicalPayanarTypeColumn()
        {
        }
        public bool IsPayanarTableDesign { get; set; } = false;
        public PayanarTableDesign TableDesign { get; set; }
        private IEnumerable<HierarchicalPayanarTypeColumn> _children = null;
        public IEnumerable<HierarchicalPayanarTypeColumn> Children
        {
            get
            {
                lock (_ogj)
                {
                    if (_children == null)
                        _children = new List<HierarchicalPayanarTypeColumn>();
                }

                return _children;
            }
            set { _children = value; }
        }
    }
    public interface IPayanarTableDesign : IPayanarType
    {
        System.String OriginalName { get; set; }
        IEnumerable<IPayanarTableColumnDesign> Columns { get; set; }
    }
    public class PayanarTableDesign
    {
        ////public PayanarTableDesign()
        ////{
        ////    Columns = new List<PayanarTableColumnDesign>();
        ////}
        ///public System.String OriginalName { get; set; } = String.Empty;
        ///public IEnumerable<PayanarTableColumnDesign> Columns { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
    }
    public interface IPayanarTableColumnDesign : IPayanarType
    {
        System.String OriginalName { get; set; }
        System.String ReferencedPayanarTableDesignUniqueId { get; set; }
        System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; }
        System.String LeastPayanarTableDesignUniqueId { get; set; }
        System.String LeastPayanarTableColumnDesignUniqueId { get; set; }
    }
    public class PayanarTableColumnDesign : PayanarType, IPayanarTableColumnDesign
    {
        public System.String OriginalName { get; set; }
        public System.String ReferencedPayanarTableDesignUniqueId { get; set; } = String.Empty;
        public System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
        public System.String LeastPayanarTableDesignUniqueId { get; set; } = String.Empty;
        public System.String LeastPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
    }
    public class PayanarTable
    {
        ////public PayanarTableDesign TableDesign { get; set; }
        public string UniqueId { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public IEnumerable<PayanarTableRow> Rows { get; set; }
        public void AddRow(DataModelss.PayanarTableRow row)
        {
            (Rows as IList<DtoModelss.PayanarTableRow>).Add(new DtoModelss.PayanarTableRow(row.Cells) { UniqueId = row.UniqueId });
        }
    }
    public class PayanarTableRow
    {
        public PayanarTableRow() { }
        public PayanarTableRow(IDictionary<string, DataModelss.PayanarTableCell> cells)
        {
            AddCells(cells);
        }
        public string UniqueId { get; set; } = String.Empty;
        public IDictionary<string, PayanarTableCell> Cells { get; set; }
        private void AddCells(IDictionary<string, DataModelss.PayanarTableCell> cells)
        {
            cells?.ToList().ForEach(v =>
            {
                Cells.Add(v.Key, new DtoModelss.PayanarTableCell() { ColumnDesignUniqueId = v.Value.ColumnDesignUniqueId, Value = v.Value.Value });
            });
        }
    }
    public class PayanarTableCell
    {
        public string ColumnDesignUniqueId { get; set; }
        public string Value { get; set; }
    }
}
