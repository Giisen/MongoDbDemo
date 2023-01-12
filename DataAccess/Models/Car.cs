using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    public record Car
    {
        [BsonId] public ObjectId Id { get; set; }

        [BsonElement] public string Make { get; set; } = string.Empty;

        [BsonElement] public string Model { get; set; } = string.Empty;
        [BsonElement] public string Color { get; set; } = string.Empty;

        [BsonElement] public int HorsePower { get; set; }
    }
}
