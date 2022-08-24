using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstStudy.Repository
{
    public class TeacherInfoRepository : ITeacherInfo
    {
        readonly DatabaseContext _dbContext = new();
        public TeacherInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddTeacher(TeacherInfo teacherInfo)
        {
            try
            {
                _dbContext.TeacherInfo.Add(teacherInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckTeacher(int id)
        {
            return _dbContext.TeacherInfo.Any(e => e.Id == id);
        }

        public TeacherInfo DeleteTeacher(int Id)
        {
            try
            {
                TeacherInfo teacherInfo = _dbContext.TeacherInfo.Find(Id);
                if (teacherInfo != null)
                {
                    _dbContext.TeacherInfo.Remove(teacherInfo);
                    _dbContext.SaveChanges();
                    return teacherInfo;
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

        public List<TeacherInfo> GetAllTeacher()
        {
            try
            {
                return _dbContext.TeacherInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TeacherInfo> GetTeacherById(string id)
        {
            return await _dbContext.TeacherInfo.FirstOrDefaultAsync(e => e.TeacherId == id);
        }

        public void UpdateTeacher(TeacherInfo teacherInfo)
        {
            try
            {
                _dbContext.Entry(teacherInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
