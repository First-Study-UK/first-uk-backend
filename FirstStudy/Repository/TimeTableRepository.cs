using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Repository
{
    public class TimeTableRepository : ITimeTable
    {
        readonly DatabaseContext _dbcontext=new DatabaseContext();
        public TimeTableRepository(DatabaseContext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        public List<SelectedSubject> GetStudentTimeTable(string studentid)  
        {
            try
            {
                var studentTimeTable = _dbcontext.SelectedSubject
                                        .Include(c => c.SelectedClass)
                                            .ThenInclude(d => d.TeacherInfo)
                                        .Where(p => p.StudentId == studentid).ToList();
                return studentTimeTable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectedClass> GetTeacherTimeTables(string teacherid)
        {
            try
            {
                var teacherTimeTables = _dbcontext.SelectedClass
                                            .Include(c => c.SelectedSubjects)
                                                .ThenInclude(d => d.StudentInfo)
                                            .Where(p => p.TeacherId == teacherid).ToList();
                return teacherTimeTables;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SelectedClass> GetAllTimeTables()
        {
            try
            {
                var teacherTimeTables = _dbcontext.SelectedClass
                                            .Include(c => c.SelectedSubjects)
                                                .ThenInclude(d => d.StudentInfo)
                                            .ToList();

                return teacherTimeTables;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
