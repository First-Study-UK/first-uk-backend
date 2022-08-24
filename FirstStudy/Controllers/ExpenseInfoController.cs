using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStudy.Controllers
{
    [Route("api/expenseinfo")]
    [ApiController]
    public class ExpenseInfoController : ControllerBase
    {
        private readonly IExpenseInfo _IExpenseInfo;

        public ExpenseInfoController(IExpenseInfo iExpenseInfo)
        {
            _IExpenseInfo = iExpenseInfo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseInfo>>> Get()
        {
            return await Task.FromResult(_IExpenseInfo.GetAllExpenseInfo());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExpenseInfo>>> GetbyId(int id)
        {
            var infobyID = await _IExpenseInfo.GetExpenseInfoById(id);
            if (infobyID == null)
            {
                return NotFound();
            }
            return Ok(infobyID);
        }
        [HttpPost]
        public async Task<ActionResult<ExpenseInfo>> Post(ExpenseInfo expenseInfo)
        {
            _IExpenseInfo.AddExpenseInfo(expenseInfo);
            return await Task.FromResult(expenseInfo);
        }
    }
}
