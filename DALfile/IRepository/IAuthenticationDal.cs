using MODELfile;
using MODELfile.Authenticate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DALfile.IRepository
{
    public interface IAuthenticationDal
    {
        Task<UserModel> Authenticate(AuthenticateRequest model);
    }
}
