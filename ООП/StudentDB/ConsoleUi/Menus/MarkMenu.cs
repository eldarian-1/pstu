using Dialog;
using System;
using System.Linq;
using Model.Entities;
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
            => "Оценки\n" +
            "1. Вывести\n" +
            "2. Поиск\n" +
            "3. Обновление\n" +
            "4. Удаление\n" +
            "0. Назад\n";

        public IList<Action> Tasks => _Tasks;

        public IList<Exception> Reactions => _Reactions;

        private string MarkToString(MarkEntry mark)
        {
            return mark.MarkId + ". " + mark.SubjectDescription + " " + mark.StudentDescription + " " + mark.MarkValue;
        }

        private void Output()
        {
            string result = "";
            foreach (var item in _Mediator.Marks)
                result += MarkToString(item) + "\n";
            MenuManager.Write(result);
        }

        private void Select()
        {
            Input.ReadNum(out int id, "Введите id: ");
            MenuManager.Write(MarkToString(_Mediator.Marks.Where(item => item.MarkId == id).ToList()[0]));
        }

        private void Update()
        {
            Input.ReadNum(out int markId, "Введите id оценки: ");
            Input.ReadNum(out int studentId, "Введите id студента: ");
            Input.ReadNum(out int subjectId, "Введите id предмета: ");
            Input.ReadNum(out int value, "Введите оценку: ");
            _Mediator.UpdateMark(new Mark { MarkId = markId, StudentId = studentId, SubjectId = subjectId, MarkValue = (byte)value });
        }

        private void Delete()
        {
            Input.ReadNum(out int id, "Введите id: ");
            _Mediator.RemoveMark(_Mediator.Marks.Where(item => item.MarkId == id).ToList()[0]);
        }
    }
}
