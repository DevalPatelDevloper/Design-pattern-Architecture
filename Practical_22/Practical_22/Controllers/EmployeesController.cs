using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access_layar.Models;
using Services.Models;
using BAL_AbstractDeptFactory;
using Business__access_layer;

namespace Practical_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly DeptFactory departFactory;
        private readonly FactoryType factoryType;

        public EmployeesController(AppDbContext context, DeptFactory departFactory, FactoryType factoryType)
        {
            _context = context;
            this.departFactory = departFactory;
            this.factoryType = factoryType;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return Ok("This id is not in list.....Please Reenter id");
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return Ok("Employee is not Exist");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return Ok("Employee is not in List");
            }
            employee.Status = true;
            _context.Update(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        [HttpGet("OvertimePayFactory")]
        public async Task<ActionResult> OvertimePay(int id, int hour)
        {
            if (id != 0)
            {
                var deptname = await _context.Employees.Include(x => x.Dept).Where(x => x.Id == id).Select(x => x.Dept.Dept_Name).FirstOrDefaultAsync();
                var result = departFactory.Getobj(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok(overtimepay);
            }
            return NotFound("Data Not found");
        }
        [HttpGet("OvertimePayAbstractFactory")]
        public async Task<ActionResult> OvertimePayAbstractFactory(int id, int hour, string factorytype)
        {
            if (id != 0)
            {
                var obj = factoryType.getfactorytype(factorytype);
                var deptname = await _context.Employees.Include(x => x.Dept).Where(x => x.Id == id).Select(x => x.Dept.Dept_Name).FirstOrDefaultAsync();
                var result = obj.GetFactory(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok(overtimepay);
            }
            return NotFound("Data Not found");
        }
    }
}
