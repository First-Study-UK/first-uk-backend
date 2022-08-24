namespace FirstStudy.Models
{
    public class DashboardDuesDto
    {
        public int? Id { get; set; }
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? PaymentMethod { get; set; }
        public int Fees { get; set; }
        public int TotalPayable { get; set; }
        public DateTime EndDate { get; set; }
    }
}
