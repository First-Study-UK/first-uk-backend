using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface ITimeTable
    {
        public List<SelectedSubject> GetStudentTimeTable(string studentid);
        public List<SelectedClass> GetTeacherTimeTables(string teacherid);
        public List<SelectedClass> GetAllTimeTables();
    }
}
