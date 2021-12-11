using Lobster.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Lobster.API.Data
{
    public class DatabaseSeed
    {
        public static void SeedUsers(IMongoCollection<User> Users)
        {
            //Initial users
            bool existUser = Users.Find(p => true).Any();
            if (!existUser)
            {
                Users.InsertManyAsync(GetPreconfiguredUsers());
            }
        }

        public static void SeedNodes(IMongoCollection<TreeNode> Nodes)
        {
            //Initial Story Nodes
            bool existNode = Nodes.Find(n => true).Any();
            if (!existNode)
            {
                Nodes.InsertManyAsync(GetPreconfiguredNodes());
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id= 1,
                    Username= "test",
                    Password= "test"
                },
                new User()
                {
                    Id= 2,
                    Username= "Wolverine",
                    Password= "Wolverine"
                },
                new User()
                {
                    Id= 3,
                    Username= "Raven",
                    Password= "Raven"
                },
                new User()
                {
                    Id= 4,
                    Username= "Rogue",
                    Password= "Rogue"
                },
                new User()
                {
                    Id= 5,
                    Username= "Magneto",
                    Password= "Magneto"
                },
                new User()
                {
                    Id= 6,
                    Username= "Sabretooth",
                    Password= "Sabretooth"
                },
                new User()
                {
                    Id= 7,
                    Username= "Pyro",
                    Password= "Pyro"
                }
            };
        }

        private static IEnumerable<TreeNode> GetPreconfiguredNodes()
        {
            return new List<TreeNode>()
            {
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 1,
                    Name= "MCU",
                    Description= "Do you like aliens or humans?",
                    ChildrenId = new int[2] { 2, 3 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 2,
                    Name= "Aliens",
                    Description= "Do you like aliens who are Gods?",
                    ChildrenId = new int[2] { 4, 5 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 3,
                    Name= "Humans",
                    Description= "Do you like humans or superhumans",
                    ChildrenId = new int[2] { 6, 7 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 4,
                    Name= "Yes",
                    Description= "Hammer or Dagger or Gungnir",
                    ChildrenId = new int[3] { 8, 9, 10 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 5,
                    Name= "No",
                    Description= "Tree or Raccoon or Green",
                    ChildrenId = new int[3] { 11, 12, 13 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 6,
                    Name= "Humans",
                    Description= "Arrows or Spider or Iron suit",
                    ChildrenId = new int[3] { 14, 15, 16 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 7,
                    Name= "Superhumans",
                    Description= "US or England or Africa or Asia",
                    ChildrenId = new int[4] { 17, 18, 19, 20 } 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 8,
                    Name= "Hammer",
                    Description= "THOR",
                    ChildrenId = null
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 9,
                    Name= "Dagger",
                    Description= "LOKI",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 10,
                    Name= "Gungnir",
                    Description= "ODIN",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 11,
                    Name= "Tree",
                    Description= "GROOT",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 12,
                    Name= "Raccoon",
                    Description= "ROCKET RACOON",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 13,
                    Name= "Green",
                    Description= "GAMORA",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 14,
                    Name= "Arrows",
                    Description= "HAWKEYE",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 15,
                    Name= "Spider",
                    Description= "BLACK WIDOW",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 16,
                    Name= "Iron suit",
                    Description= "IRON MAN",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 17,
                    Name= "US",
                    Description= "Captain America",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 18,
                    Name= "England",
                    Description= "Dr. Strange",
                    ChildrenId = null
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 19,
                    Name= "Africa",
                    Description= "Black Panther",
                    ChildrenId = null 
                },
                new TreeNode()
                {
                    StoryId = 1,
                    Id= 20,
                    Name= "Asia",
                    Description= "Shaang Chi",
                    ChildrenId = null 
                }
            };
        }
    }
}
