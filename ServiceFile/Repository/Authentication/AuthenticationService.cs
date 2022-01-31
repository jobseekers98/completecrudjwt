using DALfile;
using DALfile.IRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MODELfile;
using MODELfile.Authenticate;
using MODELfile.Helpers;
using Servicefile.IRepository.IAuthentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicefile.Repository.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthenticationDal _IauthenticationDal;
        public AuthenticationService(IOptions<AppSettings> appSettings, IAuthenticationDal IauthenticationDal)
        {
            _appSettings = appSettings.Value;
            _IauthenticationDal = IauthenticationDal;
        }
        public async Task<UserModel> Authenticate(AuthenticateRequest model)
        {
            return await _IauthenticationDal.Authenticate(model);
        }
        public string GenerateToken(UserModel user)
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
