using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface ISubjectInfo
    {
        public void AddSubject(SubjectInfo subjectInfo);
        public void AddSubSubject(SubSubjectInfo subSubjectInfo);
        public List<SubjectInfo> GetAllSubject();

    }
}
