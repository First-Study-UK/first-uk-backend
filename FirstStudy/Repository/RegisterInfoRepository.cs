using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Repository
{
    public class RegisterInfoRepository : IRegisterInfo
    {
        readonly DatabaseContext _dbContext = new();
        public RegisterInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRegister(RegisterInfo registerInfo)
        {
            try
            {
                _dbContext.RegisterInfo.Add(registerInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<RegisterInfo> GetAllRegisterInfo()
        {
            try
            {
                var register = _dbContext.RegisterInfo.Include(c => c.Attendances).ToList();
                return (register);
            }
            catch
            {
                throw;
            }
        }

        public IList<Attendance> GetAttandancesByStudent(string studentId)
        {
            try
            {
                var register = _dbContext.Attendance.Include(c=>c.RegisterInfo).Where(c=> c.StudentId==studentId).ToList();
                return (register);
            }
            catch
            {
                throw;
            }
        }

        public List<RegisterInfo> GetTeacherRegisterInfo(string teacherId)
        {
            try
            {
                var register = _dbContext.RegisterInfo.Include(c => c.Attendances).Where(c=>c.TeacherId==teacherId).ToList();
                return (register);
            }
            catch
            {
                throw;
            }
        }
    }
}
