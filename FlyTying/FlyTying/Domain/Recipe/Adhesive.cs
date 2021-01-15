using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    [BsonDiscriminator("Adhesive")]
    public class Adhesive : Supply
    {
    }
}
