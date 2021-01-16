using Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF
{
    [Table("marks")]
    class EfMark : Mark
    {
        [Key]
        [Column("mark_id")]
        public override long MarkId => throw new NotImplementedException();

        [Column("student_id")]
        public override long StudentId => throw new NotImplementedException();

        [Column("subject_id")]
        public override long SubjectId => throw new NotImplementedException();

        [Column("value")]
        public override byte Value => throw new NotImplementedException();
    }
}
