
using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface IPaymentInfo
    {
        public void AddPayment(PaymentInfo paymentInfo);
        Task<StudentInfo> GetStudentInfoByStudentId(string id);
        public List<PaymentInfo> GetAllPaymentInfo();
        public PaymentInfo DeletePaymentHistory(int Id);
        public List<PaymentInfo> GetPaymentInfoByStudentId(string id);
        PaymentInfo GetPaymentInfoByInvoice(string invoice);
    }
}
