using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstStudy.Models
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string Year { get; set; }
        public string ContactPerson1 { get; set; }
        public string EmailPerson1 { get; set; }
        public string MobilePerson1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string EmailPerson2 { get; set; }
        public string MobilePerson2 { get; set; }
        public string Allergies { get; set; }
        public string MedicalDifficulties { get; set; }
        public string LearningDifficulties { get; set; }
        public string StudentImage { get; set; }

        ICollection<SelectedSubject> Subjects { get; set; }
    }
}
