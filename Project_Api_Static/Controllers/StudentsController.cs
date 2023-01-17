using BLL;
using Microsoft.AspNetCore.Mvc;

namespace Project_Api_Static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentservice StudentService { get; }
        public StudentsController(IStudentservice _StudentService)
        {
            StudentService = _StudentService;
        }
        [HttpGet(Name = "Get_All_Student")]
        public async Task<APIResponse> Get()
        {
            return await StudentService.Get_All_Student();
        }
    }
}
