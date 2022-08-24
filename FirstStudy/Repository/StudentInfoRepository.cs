using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Repository
{
    public class StudentInfoRepository : IStudentInfo
    {
        readonly DatabaseContext _dbContext = new();
        public StudentInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudent(StudentInfo studentinfo)
        {
            try
            {
                _dbContext.StudentInfo.Add(studentinfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckStudent(int id)
        {
            return _dbContext.StudentInfo.Any(e => e.Id == id);
        }

        public StudentInfo DeleteStudent(string StudentId)
        {
            try
            {
                StudentInfo studentinfo = _dbContext.StudentInfo.Find(StudentId);
                if (studentinfo != null)
                {
                    _dbContext.StudentInfo.Remove(studentinfo);
                    _dbContext.SaveChanges();
                    return studentinfo;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<StudentInfo> GetAllStudent()
        {
            try
            {
                return _dbContext.StudentInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<StudentInfo> GetStudentById(string id)
        {
            return await _dbContext.StudentInfo.FirstOrDefaultAsync(e => e.StudentId == id);
        }

        public void UpdateStudent(StudentInfo studentinfo)
        {
            try
            {
                _dbContext.Entry(studentinfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
