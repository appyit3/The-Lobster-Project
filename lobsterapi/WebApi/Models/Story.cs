using System.Collections.Generic;
using Lobster.API.Entities;

namespace Lobster.API.Models
{
    public class StoryNode {
        public int Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<int, StoryNode> ChildNodes { get; set; }

        public StoryNode(int id, string name, string desc)
        {
            Id = id;
            Name = name;
            Description = desc;
            ChildNodes = new Dictionary<int, StoryNode>();
        }
    }

    public class Story
    {
        public int StoryId;
        public string Name { get; set; }
        public string Description { get; set; }
        public StoryNode RootNode { get; set; }
    }
}