using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal? UnitPrice { get; set; }

        [DataMember]
        public int? UnitsInStock { get; set; }

        [DataMember]
        public int? ReorderLevel { get; set; }

    
    }
}
