using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Controllers
{
    [Route("api/teacherinfo")]
    [ApiController]
    public class TeacherInfoController : ControllerBase
    {
        readonly ITeacherInfo _ITeacherInfo;
        readonly ISelectedClass _ISelectedClass;
        readonly DatabaseContext _DatabaseContext;
        public TeacherInfoController(ITeacherInfo ITeacherInfo, ISelectedClass ISelectedClass, DatabaseContext DatabaseContext)
        {
            _ITeacherInfo = ITeacherInfo;
            _ISelectedClass = ISelectedClass;
            _DatabaseContext = DatabaseContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherViewModel>>> GetAllTeacher()
        {
            List<TeacherViewModel> viewModel = new List<TeacherViewModel>();
            var result = _DatabaseContext.TeacherInfo.ToList();
            var select = _DatabaseContext.SelectedClass.ToList();

            foreach (var item in result)
            {
                TeacherViewModel view = new TeacherViewModel();
                view.SelectedClass = select.Where(o => o.TeacherId == item.TeacherId).ToList();
                view.TeacherInfo = item;
                viewModel.Add(view);
            }
            return viewModel;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherViewModel>> GetbyId(string id)
        {
            TeacherViewModel viewModel = new TeacherViewModel();
            var result = _DatabaseContext.TeacherInfo.FirstOrDefault(o => o.TeacherId == id);
            var select = _DatabaseContext.SelectedClass.Where(o => o.TeacherId == id).ToList();

            viewModel.SelectedClass = select;
            viewModel.TeacherInfo = result;
            return viewModel;
        }
        [HttpPost]
        public async Task<ActionResult<TeacherViewModel>> Post(TeacherViewModel teacherViewModel)
        {
            var teacher = teacherViewModel.TeacherInfo;
            _ITeacherInfo.AddTeacher(teacher);
            var selectedcls = teacherViewModel.SelectedClass.ToList();
            foreach (var cls in selectedcls)
            {
                cls.TeacherInfoId = teacher.Id;
                cls.TeacherId = teacher.TeacherId;
                _ISelectedClass.AddSelectedSubject(cls);
            }
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<TeacherInfo>> Put(int id, TeacherInfo teacherInfo)
        {
            if (id != teacherInfo.Id)
            {
                return BadRequest();
            }
            try
            {
                _ITeacherInfo.UpdateTeacher(teacherInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(teacherInfo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherInfo>> Delete(int id)
        {
            var teacher = _ITeacherInfo.DeleteTeacher(id);
            return await Task.FromResult(teacher);
        }

        private bool TeacherExists(int id)
        {
            return _ITeacherInfo.CheckTeacher(id);
        }
    }
}
