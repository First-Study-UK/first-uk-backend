namespace FirstStudy.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int Status { get; set; } 
        public string StudentId { get; set; }
        public string? StudentName { get; set; }
        public RegisterInfo? RegisterInfo { get; set; }
        public int? RegisterInfoId { get; set; }
    }
}
