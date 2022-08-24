using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStudy.Controllers
{
    [Route("api/registerinfo")]
    [ApiController]
    public class RegisterInfoController : ControllerBase
    {
        private readonly IRegisterInfo _IRegisterInfo;
        public RegisterInfoController(IRegisterInfo IRegisterInfo)
        {
            _IRegisterInfo = IRegisterInfo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterInfo>>> Get()
        {
            return await Task.FromResult(_IRegisterInfo.GetAllRegisterInfo());
        }

        [HttpPost]
        public async Task<ActionResult<RegisterInfo>> Post(RegisterInfo registerInfo)
        {

            _IRegisterInfo.AddRegister(registerInfo);
            return await Task.FromResult(registerInfo);
        }

        [HttpGet("StudentRegisterBy/{id}")]
        public ActionResult<IEnumerable<Attendance>> GetStudentRegisterById(string id)
        {
            var infobyID = _IRegisterInfo.GetAttandancesByStudent(id);
            if (infobyID == null)
            {
                return NotFound();
            }
            return Ok(infobyID);
        }

        [HttpGet("TeacherRegisterBy/{id}")]
        public async Task<ActionResult<IEnumerable<RegisterInfo>>> GetTeacherRegisterById(string id)
        {
            return await Task.FromResult(_IRegisterInfo.GetTeacherRegisterInfo(id));
        }
    }
}
