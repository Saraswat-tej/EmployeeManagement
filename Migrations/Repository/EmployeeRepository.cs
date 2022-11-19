using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            this._context = context;

        }
        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var records = await _context.Employees.Select(x => new EmployeeModel()
            {
                Id = x.Id,
                EmpName = x.EmpName,
                Email = x.Email,
                Department = x.Department,
                Designation = x.Designation,
                WorkingHours = x.WorkingHours


            }).ToListAsync();

            return records;


        }
        public async Task<EmployeeModel>GetEmployeesByIdAsync(int employeeId)
        {
            var records = await _context.Employees.Where(x => x.Id == employeeId).Select(x => new EmployeeModel()
            {
                Id = x.Id,
                EmpName = x.EmpName,
                Email = x.Email,
                Department = x.Department,
                Designation = x.Designation,
                WorkingHours = x.WorkingHours


            }).FirstOrDefaultAsync();

            return records;

        }
        public async Task<int> AddEmployeeAsync(EmployeeModel employeeModel)
        {
            try
            {
                var employee = new Employees()
                {
                    EmpName = employeeModel.EmpName,
                    Email = employeeModel.Email,
                    Department = employeeModel.Department,
                    Designation = employeeModel.Designation,
                    WorkingHours = employeeModel.WorkingHours

                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                return employee.Id;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task  UpdateEmployeesAsync(int employeeId, EmployeeModel employeeModel)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                employee.EmpName = employeeModel.EmpName;
                employee.Email = employeeModel.Email;
                employee.Department = employeeModel.Department;
                employee.Designation = employeeModel.Designation;
                employee.WorkingHours = employeeModel.WorkingHours;

               await _context.SaveChangesAsync();
            }
            

        }

        public async Task  DeleteEmployeeAsync(int employeeId)
        {
            var employee = new Employees() {Id=employeeId };

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

          
        }




    }
}
