using DALfile.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MODELfile;
using MODELfile.Authenticate;
using MODELfile.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DALfile.Repository
{
    public class AuthenticationDal : IAuthenticationDal
    {
        public readonly ApplicationContext _dbcontext;
        private readonly AppSettings _appSettings;
        public AuthenticationDal(ApplicationContext dbcontext, IOptions<AppSettings> appSettings)
        {
            _dbcontext = dbcontext;
            _appSettings = appSettings.Value;
        }
        public async Task<UserModel> Authenticate(AuthenticateRequest model)
        {
            UserModel lst = await _dbcontext.Users.Where(x => x.UserName == model.Username && x.Password == model.Password).FirstOrDefaultAsync();
            return lst;
        }
    }
}
