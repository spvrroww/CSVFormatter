using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSVTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private IMapper mapper;
        private ApplicationDbContext db;

        protected IMapper _mapper => mapper?? (mapper = HttpContext.RequestServices.GetRequiredService<IMapper>()) ;
        protected ApplicationDbContext _db => db?? (db = HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>());

        
    }
}
