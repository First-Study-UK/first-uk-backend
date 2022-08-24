namespace FirstStudy.Models
{
    public class TeacherTimetableViewModel
    {
        public string TeacherId { get; set; }
        public string? Subject { get; set; }
        public string? SubSubject { get; set; }
        public string ScheduleDay { get; set; }
        public string ScheduleTime { get; set; }
        public string? YearGroup { get; set; }

        ICollection<StudentInfo>? studentInfos { get; set; }

    }
}
