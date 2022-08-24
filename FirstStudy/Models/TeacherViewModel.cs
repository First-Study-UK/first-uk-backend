namespace FirstStudy.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public TeacherInfo TeacherInfo { get; set; }
        public List<SelectedClass> SelectedClass { get; set; }
    }
}
