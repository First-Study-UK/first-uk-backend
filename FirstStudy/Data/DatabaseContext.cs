using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Data
{
    public partial class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<StudentInfo> StudentInfo { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfo { get; set; }
        public virtual DbSet<SubjectInfo> SubjectInfo { get; set; }
        public virtual DbSet<SubSubjectInfo> SubSubjectInfo { get; set; }
        public virtual DbSet<YearInfo> YearInfo { get; set; }
        public virtual DbSet<YearGroupInfo> YearGroupInfo { get; set; }
        public virtual DbSet<RegisterInfo> RegisterInfo { get; set; }
        public virtual DbSet<PaymentInfo> PaymentInfo { get; set; }
        public virtual DbSet<ExpenseInfo> ExpenseInfo { get; set; }
        public virtual DbSet<SelectedSubject> SelectedSubject { get; set; }
        public virtual DbSet<SelectedClass> SelectedClass { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<DashSidebarDetails> DashSidebarDetails { get; set; }
        public virtual DbSet<DashboardDuesDto> DashboardDues { get; set; }
        public virtual DbSet<TeacherTimetableViewModel> TeacherTimetables { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DashboardDuesDto>(eb => {
                   eb.HasNoKey();
                   eb.ToView("DashboardDues");
               });

            builder.Entity<TeacherTimetableViewModel>(eb => {
                eb.HasNoKey();
                eb.ToView("TeacherTimetables");
            });
        }

    }
}
