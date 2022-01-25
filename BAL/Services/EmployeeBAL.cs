using BAL.IService;
using DAL;
using DAL.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL
{
    public class EmployeeBAL : IEmployeeBAL
    {
        private readonly IEmployeeDAL _employeeDAL;
        
        public EmployeeBAL(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }
        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            return await _employeeDAL.AddEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return _employeeDAL.DeleteEmployee(id);
        }

        public async Task<List<EmployeeModel>> GetEmployee()
        {
            return await _employeeDAL.GetEmployee();
        }

        public Task<EmployeeModel> GetEmployeeId(int id)
        {
            return  _employeeDAL.GetEmployeeId(id);
        }

        public Task<bool> UpdateEmployee(EmployeeModel model)
        {
            return _employeeDAL.UpdateEmployee(model);
        }
    }
}
