using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface IStudentInfo
    {
        public List<StudentInfo> GetAllStudent();
        Task<StudentInfo> GetStudentById(string id);
        public void AddStudent(StudentInfo studentinfo);
        public void UpdateStudent(StudentInfo studentinfo);
        public StudentInfo DeleteStudent(string StudentId);
        public bool CheckStudent(int id);
    }
}
