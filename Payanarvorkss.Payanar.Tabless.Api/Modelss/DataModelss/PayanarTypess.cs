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
        System.String LeastPayanarTableColumnDesignUniqueIdentifier { get; set; }
        System.String ReferencedPayanarTableColumnDesignUniqueIdentifier { get; set; }
        System.String PayanarTableDesignUniqueIdentifier { get; set; }
        System.String ReferencedPayanarTableDesignUniqueIdentifier { get; set; }
    }
    public class PayanarTableColumnDesign : PayanarType, IPayanarTableColumnDesign
    {
        [BsonElement("leastPayanarTableColumnDesignUniqueIdentifier")]
        public System.String LeastPayanarTableColumnDesignUniqueIdentifier { get; set; } = String.Empty;
        [BsonElement("referencedPayanarTableColumnDesignUniqueIdentifier")]
        public System.String ReferencedPayanarTableColumnDesignUniqueIdentifier { get; set; } = String.Empty;
        [BsonElement("payanarTableDesignUniqueIdentifier")]
        public System.String PayanarTableDesignUniqueIdentifier { get; set; } = String.Empty;
        [BsonElement("referencedPayanarTableDesignUniqueIdentifier")]
        public System.String ReferencedPayanarTableDesignUniqueIdentifier { get; set; } = String.Empty;
    }
}
