using System.Collections.Generic;

namespace Lobster.API.Models
{
    public class StoryNode {
        public int Id;
        public StoryNode ParentNode { get; set; }
        private Dictionary<int, StoryNode> ChildNodes { get; set; }
    }

    public class Story
    {
        public int StoryId;
        public string Name { get; set; }
        public string Description { get; set; }
        public StoryNode root { get; set; }
    }
}