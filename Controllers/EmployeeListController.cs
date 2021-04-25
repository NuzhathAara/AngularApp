using AngularCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeListController : ControllerBase
    {
        private readonly EmployeeListDbContext _context;

        public EmployeeListController(EmployeeListDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeList>>> GetEmployeeList()
        {
            return await _context.EmployeeList.ToListAsync();
        }

        // GET: api/EmployeeList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeList>> GetEmployeeList(int id)
        {
            var employee = await _context.EmployeeList.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/EmployeesList/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeList(int id, EmployeeList employeelist)
        {
            if (id != employeelist.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeelist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeList>> PostEmployee(EmployeeList employeelist)
        {
            _context.EmployeeList.Add(employeelist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employeelist.Id }, employeelist);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeList>> DeleteEmployee(int id)
        {
            var employeelist = await _context.EmployeeList.FindAsync(id);
            if (employeelist == null)
            {
                return NotFound();
            }

            _context.EmployeeList.Remove(employeelist);
            await _context.SaveChangesAsync();

            return employeelist;
        }

        private bool EmployeeListExists(int id)
        {
            return _context.EmployeeList.Any(e => e.Id == id);
        }
    }
}
