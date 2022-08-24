using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStudy.Controllers
{
    [Route("api/dashSidebardetails")]
    [ApiController]
    public class DashSidebarDetailsController : ControllerBase
    {
        private readonly IDashSidebarDetails _IDashSidebarDetails;
        public DashSidebarDetailsController(IDashSidebarDetails iDashSidebarDetails)
        {
            _IDashSidebarDetails = iDashSidebarDetails;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashSidebarDetails>>> Get()
        {
            return await Task.FromResult(_IDashSidebarDetails.GetAllAddSidebarDetails());
        }

        [HttpPost]
        public async Task<ActionResult<DashSidebarDetails>> Post(DashSidebarDetails dashSidebarDetails)
        {
            _IDashSidebarDetails.AddSidebarDetails(dashSidebarDetails);
            return await Task.FromResult(dashSidebarDetails);
        }

        [HttpGet("GetAllDashboardDues")]
        public ActionResult<IEnumerable<DashboardDuesDto>> GetAllDashboardDues()
        {
            var dues = _IDashSidebarDetails.GetAllDashboardDues();
            return Ok(dues);
        }
    }
}
