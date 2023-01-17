using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Api_Static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private ISchoolService SchoolService { get; }
        public SchoolsController(ISchoolService _SchoolService)
        {
            SchoolService = _SchoolService;
        }
        [HttpGet(Name = "Get_All_School")]
        public APIResponse Get()
        {
            return SchoolService.Get_All_School();
        }
    }
}
