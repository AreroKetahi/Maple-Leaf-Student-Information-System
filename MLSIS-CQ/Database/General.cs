using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MLSIS_CQ.Database
{
    public class SIDB: DbContext
    {
        public SIDB(DbContextOptions<SIDB> options) : base(options) { }
        public DbSet<Student> students { get; set; }

    }
    public class Student
    {
        [Key] public string student_id { get; set; }
        public string student_name { get; set; }
        public string student_class { get; set;}
        public string student_dorm { get; set; }
    }
    public class Class
    {
        public string graduate_year { get; set; }
        [Column (TypeName = "jsonb")]
        public List<string> students { get; set; } = new List<string>();
    }
}
