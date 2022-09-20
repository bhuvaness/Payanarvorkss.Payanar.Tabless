using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Payanarvorkss.Payanar.Tabless.Api.Utilitiess;

namespace Payanarvorkss.Payanar.Tabless.Api.DtoModelss
{
    public interface IPayanarType
    {
        string UniqueId { get; set; }
        string Name { get; set; }
    }
    public class PayanarType : IPayanarType
    {
        public string UniqueId { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
    }
    public interface IHierarchicalPayanarTableDesign : IPayanarType
    {
        IEnumerable<HierarchicalPayanarTableColumnDesign> Columns { get; set; }
    }
    public class HierarchicalPayanarTableDesign : PayanarType, IHierarchicalPayanarTableDesign
    {
        public HierarchicalPayanarTableDesign()
        {
            Columns = new List<HierarchicalPayanarTableColumnDesign>();
        }
        public IEnumerable<HierarchicalPayanarTableColumnDesign> Columns { get; set; }
    }
    public interface IHierarchicalPayanarTableColumnDesign : IPayanarType
    {
    }
    public class HierarchicalPayanarTableColumnDesign : PayanarType, IHierarchicalPayanarTableColumnDesign
    {
    }
    public interface IPayanarTableDesign : IPayanarType
    {
        System.String OriginalName { get; set; }
        IEnumerable<PayanarTableColumnDesign> Columnss { get; set; }
    }
    public class PayanarTableDesign : PayanarType, IPayanarTableDesign
    {
        public System.String OriginalName { get; set; } = String.Empty;
        public IEnumerable<PayanarTableColumnDesign> Columnss { get; set; }
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
