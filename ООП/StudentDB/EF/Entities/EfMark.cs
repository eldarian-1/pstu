using Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    [Table("marks")]
    internal class EfMark : Mark, IEntity<Mark, EfMark>
    {
        public EfMark() : base() { }

        public EfMark(Mark mark)
        {
            MarkId = mark.MarkId;
            StudentId = mark.StudentId;
            SubjectId = mark.SubjectId;
            MarkValue = mark.MarkValue;
        }

        [Key]
        [Column("mark_id")]
        public override long MarkId { get; set; }

        [Column("student_id")]
        public override long StudentId { get; set; }

        [Column("subject_id")]
        public override long SubjectId { get; set; }

        [Column("mark_value")]
        public override byte MarkValue { get; set; }

        public long Identificator() => MarkId;

        public EfMark Update(EfMark entity)
        {
            StudentId = entity.StudentId;
            SubjectId = entity.SubjectId;
            MarkValue = entity.MarkValue;
            return this;
        }
    }
}
