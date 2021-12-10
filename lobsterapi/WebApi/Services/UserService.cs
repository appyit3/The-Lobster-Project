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
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<User> GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly IDatabaseRepository _repo;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IDatabaseRepository repo)
        {
            _appSettings = appSettings.Value;
            _repo = repo;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            //var Users = await _repo.GetUsers();
            // foreach(User userobj in Users){
            //     Console.WriteLine(userobj.Username);
            // }

            //var user = Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            var users = await _repo.GetUser(model.Username, model.Password);
            var user = users.FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            var result =  new AuthenticateResponse(user, token);
            var returnval = await Task.FromResult(result);
            return returnval;
            //return new AuthenticateResponse(user, token);
        }

        public async Task<User> GetById(int id)
        {
            return await _repo.GetUser(id);
        }


        //generate token
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}