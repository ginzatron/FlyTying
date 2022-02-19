
using MongoDB.Bson.Serialization.Attributes;

namespace Flies.RecipeDomain;

[BsonDiscriminator("Adhesive")]
public class Adhesive : Supply
{

}
