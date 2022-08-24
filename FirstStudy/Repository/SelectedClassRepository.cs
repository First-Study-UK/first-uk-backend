using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;

namespace FirstStudy.Repository
{
    public class SelectedClassRepository:ISelectedClass
    {
        readonly DatabaseContext _dbContext = new();
        public SelectedClassRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSelectedSubject(SelectedClass selectedClass)
        {
            try
            {
                _dbContext.SelectedClass.Add(selectedClass);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
