using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Api_Static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherServices TeacherService { get; }
        public TeacherController(ITeacherServices _TeacherService)
        {
            TeacherService = _TeacherService;
        }
        [HttpGet(Name = "Get_All_Teacher")]
        public APIResponse Get()
        {
            return TeacherService.Get_All_Teacher();
        }
    }
}
