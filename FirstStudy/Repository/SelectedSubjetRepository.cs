using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;

namespace FirstStudy.Repository
{
    public class SelectedSubjetRepository : ISelectedSubject
    {
        readonly DatabaseContext _dbContext = new();
        public SelectedSubjetRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSelectedSubject(SelectedSubject selectedSubject)
        {
            try
            {
                _dbContext.SelectedSubject.Add(selectedSubject);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
