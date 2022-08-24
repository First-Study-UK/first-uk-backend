using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Repository
{
    public class ExpenseInfoRepository : IExpenseInfo
    {
        readonly DatabaseContext _dbContext = new();
        public ExpenseInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddExpenseInfo(ExpenseInfo expenseInfo)
        {
            try
            {
                _dbContext.ExpenseInfo.Add(expenseInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public ExpenseInfo DeleteExpensetHistory(int Id)
        {
            try
            {
                ExpenseInfo expenseInfo = _dbContext.ExpenseInfo.Find(Id);
                if (expenseInfo != null)
                {
                    _dbContext.ExpenseInfo.Remove(expenseInfo);
                    _dbContext.SaveChanges();
                    return expenseInfo;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<ExpenseInfo> GetAllExpenseInfo()
        {
            try
            {
                return _dbContext.ExpenseInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ExpenseInfo> GetExpenseInfoById(int id)
        {
            return await _dbContext.ExpenseInfo.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
