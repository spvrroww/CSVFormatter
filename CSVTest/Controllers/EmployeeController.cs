using CSVTest.Helper;
using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CSVTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeController>
    {
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = await _db.Employees.AddAsync(employee.MapToEmployee(_mapper));
                await _db.SaveChangesAsync();
                return Ok(newEmployee.Entity.MapToEmployeeDTO(_mapper));
            }
            else
            {
                return BadRequest(new ErrorModel
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    Message = "Invalid Request Parameters"
                });
            }
        }

        [HttpGet("companyId")]
        public async Task<IActionResult> GetAllEmployees(Guid CompanyId)
        {
            var existingEmployees = _db.Employees.Where(x=> x.CompanyId == CompanyId).AsNoTracking();
          
            return Ok(existingEmployees.Select<Employee, EmployeeDTO>(x=> x.MapToEmployeeDTO(_mapper)));
            
        }
    }
}
