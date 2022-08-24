using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStudy.Controllers
{
    [Route("api/subjectinfo")]
    [ApiController]
    public class SubjectInfoController : ControllerBase
    {
        private readonly ISubjectInfo _ISubjectInfo;
        public SubjectInfoController(ISubjectInfo ISubjectInfo)
        {
            _ISubjectInfo = ISubjectInfo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectInfo>>> Get()
        {
            return await Task.FromResult(_ISubjectInfo.GetAllSubject());
        }

        [HttpPost]
        public async Task<ActionResult<SubjectInfo>> Post(SubjectInfo subjectInfo)
        {
            _ISubjectInfo.AddSubject(subjectInfo);

            SubSubjectInfo subSubjectInfo = new SubSubjectInfo();
            subSubjectInfo.SubjectId = subjectInfo.SubjectId;
            subSubjectInfo.SubSubject=subjectInfo.SubSubject;   

            _ISubjectInfo.AddSubSubject(subSubjectInfo);

            return await Task.FromResult(subjectInfo);
        }
    }
}
