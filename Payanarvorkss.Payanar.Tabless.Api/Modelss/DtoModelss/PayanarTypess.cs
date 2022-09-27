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
    }
    public class HierarchicalPayanarTypeColumn : PayanarType, IHierarchicalPayanarTypeColumn
    {
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
        System.String LeastPayanarTableColumnDesignUniqueIdentifier { get; set; }
        System.String ReferencedPayanarTableColumnDesignUniqueIdentifier { get; set; }
        System.String PayanarTableDesignUniqueIdentifier { get; set; }
    }
    public class PayanarTableColumnDesign : PayanarType, IPayanarTableColumnDesign
    {
        public System.String LeastPayanarTableColumnDesignUniqueIdentifier { get; set; } = String.Empty;
        public System.String ReferencedPayanarTableColumnDesignUniqueIdentifier { get; set; } = String.Empty;
        public System.String PayanarTableDesignUniqueIdentifier { get; set; } = String.Empty;
        public System.String ReferencedPayanarTableDesignUniqueIdentifier { get; set; } = String.Empty;
    }
}
