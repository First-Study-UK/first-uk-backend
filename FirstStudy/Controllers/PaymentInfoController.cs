using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStudy.Controllers
{
    [Route("api/paymentinfo")]
    [ApiController]
    public class PaymentInfoController : ControllerBase
    {
        private readonly IPaymentInfo _IPaymentInfo;
        public PaymentInfoController(IPaymentInfo IPaymentInfo)
        {
            _IPaymentInfo = IPaymentInfo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentInfo>>> Get()
        {
            return await Task.FromResult(_IPaymentInfo.GetAllPaymentInfo());
        }

        [HttpPost]
        public async Task<ActionResult<PaymentInfo>> Post(PaymentInfo paymentInfo)
        {
            _IPaymentInfo.AddPayment(paymentInfo);
            return await Task.FromResult(paymentInfo);
        }

        [HttpGet("Studentinfoby{id}")]
        public async Task<ActionResult<IEnumerable<PaymentInfo>>> GetStudentbyId(string id)
        {
            var infobyID = await _IPaymentInfo.GetStudentInfoByStudentId(id);
            if (infobyID == null)
            {
                return NotFound();
            }
            return Ok(infobyID);
        }
        [HttpGet("Paymentinfoby{id}")]
        public async Task<ActionResult<IEnumerable<PaymentInfo>>> GetPaymentbyId(string id)
        {
            var infobyID =  _IPaymentInfo.GetPaymentInfoByStudentId(id);
            if (infobyID == null)
            {
                return NotFound();
            }
            return Ok(infobyID);
        }

        [HttpGet("PaymentbyInvoice/{id}")]
        public ActionResult<PaymentInfo> GetPaymentbyInvoice(string id)
        {
            var infobyID = _IPaymentInfo.GetPaymentInfoByInvoice(id);
            if (infobyID == null)
            {
                return NotFound();
            }
            return Ok(infobyID);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentInfo>> Delete(int id)
        {
            var student = _IPaymentInfo.DeletePaymentHistory(id);
            return await Task.FromResult(student);
        }
    }
}
