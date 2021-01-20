using Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF
{
    [Table("students")]
    class EfStudent : Student
    {
        [Key]
        [Column("student_id")]
        public override long StudentId => throw new System.NotImplementedException();

        [Column("first_name")]
        public override string FirstName => throw new System.NotImplementedException();

        [Column("last_name")]
        public override string LastName => throw new System.NotImplementedException();
    }
}
