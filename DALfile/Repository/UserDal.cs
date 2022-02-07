using DALfile.IRepository;
using Microsoft.EntityFrameworkCore;
using MODELfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DALfile.Repository
{

    public class UserDal : IUserDal
    {
        ApplicationContext _dbcontext;
        public UserDal(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<UserModel>> GetUserDetail(int? userId)
        {
            List<UserModel> lst = new List<UserModel>();
            if (userId == null)
            {
                //ytetyey;
                lst = await _dbcontext.Users.ToListAsync();
            }
            else
            {
               
                lst = await _dbcontext.Users.Where(x => x.Id == userId).ToListAsync();
                
            }

            return lst;
        }
        public async Task<int> AddUpdateUser(UserModel user)
        {
            int result = 0;
            try
            {
                if (user.Id == null)
                {
                    _dbcontext.Add(user);
                    result = await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    var data = await _dbcontext.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.FirstName = user.FirstName;
                        data.LastName = user.LastName;
                        data.UserName = user.UserName;
                        data.Password = user.Password;
                        _dbcontext.Entry(data).State = EntityState.Modified;
                        result = await _dbcontext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<int> DeleteUser(int userId)
        {
            int result = 0;
            if (userId > 0)
            {
                var studentbyid = _dbcontext.Users.Where(x => x.Id == userId).FirstOrDefault();
                if (studentbyid != null)
                {
                    _dbcontext.Entry(studentbyid).State = EntityState.Deleted;
                    result = await _dbcontext.SaveChangesAsync();
                }
            }
            return result;


        }

        public async Task<bool> ErrorLog(Exception ex)
        {
            Logtable logtable = new Logtable()
            {
                Application = "",
                ErrorMessage = ex.Message,
                ErrorDetails = Convert.ToString(ex.InnerException),
                ExtraInformation = ex.StackTrace
            };
            _dbcontext.Add(logtable);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
