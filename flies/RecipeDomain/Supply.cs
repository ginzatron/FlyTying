using MongoDB.Bson.Serialization.Attributes;

namespace Flies.RecipeDomain;
[BsonKnownTypes(typeof(Adhesive))]
public class Supply
{
    public string Name { get; set; }
    public string Note { get; set; }
}
