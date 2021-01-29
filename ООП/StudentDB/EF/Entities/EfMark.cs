using Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    [Table("marks")]
    internal class EfMark : Mark
    {
        public EfMark(Mark mark)
        {
            MarkId = mark.MarkId;
            StudentId = mark.StudentId;
            SubjectId = mark.SubjectId;
            Value = mark.Value;
        }

        [Key]
        [Column("mark_id")]
        public override long MarkId { get; set; }

        [Column("student_id")]
        public override long StudentId { get; set; }

        [Column("subject_id")]
        public override long SubjectId { get; set; }

        [Column("value")]
        public override byte Value { get; set; }
    }
}
