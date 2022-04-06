using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_layar;
using Data_Access_layar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Practical_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Service _service;

        public EmployeesController(Service service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmp([FromBody] Employee employee)
        {
            var res = await _service.AddEmp(employee);
            if (res)
            {
                return Ok(employee);
            }
            return BadRequest("Error occuring while adding employee!!!");
        }
        [HttpGet]
        public async Task<List<Employee>> GetAllEmp()
        {
            var employees = await _service.GetAllEmp();
            return employees;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmp(int id, Employee employee)
        {
            try
            {
                if (id == employee.Id)
                {
                    await _service.Updateemp(employee);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _service.IsEmployeeExist(id))
                {
                    return NotFound();
                }
                throw;
            }
            return Ok("Updated Successfull");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var employee = await _service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            await _service.DeleteEmployee(id);
            return Ok("Deleted Successfull");
        }

    }
}
