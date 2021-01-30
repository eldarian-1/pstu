using Dialog;
using System;
using System.Collections.Generic;

namespace ConsoleUi.Menus
{
    class MarkMenu : IMenu
    {
        private Mediator _Mediator;
        private IList<Action> _Tasks;
        private IList<Exception> _Reactions;

        public MarkMenu(Mediator mediator)
        {
            _Mediator = mediator;
            _Tasks = new List<Action>().Append(Output, Select, Update, Delete);
            _Reactions = new List<Exception>();
        }

        public string Menu
            => "Главное меню\n" +
            "1. Дисциплины\n" +
            "2. Студенты\n" +
            "3. Оценки\n" +
            "0. Выход\n";

        public IList<Action> Tasks => _Tasks;

        public IList<Exception> Reactions => _Reactions;

        public void Output()
        {
            string result = "";
            foreach (var item in _Mediator.Marks)
                result += item.MarkId + ". " + item.SubjectId + " " + item.StudentId + " " + item.MarkValue + "\n";
            MenuManager.Write(result);
        }

        public void Select()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
