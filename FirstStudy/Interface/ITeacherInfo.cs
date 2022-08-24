using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface ITeacherInfo
    {
        public List<TeacherInfo> GetAllTeacher();
        Task<TeacherInfo> GetTeacherById(string id);
        public void AddTeacher(TeacherInfo teacherInfo);
        public void UpdateTeacher(TeacherInfo teacherInfo);
        public TeacherInfo DeleteTeacher(int Id);
        public bool CheckTeacher(int id);
    }
}
