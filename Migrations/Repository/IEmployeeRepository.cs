using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public  interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeesByIdAsync(int employeeId);

        Task<int> AddEmployeeAsync(EmployeeModel employeeModel);

        Task UpdateEmployeesAsync(int employeeId, EmployeeModel employeeModel);

        Task DeleteEmployeeAsync(int employeeId);
    }
}
