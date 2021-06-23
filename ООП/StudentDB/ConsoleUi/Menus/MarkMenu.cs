using Dialog;
using System;
using Controller;
using System.Linq;
using Model.Entities;
using System.Collections.Generic;

namespace ConsoleUi.Menus
{
    class MarkMenu : IMenu
    {
        private const int c_Min = 2;
        private const int c_Max = 5;

        private Mediator _Mediator;
        private IList<Action> _Tasks;
        private IList<Exception> _Reactions;

        private Func<int, bool> _Validate = mark => c_Min <= mark && mark <= c_Max;

        public MarkMenu(Mediator mediator)
        {
            _Mediator = mediator;
            _Tasks = new List<Action>().Append(Output, Select, Insert, Update, Delete);
            _Reactions = new List<Exception>();
        }

        public string Menu
            => "Оценки\n" +
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
            foreach (var item in _Mediator.Marks)
                result += item + "\n";
            MenuManager.Write(result);
        }

        private void Select()
        {
            Input.ReadNum(out int id, "Введите id: ");
            MenuManager.Write(_Mediator.Marks.Where(item => item.MarkId == id).ToList()[0].ToString());
        }

        private void Insert()
        {
            string text = "";
            foreach (var item in _Mediator.Students)
                text += item + "\n";
            Input.ReadNum(out int studentId, text + "Введите id студента: ");
            text = "";
            foreach (var item in _Mediator.Subjects)
                text += item + "\n";
            Input.ReadNum(out int subjectId, text + "Введите id дисциплины: ");
            Input.ReadNum(out int value, "Введите оценку: ", _Validate);
            _Mediator.AddMark(studentId, subjectId, (byte)value);
        }

        private void Update()
        {
            Input.ReadNum(out int markId, "Введите id оценки: ");
            Input.ReadNum(out int studentId, "Введите id студента: ");
            Input.ReadNum(out int subjectId, "Введите id предмета: ");
            Input.ReadNum(out int value, "Введите оценку: ", _Validate);
            _Mediator.UpdateMark(new Mark { MarkId = markId, StudentId = studentId, SubjectId = subjectId, MarkValue = (byte)value });
        }

        private void Delete()
        {
            Input.ReadNum(out int id, "Введите id: ");
            _Mediator.RemoveMark(_Mediator.Marks.Where(item => item.MarkId == id).ToList()[0]);
        }
    }
}
