using API.Data;
using API.Models.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(APIDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees.ToListAsync();
                var records = _mapper.Map<Employee>(employees);
                return Ok(records);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDTO);
            
            if (_context.Employees == null)
            {
                return Problem("Entity 'API.Employees' is null");
            }

            employee.Id = AssignNewID();

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] UpdateEmployeeDTO updateEmployeeDTO)
        {
            if (id != updateEmployeeDTO.Id) 
            {
                return BadRequest();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEmployeeDTO, employee);

            try
            {
                await _context.SaveChangesAsync();

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string AssignNewID()
        {
            Random newString = new Random();
            char firstChar = (char)newString.Next('A', 'Z' + 1);
            char secondChar = (char)newString.Next('A', 'Z' + 1);
            int randomNumber = newString.Next(1000, 10000);

            string formattedString = $"{firstChar}{secondChar}-{randomNumber}";

            return formattedString;
        }
    }
}
