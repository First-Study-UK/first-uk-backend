namespace FirstStudy.Models
{
    public class SelectedSubject
    {
        public int Id { get; set; }
        public SelectedClass? SelectedClass { get; set; }
        public int? SelectedClassId { get; set; }
        public StudentInfo? StudentInfo { get; set; }
        public int? StudentInfoId { get; set; }
        public string? StudentId { get; set; }

    }
}
