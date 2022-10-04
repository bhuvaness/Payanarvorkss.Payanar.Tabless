using MongoDB.Bson.Serialization.Attributes;

namespace Payanarvorkss.Payanar.Tabless.Api.DataModelss
{
    public interface IPayanarType
    {
        string ParentUniqueId { get; set; }
        string UniqueId { get; set; }
        string Name { get; set; }
    }
    public class PayanarType : IPayanarType
    {
        [BsonId]
        public string UniqueId { get; set; } = String.Empty;
        [BsonElement("parentUniqueId")]
        public string ParentUniqueId { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
    }
    public interface IHierarchicalPayanarTypeDesign : IPayanarType
    {
    }
    public class HierarchicalPayanarTypeDesign : PayanarType, IHierarchicalPayanarTypeDesign
    {
    }
    public interface IHierarchicalPayanarTypeColumnDesign : IPayanarType
    {
        bool IsPayanarTableDesign { get; set; }
    }
    public class HierarchicalPayanarTypeColumnDesign : PayanarType, IHierarchicalPayanarTypeColumnDesign
    {
        public bool IsPayanarTableDesign { get; set; } = false;
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
        [BsonElement("originalName")]
        public System.String OriginalName { get; set; } = String.Empty;
        [BsonElement("columns")]
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
        [BsonElement("referencedPayanarTableDesignUniqueId")]
        public System.String ReferencedPayanarTableDesignUniqueId { get; set; } = String.Empty;
        [BsonElement("referencedPayanarTableColumnDesignUniqueId")]
        public System.String ReferencedPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
        [BsonElement("leastPayanarTableDesignUniqueId")]
        public System.String LeastPayanarTableDesignUniqueId { get; set; } = String.Empty;
        [BsonElement("leastPayanarTableColumnDesignUniqueId")]
        public System.String LeastPayanarTableColumnDesignUniqueId { get; set; } = String.Empty;
    }
}
