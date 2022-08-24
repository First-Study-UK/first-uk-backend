using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace FirstStudy.Controllers
{
    [Route("api/studentinfo")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        private readonly IStudentInfo _IStudentInfo;
        private readonly ISelectedSubject _ISelectedSubject;
        private readonly DatabaseContext _DatabaseContext;
        public StudentInfoController(IStudentInfo IStudentInfo, ISelectedSubject ISelectedSubject,DatabaseContext DatabaseContext)
        {
            _IStudentInfo = IStudentInfo;
            _ISelectedSubject = ISelectedSubject;
            _DatabaseContext = DatabaseContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetAllStudent()
        {
            List<StudentViewModel> viewModel = new List<StudentViewModel>();
            var result = _DatabaseContext.StudentInfo.ToList();
            var select = _DatabaseContext.SelectedSubject.Include(c => c.SelectedClass).ToList();

            foreach (var item in result)
            {
                StudentViewModel view = new StudentViewModel();
                view.SelectedSubject = select.Where(o => o.StudentId == item.StudentId).ToList();
                view.StudentInfo = item;
                viewModel.Add(view);
            }
            return viewModel;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> GetByStudentId(string id)
        {
            StudentViewModel viewModel = new StudentViewModel();
            var result = _DatabaseContext.StudentInfo.FirstOrDefault(o => o.StudentId==id);            
            var select = _DatabaseContext.SelectedSubject.Include(c=>c.SelectedClass).ThenInclude(d=> d.TeacherInfo).Where(o => o.StudentId==id).ToList();
            
            viewModel.SelectedSubject = select;
            viewModel.StudentInfo = result;
            return viewModel;
        }

        [HttpPost]
        public async Task<ActionResult<StudentViewModel>> Post(StudentViewModel studentViewModel)
        {
            var std = studentViewModel.StudentInfo;
            _IStudentInfo.AddStudent(std);
            var selectedsub = studentViewModel.SelectedSubject.ToList();
            foreach (var sub in selectedsub)
            {
                sub.StudentInfoId = std.Id;
                sub.StudentId = std.StudentId;
                _ISelectedSubject.AddSelectedSubject(sub);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<StudentInfo>> Put(int id, StudentInfo studentInfo)
        {
            if (id != studentInfo.Id)
            {
                return BadRequest();
            }
            try
            {
                _IStudentInfo.UpdateStudent(studentInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(studentInfo);
        }


        //changes needed
        [HttpDelete("{StudentId}")]
        public async Task<ActionResult<StudentInfo>> Delete(string StudentId)
        {
            return Ok();
        }

        private bool StudentExists(int id)
        {
            return _IStudentInfo.CheckStudent(id);
        }
    }
}
