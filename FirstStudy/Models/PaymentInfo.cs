namespace FirstStudy.Models
{
    public class PaymentInfo
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Fees { get; set; }
        public int TotalPayable { get; set; }
        public int Discount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string InvoiceId { get; set; }
        public string Note { get; set; }
        public string StudentName { get; set; }
    }
}
