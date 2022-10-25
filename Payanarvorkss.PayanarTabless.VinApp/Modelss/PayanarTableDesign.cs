using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Utilitiess;

namespace WinFormsApp1.Modelss
{
    public class PayanarApplication
    {
        private static PayanarApplication _instance = null;
        public static PayanarApplication Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PayanarApplication();

                return _instance;
            }
        }
        private IEnumerable<PayanarTableDesign> _tableDesigns = null;
        public IEnumerable<PayanarTableDesign> TableDesigns
        {
            get
            {
                ////if (_tableDesigns == null)
                ////{

                ////}
                return _tableDesigns;
            }
            set
            {
                _tableDesigns = value;

                IList<PayanarTypeSelection> selections = new List<PayanarTypeSelection>();

                _tableDesigns.ToList().ForEach(x =>
                {
                    x.Columns.ToList().ForEach(y =>
                    {
                        y.Parent = x;
                        selections.Add(new PayanarTypeSelection(x, y));
                    });
                });
                TypeSelections = selections;
            }
        }
        public IEnumerable<PayanarTypeSelection> TypeSelections
        {
            get; private set;
        }
    }
    public interface IPayanarType
    {
        string UniqueId { get; set; }
        string ParentUniqueId { get; set; }
        string Name { get; set; }
        bool IsSystemType { get; set; }
        string FullName { get; }
        IPayanarType Parent { get; set; }
    }
    public class PayanarType : IPayanarType
    {
        public string UniqueId { get; set; } = String.Empty;
        public string ParentUniqueId { get; set; } = String.Empty;
        public virtual string Name { get; set; } = String.Empty;
        public bool IsSystemType { get; set; }
        [JsonIgnore]
        public virtual string FullName { get { return Parent != null ? $"{Parent.FullName}.{Name}" : Name; } }
        private IPayanarType _parent = null;
        [JsonIgnore]
        public IPayanarType Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                ParentUniqueId = value?.UniqueId;
            }
        }
    }
    public interface IHierarchicalPayanarType : IPayanarType
    {
        IEnumerable<HierarchicalPayanarTypeColumn> Columns { get; set; }
    }
    public class HierarchicalPayanarType : PayanarType, IHierarchicalPayanarType
    {
        public HierarchicalPayanarType()
        {
            Columns = new List<HierarchicalPayanarTypeColumn>();
        }
        public IEnumerable<HierarchicalPayanarTypeColumn> Columns { get; set; }
    }
    public interface IHierarchicalPayanarTypeColumn : IPayanarType
    {
        bool IsPayanarTableDesign { get; set; }
        PayanarTableDesign TableDesign { get; set; }
        IEnumerable<HierarchicalPayanarTypeColumn> Children { get; set; }
    }
    public class HierarchicalPayanarTypeColumn : PayanarType, IHierarchicalPayanarTypeColumn
    {
        public bool IsPayanarTableDesign { get; set; }
        public PayanarTableDesign TableDesign { get; set; }
        public IEnumerable<HierarchicalPayanarTypeColumn> Children { get; set; }
    }
    public interface IPayanarTableDesign : IPayanarType
    {
        System.String OriginalName { get; set; }
        IEnumerable<PayanarTableColumnDesign> Columns { get; set; }
    }
    public class PayanarTableDesign : PayanarType, IPayanarTableDesign
    {
        public PayanarTableDesign()
        {
            Columns = new List<PayanarTableColumnDesign>();
        }
        public PayanarTableDesign(string uniqueId, IPayanarType parent, bool addDefaultColumn)
        {
            UniqueId = uniqueId;
            Parent = parent;
            Columns = new List<PayanarTableColumnDesign>();
            if (addDefaultColumn)
                AddColumn();
        }
        private System.String _originalName = String.Empty;
        public System.String OriginalName
        {
            get { return _originalName; }
            set
            {
                _originalName = value;
                base.Name = _originalName;
            }
        }
        public IEnumerable<PayanarTableColumnDesign> Columns { get; set; }
        public void AddColumn()
        {
            (Columns as IList<PayanarTableColumnDesign>).Add(new PayanarTableColumnDesign(Utility.NewUniqueId, this));
        }
    }
    public interface IPayanarTableColumnDesign : IPayanarType
    {
        System.String OriginalName { get; set; }
        System.String ColumnType { get; }
        System.String ReferencedPayanarTableDesignUniqueId { get; set; }
        System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; }
        System.String LeastPayanarTableDesignUniqueId { get; set; }
        System.String LeastPayanarTableColumnDesignUniqueId { get; set; }
    }
    public class PayanarTableColumnDesign : PayanarType, IPayanarTableColumnDesign
    {
        public PayanarTableColumnDesign() { }
        public PayanarTableColumnDesign(string uniqueId, PayanarTableDesign tableDesign)
        {
            UniqueId = uniqueId;
            Parent = tableDesign;
        }
        private System.String _originalName = String.Empty;
        public System.String OriginalName
        {
            get { return _originalName; }
            set
            {
                _originalName = value;
                base.Name = _originalName;
            }
        }
        public System.String ReferencedPayanarTableDesignUniqueId { get; set; } = String.Empty;
        public System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
        public System.String LeastPayanarTableDesignUniqueId { get; set; } = String.Empty;
        public System.String LeastPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
        [JsonIgnore]
        public System.String ColumnType { get { return PayanarTypeSelection?.ColumnFullName; } }
        private PayanarTypeSelection _payanarTypeSelection = null;
        [JsonIgnore]
        public PayanarTypeSelection PayanarTypeSelection
        {
            get
            {
                if (_payanarTypeSelection == null)
                    _payanarTypeSelection = PayanarApplication.Instance.TypeSelections.FirstOrDefault(x => x.ColumnUniqueId.Equals(ReferencedPayanarTableColumnDesignUniqueId));
                return _payanarTypeSelection;
            }
            set
            {
                _payanarTypeSelection = value;
                ReferencedPayanarTableDesignUniqueId = _payanarTypeSelection?.ReferencedPayanarTableDesignUniqueId;
                ReferencedPayanarTableColumnDesignUniqueId = _payanarTypeSelection?.ReferencedPayanarTableColumnDesignUniqueId;
                LeastPayanarTableDesignUniqueId = _payanarTypeSelection?.LeastPayanarTableDesignUniqueId;
                LeastPayanarTableColumnDesignUniqueId = _payanarTypeSelection?.LeastPayanarTableColumnDesignUniqueId;
            }
        }
    }
    public class PayanarTypeSelection
    {
        public PayanarTypeSelection() { }
        public PayanarTypeSelection(PayanarTableDesign tableDesign, PayanarTableColumnDesign tableColumnDesign) : this()
        {
            TableDesign = tableDesign;
            TableColumnDesign = tableColumnDesign;
        }
        public PayanarTableDesign TableDesign { get; set; }
        public PayanarTableColumnDesign TableColumnDesign { private get; set; }
        public System.String ColumnUniqueId { get { return TableColumnDesign?.UniqueId; } }
        public System.String ColumnName { get { return TableColumnDesign?.Name; } }
        public System.String ColumnFullName { get { return TableColumnDesign?.FullName; } }
        public System.String ParentUniqueId { get { return TableColumnDesign?.ParentUniqueId; } }
        public System.String TableName { get { return TableDesign?.Name; } }
        public System.String TableFullName { get { return TableDesign?.FullName; } }
        public System.String ReferencedPayanarTableDesignUniqueId { get { return TableDesign?.UniqueId; } }
        public System.String ReferencedPayanarTableColumnDesignUniqueId { get { return TableColumnDesign?.UniqueId; } }
        public System.String LeastPayanarTableDesignUniqueId { get { return TableColumnDesign?.LeastPayanarTableDesignUniqueId; } }
        public System.String LeastPayanarTableColumnDesignUniqueId { get { return TableColumnDesign?.LeastPayanarTableColumnDesignUniqueId; } }
    }
    public class PayanarTable
    {
        public PayanarTable() { }
        public PayanarTable(PayanarTableDesign tableDesign)
        {
            UniqueId = tableDesign.UniqueId;
            Name = tableDesign.Name;
            TableDesign = tableDesign;
            Rows = new List<PayanarTableRow>();
        }
        public PayanarTable(PayanarTableDesign tableDesign, string uniqueId) : this(tableDesign)
        {
            UniqueId = uniqueId;
        }
        public PayanarTableDesign TableDesign { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public IEnumerable<PayanarTableRow> Rows { get; set; }
        public PayanarTableRow AddRow()
        {
            PayanarTableRow row = new PayanarTableRow(this);
            (Rows as IList<PayanarTableRow>).Add(row);
            return row;
        }
        public PayanarTableRow GetRow(string rowId)
        {
            return rowId != null ? (Rows as IList<PayanarTableRow>).FirstOrDefault(x => x.UniqueId == rowId) : null;
        }
    }
    public class PayanarTableRow
    {
        public PayanarTableRow() { }
        public PayanarTableRow(PayanarTable table)
        {
            UniqueId = Utility.NewUniqueId;
            Cells = new Dictionary<string, PayanarTableCell>();
            AddCells(table.TableDesign.Columns);
        }
        private string _uniqueId;
        public string UniqueId { get { return _uniqueId; } set { _uniqueId = value; } }
        public IDictionary<string, PayanarTableCell> Cells { get; set; }
        public void SetValue(string columnName, string value)
        {
            Cells[columnName].Value = value;
        }
        public string GetValue(string columnName)
        {
            return Cells[columnName].Value;
        }
        private void AddCells(IEnumerable<PayanarTableColumnDesign> columnDesigns)
        {
            columnDesigns.ToList().ForEach(x =>
            {
                Cells.Add(x.Name, new PayanarTableCell(this, x));
            });
        }
    }
    public class PayanarTableCell
    {
        public PayanarTableCell() { }
        public PayanarTableCell(PayanarTableRow row, PayanarTableColumnDesign columnDesign)
        {
            ColumnDesign = columnDesign;
            ColumnDesignUniqueId = columnDesign.UniqueId;
            Row = row;
        }
        public PayanarTableColumnDesign ColumnDesign { get; set; }
        private PayanarTableRow Row { get; set; }
        public string ColumnDesignUniqueId { get; set; }
        public System.String ReferencedPayanarTableDesignUniqueId { get; set; }
        public System.String ReferencedPayanarTableRowUniqueId { get; set; }
        public string Value { get; set; }
    }
}
