using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult>GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById( [FromRoute] int id)
        {
            var employee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeModel employeeModel)
        {
            var id= await _employeeRepository.AddEmployeeAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmployeesById), new { id = id, controller = "employees" },id) ;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeModel employeeModel,[FromRoute] int id)
        {
             await _employeeRepository.UpdateEmployeesAsync(id,employeeModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee( [FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return Ok();
        }


    }
}
