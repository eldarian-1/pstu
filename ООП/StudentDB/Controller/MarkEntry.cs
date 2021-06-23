using System.Linq;
using Model.Entities;

namespace Controller
{
    public class MarkEntry : Mark
    {
        private IMediator _Mediator;

        public MarkEntry(Mark mark, IMediator mediator)
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
                .Select(subject => subject.ToString())
                .ToArray()[0];
        }

        public string StudentDescription
        {
            get => _Mediator.Students
                .Where(student => student.StudentId == StudentId)
                .Select(student => student.ToString())
                .ToArray()[0];
        }

        public override string ToString()
        {
            return MarkId + ". " + StudentDescription + " | " + SubjectDescription + " : " + MarkValue;
        }
    }
}
