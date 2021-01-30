using Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    [Table("subjects")]
    internal class EfSubject : Subject
    {
        public EfSubject(Subject subject)
        {
            SubjectId = subject.SubjectId;
            SubjectName = subject.SubjectName;
        }

        [Key]
        [Column("subject_id")]
        public override long SubjectId { get; set; }

        [Column("subject_name")]
        public override string SubjectName { get; set; }
    }
}
