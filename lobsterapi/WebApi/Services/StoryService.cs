// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using Lobster.API.Entities;
// using Lobster.API.Helpers;
// using Lobster.API.Data;
// using Lobster.API.Models;
// using Lobster.API.Repositories;
// using System.Threading.Tasks;

// namespace Lobster.API.Services
// {
//     public interface IStoryService
//     {
//         Task<Story> GetStory(int StoryId);
//     }

//     public class StoryService : IStoryService
//     {
//         private readonly IDatabaseRepository _repo;
//         private readonly AppSettings _appSettings;

//         public StoryService(IOptions<AppSettings> appSettings, IDatabaseRepository repo)
//         {
//             _appSettings = appSettings.Value;
//             _repo = repo;
//         }

//         public async Task<Story> GetStory(int StoryId)
//         {
//             //var Users = await _repo.GetUsers();
//             // foreach(User userobj in Users){
//             //     Console.WriteLine(userobj.Username);
//             // }

//             //var user = Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

//             var users = await _repo.GetUser(model.Username, model.Password);
//             var user = users.FirstOrDefault();

//             // return null if user not found
//             if (user == null) return null;

//             // authentication successful so generate jwt token
//             var token = generateJwtToken(user);

//             var result =  new AuthenticateResponse(user, token);
//             var returnval = await Task.FromResult(result);
//             return returnval;
//             //return new AuthenticateResponse(user, token);
//         }

        
//     }
// }