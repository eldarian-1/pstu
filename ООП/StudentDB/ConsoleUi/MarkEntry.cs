using System.Linq;
using Model.Entities;

namespace ConsoleUi
{
    public class MarkEntry : Mark
    {
        private Mediator _Mediator;

        public MarkEntry(Mark mark, Mediator mediator)
        {
            MarkId = mark.MarkId;
            SubjectId = mark.SubjectId;
            StudentId = mark.StudentId;
            MarkValue = mark.MarkValue;
            _Mediator = mediator;
        }

        public string SubjectDescription
        {
            get => _Mediator.Subjects
                .Where(subject => subject.SubjectId == SubjectId)
                .Select(subject => subject.SubjectId + ". " + subject.SubjectName)
                .ToArray()[0];
        }

        public string StudentDescription
        {
            get => _Mediator.Students
                .Where(student => student.StudentId == StudentId)
                .Select(student => student.StudentId + ". " + student.FirstName + " " + student.LastName)
                .ToArray()[0];
        }
    }
}
