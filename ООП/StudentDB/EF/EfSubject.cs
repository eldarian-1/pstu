using Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF
{
    [Table("subjects")]
    class EfSubject : Subject
    {
        [Key]
        [Column("subject_id")]
        public override long SubjectId => throw new NotImplementedException();

        [Column("name")]
        public override string Name => throw new NotImplementedException();
    }
}
