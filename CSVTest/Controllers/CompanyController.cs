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
    public class CompanyController : BaseController<CompanyController>
    {
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDTO companyDTO)
        {
            if (ModelState.IsValid)
            {
                var newCompany = await _db.Companies.AddAsync(companyDTO.MapToCompany(_mapper));
                await _db.SaveChangesAsync();
                return Ok(newCompany.Entity.MapToCompanyDTO(_mapper));
            }
            else return BadRequest( new ErrorModel
            {
                ErrorCode = StatusCodes.Status400BadRequest,
                Message = "invalid Request parameters"
            });
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _db.Companies.ToListAsync();
            return Ok(companies.Select<Company, CompanyDTO>(x => x.MapToCompanyDTO(_mapper)));
            
        }

    }
}
