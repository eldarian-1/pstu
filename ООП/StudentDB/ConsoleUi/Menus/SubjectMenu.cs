using Dialog;
using System;
using Controller;
using System.Linq;
using Model.Entities;
using System.Collections.Generic;

namespace ConsoleUi.Menus
{
    class SubjectMenu : IMenu
    {
        private Mediator _Mediator;
        private IList<Action> _Tasks;
        private IList<Exception> _Reactions;

        public SubjectMenu(Mediator mediator)
        {
            _Mediator = mediator;
            _Tasks = new List<Action>().Append(Output, Select, Insert, Update, Delete);
            _Reactions = new List<Exception>();
        }

        public string Menu
            => "Дисциплины\n" +
            "1. Вывести\n" +
            "2. Поиск по ID\n" +
            "3. Добавление\n" +
            "4. Обновление\n" +
            "5. Удаление\n" +
            "0. Назад\n";

        public IList<Action> Tasks => _Tasks;

        public IList<Exception> Reactions => _Reactions;

        private void Output()
        {
            string result = "";
            foreach (var item in _Mediator.Subjects)
                result += item + "\n";
            MenuManager.Write(result);
        }

        private void Select()
        {
            Input.ReadNum(out int id, "Введите id: ");
            MenuManager.Write(_Mediator.Subjects.Where(item => item.SubjectId == id).ToList()[0].ToString());
        }

        private void Insert()
        {
            Input.ReadWord(out string name, "Введите наименование: ");
            _Mediator.AddSubject(name);
        }

        private void Update()
        {
            Input.ReadNum(out int id, "Введите id: ");
            Input.ReadWord(out string name, "Введите наименование: ");
            _Mediator.UpdateSubject(new Subject { SubjectId = id, SubjectName = name });
        }

        private void Delete()
        {
            Input.ReadNum(out int id, "Введите id: ");
            _Mediator.RemoveSubject(_Mediator.Subjects.Where(item => item.SubjectId == id).ToList()[0]);
        }
    }
}
