using FirstStudy.Interface;
using FirstStudy.Models;
using FirstStudy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTable _studentTimeTable;
        public TimeTableController(ITimeTable studentTimeTable)
        {
            _studentTimeTable = studentTimeTable;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SelectedSubject>>> Get(string id)
        {
            return await Task.FromResult(_studentTimeTable.GetStudentTimeTable(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedClass>>> Get()
        {
            return await Task.FromResult(_studentTimeTable.GetAllTimeTables());
        }

        [HttpGet("TeacherTimeTable/{id}")]
        public async Task<ActionResult<IEnumerable<SelectedClass>>> GetTeacher(string id)
        {
            return await Task.FromResult(_studentTimeTable.GetTeacherTimeTables(id));
        }
    }
}
