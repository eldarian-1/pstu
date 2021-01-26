using System.Linq;
using Model.Entities;

namespace WpfUi.Wrappers
{
    class MarkEntry : Mark
    {
        private MainWindow _Main;

        public MarkEntry(Mark mark, MainWindow main)
        {
            MarkId = mark.MarkId;
            SubjectId = mark.SubjectId;
            StudentId = mark.StudentId;
            Value = mark.Value;
            _Main = main;
        }

        public string SubjectDescription
        {
            get => _Main.Subjects
                .Where(subject => subject.SubjectId == SubjectId)
                .Select(subject => subject.SubjectId + ". " + subject.Name)
                .ToArray()[0];
        }

        public string StudentDescription
        {
            get => _Main.Students
                .Where(student => student.StudentId == StudentId)
                .Select(student => student.StudentId + ". " + student.FirstName + " " + student.LastName)
                .ToArray()[0];
        }
    }
}
