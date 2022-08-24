namespace FirstStudy.Models
{
    public class ExpenseInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ExpenseType { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
