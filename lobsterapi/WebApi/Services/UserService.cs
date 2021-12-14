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
        Task<IEnumerable<User>> GetUsers();
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
            var users = await _repo.GetUserByName(model.Username);
            var user = users.FirstOrDefault();

            // return null if user not found
            if ((user == null) || (user.Password != model.Password)) return null;

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

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repo.GetUsers();
        }


        //generate token
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 1 day
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(1),//.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}