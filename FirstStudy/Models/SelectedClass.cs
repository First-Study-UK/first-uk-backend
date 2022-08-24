namespace FirstStudy.Models
{
    public class SelectedClass
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public string YearGroup { get; set; }
        public string Subject { get; set; }
        public string SubSubject { get; set; }
        public string ScheduleDay { get; set; }
        public string ScheduleTime { get; set; }
        public TeacherInfo? TeacherInfo { get; set; }
        public int? TeacherInfoId { get; set; }

        public ICollection<SelectedSubject>? SelectedSubjects { get; set; }

    }
}
