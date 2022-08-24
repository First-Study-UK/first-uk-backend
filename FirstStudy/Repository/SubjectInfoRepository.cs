using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;

namespace FirstStudy.Repository
{
    public class SubjectInfoRepository : ISubjectInfo
    {
        readonly DatabaseContext _dbContext = new();
        public SubjectInfoRepository(DatabaseContext dbContext)
        {
            _dbContext=dbContext;
        }
        public void AddSubject(SubjectInfo subjectInfo)
        {
            try
            {
                _dbContext.SubjectInfo.Add(subjectInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddSubSubject(SubSubjectInfo subSubjectInfo)
        {
            try
            {
                _dbContext.SubSubjectInfo.Add(subSubjectInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<SubjectInfo> GetAllSubject()
        {
            try
            {
                return _dbContext.SubjectInfo.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
