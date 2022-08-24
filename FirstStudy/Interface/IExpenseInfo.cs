using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface IExpenseInfo
    {
        public void AddExpenseInfo(ExpenseInfo expenseInfo);
        Task<ExpenseInfo> GetExpenseInfoById(int id);
        public List<ExpenseInfo> GetAllExpenseInfo();
        public ExpenseInfo DeleteExpensetHistory(int Id);
    }
}
