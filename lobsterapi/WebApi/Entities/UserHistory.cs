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
        
        public int Id { get; set; }
        public string UserId { get; set; }
        public TreeNode SelectedNode { get; set; }
    }
}
