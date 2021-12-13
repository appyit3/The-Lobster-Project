using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lobster.API.Entities
{
    public class UserHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        
        public int StoryId { get; set; }
        public int UserId { get; set; }
        public int[] SelectedNodes { get; set; }
    }
}
