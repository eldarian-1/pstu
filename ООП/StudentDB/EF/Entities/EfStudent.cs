using Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    [Table("students")]
    internal class EfStudent : Student
    {
        public EfStudent(Student student)
        {
            StudentId = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;
        }

        [Key]
        [Column("student_id")]
        public override long StudentId { get; set; }

        [Column("first_name")]
        public override string FirstName { get; set; }

        [Column("last_name")]
        public override string LastName { get; set; }
    }
}
