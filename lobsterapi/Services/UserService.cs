using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Lobsterapi.Entities;
using Lobsterapi.Helpers;
using Lobsterapi.Data;
using Lobsterapi.Models;
using System.Threading.Tasks;

namespace Lobsterapi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        // IEnumerable<User> GetAll();
        User GetById(int id);
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

        //private List<User> _users = _dbContext.Users; 
        // new List<User>
        // {
        //     new User { Id = 1, Username = "test", Password = "test" }
        // };

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //Console.WriteLine("first user - {0}", _users.First().Username);
            var res = _repo.GetAllUsers().Result;
            var user = res.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            //var result =  new AuthenticateResponse(user, token);
            //return Task.FromResult(result);
            return new AuthenticateResponse(user, token);
        }

        // public IEnumerable<User> GetAll()
        // {
        //     return _users;
        // }

        public User GetById(int id)
        {
            //return _users.FirstOrDefault(x => x.Id == id);
            return  new User { Id = 1, Username = "test", Password = "test" };
        }

        // helper methods

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