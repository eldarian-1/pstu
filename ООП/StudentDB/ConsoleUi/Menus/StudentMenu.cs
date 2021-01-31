using Dialog;
using System;
using System.Linq;
using Model.Entities;
using System.Collections.Generic;

namespace ConsoleUi.Menus
{
    class StudentMenu : IMenu
    {
        private Mediator _Mediator;
        private IList<Action> _Tasks;
        private IList<Exception> _Reactions;

        public StudentMenu(Mediator mediator)
        {
            _Mediator = mediator;
            _Tasks = new List<Action>().Append(Output, Select, Insert, Update, Delete);
            _Reactions = new List<Exception>();
        }

        public string Menu
            => "Студенты\n" +
            "1. Вывести\n" +
            "2. Поиск по ID\n" +
            "3. Добавление\n" +
            "4. Обновление\n" +
            "5. Удаление\n" +
            "0. Назад\n";

        public IList<Action> Tasks => _Tasks;

        public IList<Exception> Reactions => _Reactions;

        private string StudentToString(Student student)
        {
            return student.StudentId + ". " + student.FirstName + " " + student.LastName;
        }

        private void Output()
        {
            string result = "";
            foreach (var item in _Mediator.Students)
                result += StudentToString(item) + "\n";
            MenuManager.Write(result);
        }

        private void Select()
        {
            Input.ReadNum(out int id, "Введите id: ");
            MenuManager.Write(StudentToString(_Mediator.Students.Where(item => item.StudentId == id).ToList()[0]));
        }

        private void Insert()
        {
            Input.ReadWord(out string firstName, "Введите имя: ");
            Input.ReadWord(out string lastName, "Введите фамилию: ");
            _Mediator.AddStudent(firstName, lastName);
        }

        private void Update()
        {
            Input.ReadNum(out int id, "Введите id: ");
            Input.ReadWord(out string firstName, "Введите имя: ");
            Input.ReadWord(out string lastName, "Введите фамилию: ");
            _Mediator.UpdateStudent(new Student { StudentId = id, FirstName = firstName, LastName = lastName });
        }

        private void Delete()
        {
            Input.ReadNum(out int id, "Введите id: ");
            _Mediator.RemoveStudent(_Mediator.Students.Where(item => item.StudentId == id).ToList()[0]);
        }
    }
}
