using Dialog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUi.Menus
{
    internal class MainMenu : IMenu
    {
        private Mediator _Mediator;
        private IList<Action> _Tasks;
        private IList<Exception> _Reactions;

        public MainMenu(Mediator mediator)
        {
            _Mediator = mediator;
            _Tasks = new List<Action>().Append(Subjects, Students, Marks, SetProvider);
            _Reactions = new List<Exception>();
        }

        public string Menu
            => "Главное меню\n" +
            "1. Дисциплины\n" +
            "2. Студенты\n" +
            "3. Оценки\n" +
            "4. Установить провайдер (сейчас " + _Mediator.Key + ")\n" +
            "0. Выход\n";

        public IList<Action> Tasks => _Tasks;

        public IList<Exception> Reactions => _Reactions;

        private void Subjects()
        {
            MenuManager.Instance.Run(new SubjectMenu(_Mediator));
        }

        private void Students()
        {
            MenuManager.Instance.Run(new StudentMenu(_Mediator));
        }

        private void Marks()
        {
            MenuManager.Instance.Run(new MarkMenu(_Mediator));
        }

        private void SetProvider()
        {
            int i = 0;
            string text = "";
            var providers = _Mediator.GetUseCase();
            foreach (var item in providers)
                text += i++ + ". " + item + "\n";
            Input.ReadNum(out int index, text + "Введите индекс провайдера: ");
            _Mediator.SetUseCase(providers.ToList()[index]);
        }
    }
}
