using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface IRegisterInfo
    {
        public void AddRegister(RegisterInfo registerInfo);
        public List<RegisterInfo> GetAllRegisterInfo();
        public IList<Attendance> GetAttandancesByStudent(string studentId);
        public List<RegisterInfo> GetTeacherRegisterInfo(string teacherId);
    }
}
