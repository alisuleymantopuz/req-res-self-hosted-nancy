using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Criterias
{
    [DataContract]
    public class ProductCriterias
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

    }
}
