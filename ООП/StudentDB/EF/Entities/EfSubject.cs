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
            Name = subject.Name;
        }

        [Key]
        [Column("subject_id")]
        public override long SubjectId { get; set; }

        [Column("name")]
        public override string Name { get; set; }
    }
}
