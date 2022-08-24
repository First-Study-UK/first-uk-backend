using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstStudy.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public StudentInfo StudentInfo { get; set; }
        public List<SelectedSubject> SelectedSubject { get; set; }
    }
}
