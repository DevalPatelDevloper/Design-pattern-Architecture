using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICommandRepo commandRepo;
        private readonly IQueryRepo queryRepo;

        public EmployeeController(ICommandRepo commandRepo, IQueryRepo queryRepo)
        {
            this.commandRepo = commandRepo;
            this.queryRepo = queryRepo;
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            var result = await commandRepo.Create(emp);
            if (result)
            {
                return Ok(emp);
            }
            return BadRequest("Error in Adding Employee");
        }
        [HttpGet()]
        public async Task<ActionResult> GetEmployees(int? id)
        {

            var result = await queryRepo.GetEmployee(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Data Not found");
        }
        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] Employee emp)
        {
            if (id == emp.Id)
            {
                await commandRepo.Edit(emp);
                return Ok(emp);

            }
            return BadRequest("Error in Updation of Employee");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await commandRepo.Delete(id);
            if (result)
            {
                return Ok("Employee Delete Successfully");
            }
            return NotFound("Employee Can not Deleted");
        }
    }
}
