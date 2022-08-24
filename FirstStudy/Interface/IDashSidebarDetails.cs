using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface IDashSidebarDetails
    {
        public void AddSidebarDetails(DashSidebarDetails dashSidebarDetails);
        public List<DashSidebarDetails> GetAllAddSidebarDetails();
        public IList<DashboardDuesDto> GetAllDashboardDues();
    }
}
