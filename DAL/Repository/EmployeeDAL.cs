using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAl : IEmployeeDAL
    {
        ApplicationDbContext _dbContext;
        public EmployeeDAl(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {

            var obj = await _dbContext.EmployeeModels.AddAsync(employee);
            _dbContext.SaveChanges();
            return obj.Entity;

            //string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            //using (SqlConnection con = new SqlConnection())
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("spInsertEmployeeDetails", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            //    cmd.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
            //    cmd.Parameters.AddWithValue("@EmployeeDesignation", employee.EmployeeDesignation);

            //    cmd.ExecuteNonQuery();
            //}
        }


        public bool DeleteEmployee(int id)
        {
            if (id > 0)
            {
                var studentbyid = _dbContext.EmployeeModels.Where(x => x.EmployeeID == id).FirstOrDefault();
                if (studentbyid != null)
                {
                    _dbContext.Entry(studentbyid).State = EntityState.Deleted;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;

        }

        public async Task<List<EmployeeModel>> GetEmployee()
        {
            return await _dbContext.EmployeeModels.ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeId(int id)
        {
            var data = await _dbContext.EmployeeModels.Where(x => x.EmployeeID == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateEmployee(EmployeeModel model)
        {
            var data = await _dbContext.EmployeeModels.Where(x => x.EmployeeID == model.EmployeeID).FirstOrDefaultAsync();
            if (data != null)
            {
                data.EmployeeName = model.EmployeeName;
                data.EmployeeGender = model.EmployeeGender;
                data.EmployeeDesignation = model.EmployeeDesignation;
                _dbContext.Entry(data).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }






    }
}
