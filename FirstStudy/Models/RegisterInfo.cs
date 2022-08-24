namespace FirstStudy.Models
{
    public class RegisterInfo
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string TeacherId { get; set; }
        public string? TutorName { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
