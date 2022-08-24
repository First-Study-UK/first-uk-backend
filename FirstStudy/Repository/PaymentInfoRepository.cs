using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Repository
{
    public class PaymentInfoRepository : IPaymentInfo
    {
        readonly DatabaseContext _dbContext = new();
        public PaymentInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPayment(PaymentInfo paymentInfo)
        {
            try
            {
                _dbContext.PaymentInfo.Add(paymentInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public PaymentInfo DeletePaymentHistory(int Id)
        {
            try
            {
                PaymentInfo paymentInfo = _dbContext.PaymentInfo.Find(Id);
                if (paymentInfo != null)
                {
                    _dbContext.PaymentInfo.Remove(paymentInfo);
                    _dbContext.SaveChanges();
                    return paymentInfo;
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

        public List<PaymentInfo> GetAllPaymentInfo()
        {
            try
            {
                return _dbContext.PaymentInfo.OrderByDescending(c => c.Id).ToList();
            }
            catch
            {
                throw;
            }
        }

        public PaymentInfo GetPaymentInfoByInvoice(string invoice)
        {
            var eroor = _dbContext.PaymentInfo.FirstOrDefault(e => e.InvoiceId == invoice);
            return eroor;
        }

        public List<PaymentInfo> GetPaymentInfoByStudentId(string id)
        {
            return  _dbContext.PaymentInfo.Where(e => e.StudentId == id).OrderByDescending(c => c.Id).ToList();
        }

        public async Task<StudentInfo> GetStudentInfoByStudentId(string id)
        {
            return await _dbContext.StudentInfo.FirstOrDefaultAsync(e => e.StudentId == id);
        }
    }
}
