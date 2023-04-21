using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLSIS_CQ.Database
{
    public class SIDB: DbContext
    {
        public SIDB(DbContextOptions<SIDB> options) : base(options) { }
        public DbSet<Student> students { get; set; }
        public DbSet<Counselor> counselors { get; set; }
        public DbSet<GeneralClass> classes { get; set; }

    }
    public class Student
    {
        [Key] public string student_id { get; set; }
        public string student_name { get; set; }
        public string graduation_year { get; set; }
        public string student_class { get; set; }
    }
    public class Counselor
    {
        [Key] public string counselor_name { get; set;}
        public CounselorType counselor_type { get; set; }
        [Column (TypeName = "jsonb")] public List<string> classes { get; set; } = new List<string> ();
    }
    public enum CounselorType
    {
        GeneralCounselor = 0,
        Counselor = 1,
        CounselorAssistant = 2
    }
    public class GeneralClass
    {
        [Key] public string class_name { get; set; }
        public string counselor_name { get; set; }
        public string counselor_asistant_name { get; set; }
        [Column (TypeName = "jsonb")] public List<string> students { get; set; } = new List<string>();
    }
}