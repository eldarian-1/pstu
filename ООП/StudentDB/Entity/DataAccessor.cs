﻿using Model.Entities;

namespace Model
{
    public class DataAccessor
    {
        private IOperateable _Current;

        public IOperateable Current
        {
            get => _Current;
            set
            {
                _Current = value;
                Subjects = new Requester<Subject>(value);
                Students = new Requester<Student>(value);
                Marks = new Requester<MarkEntry>(value);
            }
        }

        public IQueryable<Subject> Subjects { get; private set; }

        public IQueryable<Student> Students { get; private set; }

        public IQueryable<MarkEntry> Marks { get; private set; }
    }
}
