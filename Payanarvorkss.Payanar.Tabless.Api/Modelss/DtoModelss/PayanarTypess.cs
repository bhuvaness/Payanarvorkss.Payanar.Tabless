using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Payanarvorkss.Payanar.Tabless.Api.Utilitiess;

namespace Payanarvorkss.Payanar.Tabless.Api.DtoModelss
{
    public interface IPayanarType
    {
        string UniqueId { get; set; }
        string ParentUniqueId { get; set; }
        string Name { get; set; }
    }
    public class PayanarType : IPayanarType
    {
        public string UniqueId { get; set; } = String.Empty;
        public string ParentUniqueId { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
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
    }
    public class HierarchicalPayanarTypeColumn : PayanarType, IHierarchicalPayanarTypeColumn
    {
        public bool IsPayanarTableDesign { get; set; }
    }
    public interface IPayanarTableDesign : IPayanarType
    {
        System.String OriginalName { get; set; }
        IEnumerable<PayanarTableColumnDesign> Columns { get; set; }
    }
    public class PayanarTableDesign : PayanarType, IPayanarTableDesign
    {
        public System.String OriginalName { get; set; } = String.Empty;
        public IEnumerable<PayanarTableColumnDesign> Columns { get; set; }
    }
    public interface IPayanarTableColumnDesign : IPayanarType
    {
        System.String ReferencedPayanarTableDesignUniqueId { get; set; }
        System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; }
        System.String LeastPayanarTableDesignUniqueId { get; set; }
        System.String LeastPayanarTableColumnDesignUniqueId { get; set; }
    }
    public class PayanarTableColumnDesign : PayanarType, IPayanarTableColumnDesign
    {
        public System.String ReferencedPayanarTableDesignUniqueId { get; set; } = String.Empty;
        public System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
        public System.String LeastPayanarTableDesignUniqueId { get; set; } = String.Empty;
        public System.String LeastPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
    }
}
