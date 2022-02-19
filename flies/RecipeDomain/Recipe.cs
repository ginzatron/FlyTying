using Flies.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Flies.RecipeDomain;
public class Recipe : IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public Hook Hook { get; set; }
    public Thread Thread { get; set; }
    public Tool[] Tools { get; set; }
    public Supply[] Supplies { get; set; }
    public Instruction[] Instructions { get; set; }
    public Pattern Pattern { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
