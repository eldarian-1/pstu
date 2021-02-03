using Model.Entities;
using System.Collections.Generic;

namespace Controller
{
    public interface IMediator
    {
        IEnumerable<Subject> Subjects { get; }

        IEnumerable<Student> Students { get; }

        IEnumerable<MarkEntry> Marks { get; }
    }
}
