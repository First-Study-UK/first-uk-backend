using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;

namespace FirstStudy.Repository
{
    public class DashSidebarDetailsRepository : IDashSidebarDetails
    {
        readonly DatabaseContext _dbContext = new();
        public DashSidebarDetailsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSidebarDetails(DashSidebarDetails dashSidebarDetails)
        {
            try
            {
                _dbContext.DashSidebarDetails.Add(dashSidebarDetails);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<DashSidebarDetails> GetAllAddSidebarDetails()
        {
            try
            {
                return _dbContext.DashSidebarDetails.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IList<DashboardDuesDto> GetAllDashboardDues()
        {
            try
            {
                return _dbContext.DashboardDues.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
