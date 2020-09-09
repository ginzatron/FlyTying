using FlyTying.Application.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    public class Recipe : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Hook Hook { get; set; }
        public Thread Thread { get; set; }
        public Tool[] Tools { get; set; }
        public Supply[] Supplies { get; set; }
        public Instruction[] Instructions { get; set; }
        public Pattern Pattern { get; set; }

        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }
    }
}
