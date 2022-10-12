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
    public class PayanarTableDesign : PayanarType
    {
        public PayanarTableDesign()
        {
            Columns = new List<PayanarTableColumnDesign>();
        }
        public System.String OriginalName { get; set; } = String.Empty;
        public IEnumerable<PayanarTableColumnDesign> Columns { get; set; }
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
    public class PayanarTable : PayanarType
    {
        public PayanarTable()
        {
            DataTable = new DataModelss.PayanarTable();
        }
        private DataModelss.PayanarTable DataTable { get; set; }
        ////public PayanarTableDesign TableDesign { get; set; }
        ////public IEnumerable<PayanarTableRow> Rows { get; set; }
        private IEnumerable<PayanarTableRow> _rows = null;
        public IEnumerable<PayanarTableRow> Rows
        {
            get
            {
                if (_rows == null && DataTable.Rows != null)
                {
                    DataTable.Rows.ToList().ForEach(v => { });
                }
                return _rows;
            }
            set
            {
                _rows = value;
                if (_rows != null)
                {
                    _rows.ToList().ForEach(v => { DataTable.AddRow(v); });
                }
            }
        }
        public DataModelss.PayanarTable GetDataTable() { return DataTable; }
    }
    public class PayanarTableRow : PayanarType
    {
        private DataModelss.PayanarTableRow DataRow { get; set; }
        public IDictionary<string, PayanarTableCell> Cells { get; set; }
    }
    public class PayanarTableCell
    {
        public PayanarTableCell()
        {
            DataCell = new DataModelss.PayanarTableCell();
        }
        private DataModelss.PayanarTableCell DataCell { get; set; }
        public string ColumnDesignUniqueId { get; set; }
        public string Value { get; set; }
    }
}
