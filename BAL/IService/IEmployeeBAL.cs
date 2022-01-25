using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IEmployeeBAL
    {
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task<List<EmployeeModel>> GetEmployee();

        Task<EmployeeModel> GetEmployeeId(int id);
        public bool DeleteEmployee(int id);
        Task<bool> UpdateEmployee(EmployeeModel model);
    }
}
