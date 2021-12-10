using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lobster.API.Entities
{
    public class TreeNode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        public int Id { get; set;}
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public int[] ChildrenId { get; set; }
    }
}