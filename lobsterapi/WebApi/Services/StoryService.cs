using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Lobster.API.Entities;
using Lobster.API.Helpers;
using Lobster.API.Data;
using Lobster.API.Models;
using Lobster.API.Repositories;
using System.Threading.Tasks;

namespace Lobster.API.Services
{
    public interface IStoryService
    {
        Task<Story> GetStory(int StoryId);
    }

    public class StoryService : IStoryService
    {
        private readonly IDatabaseRepository _repo;
        private readonly AppSettings _appSettings;

        public StoryService(IOptions<AppSettings> appSettings, IDatabaseRepository repo)
        {
            _appSettings = appSettings.Value;
            _repo = repo;
        }

        public async Task<Story> GetStory(int StoryId)
        {
            IEnumerable<TreeNode> allNodes = await _repo.GetNodes(StoryId);

            Story story = new Story();
            story.StoryId = 1;
            story.Name = "Favourite MCU Hero";
            story.Description = "Find your favourite MCU Hero";

            //Root tree node from DB
            TreeNode rootNode = allNodes.FirstOrDefault(x => x.Id == 1);

            //Root tree node of our required model
            story.RootNode = await FillStoryWithNodes(null, rootNode, allNodes);

            return await Task.FromResult(story);

        }

        //Create story graph through recursion. Each tree node will map to a storynode and we'll do parent and child mappings
        private async Task<StoryNode> FillStoryWithNodes(StoryNode parentNode, TreeNode tnode, IEnumerable<TreeNode> nodes)
        {
            //mapping treenode to a new story node
            StoryNode stonode = new StoryNode(tnode.Id, tnode.Name, tnode.Description);
            
            //mapping parent to child
            //stonode.ParentNode = parentNode;
            
            //mapping child to parent
            if(parentNode != null)
            {
                parentNode.ChildNodes.Add(stonode.Id, stonode);
            }

            //creating children through recursion
            if(tnode.ChildrenId != null)
            {
                foreach(var childId in tnode.ChildrenId)
                {
                    //find treenode from collection
                    TreeNode tcnode = nodes.FirstOrDefault(x => x.Id == childId);
                    await FillStoryWithNodes(stonode, tcnode, nodes);
                }
            }
            else
            {
                stonode.ChildNodes = null;
            }

            return await Task.FromResult(stonode);
        }
    }
}