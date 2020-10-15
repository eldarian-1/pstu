using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        private const string MainMenu =
               "Главное меню\n" +
               "1. Money (1 и 2 части)\n" +
               "2. MoneyArray (3 часть)\n" +
               "0. Выход\n" +
               "Выберете действие: ";

        private const string MoneyMenu =
               "Меню Money\n" +
               "1. Добавить объект в список\n" +
               "2. Удалить первый объект из списка\n" +
               "3. Сравнение двух первых объектов в списке (1 часть)\n" +
               "4. Операции над первым объектом в списке (2 часть)\n" +
               "5. Вывести количество созданных объектов\n" +
               "6. Вывести список объектов\n" +
               "0. Назад\n" +
               "Выберете действие: ";

        private const string FirstPart =
               "МЕНЮ ОПЕРАЦИЙ\n" +
               "1. Меньше\n" +
               "2. Меньше или равно\n" +
               "3. Больше\n" +
               "4. Больше или равно\n" +
               "5. Равно\n" +
               "6. Не равно\n" +
               "0. Назад\n" +
               "Выберете операцию: ";

        private const string SecondPart =
               "Меню Money (2 часть)\n" +
               "1. Инкрементировать первый объект\n" +
               "2. Декрементировать первый объект\n" +
               "3. Привести первый объект неявно к int\n" +
               "4. Привести первый объект явно к double\n" +
               "5. Вычесть int (копейки) из Money (=> Money)\n" +
               "6. Вычесть Money из int (копейки) (=> Money)\n" +
               "0. Назад\n" +
               "Выберете действие: ";

        private const string ThirdPart =
               "Меню MoneyArray\n" +
               "1. Создать и вывести\n" +
               "2. Найти минимальное значение\n" +
               "0. Назад\n" +
               "Выберете действие: ";

        private static CLIObject Obj;
        private static List<Money> St;
        private static MoneyArray Ar;

        static void Main(string[] args)
        {
            Obj = new CLIObject(MainMenu, MenuMoney, ArrayOperation);
            St = new List<Money>();
            Obj.Run();
            Console.WriteLine("Спасибо за работу!");
            Console.ReadKey();
        }

        static void MenuMoney()
        {
            Console.WriteLine();
            Obj.Run(MoneyMenu, AddStack, PopStack,
                Compare, MoneyOperation, ElemCount, EnterElems);
        }

        static void Compare()
        {
            if (St.Count < 2)
                throw new InvalidOperationException();
            Console.WriteLine();
            Obj.Run(FirstPart, OperatitonLess, OperatitonLessEq,
                OperatitonOver, OperatitonOverEq, OperatitonEq, OperatitonNEq);
        }

        static void MoneyOperation()
        {
            if (St.Count == 0)
                throw new InvalidOperationException();
            Console.WriteLine();
            Obj.Run(SecondPart, Increment, Decrement,
                ToInt, ToDouble, MoneyInt, IntMoney);
        }

        static void ArrayOperation()
        {
            Console.WriteLine();
            Obj.Run(ThirdPart, CreateEnter, FindMinimum);
        }

        static void AddStack()
        {
            St.Add(Obj.GetMoney(CLI.GetMode()));
            Console.WriteLine();
        }

        static void PopStack()
        {
            St.RemoveAt(0);
            Console.WriteLine();
        }

        static void OperatitonLess()
            => CLI.Result(St[0] < St[1]);

        static void OperatitonLessEq()
            => CLI.Result(St[0] <= St[1]);

        static void OperatitonOver()
            => CLI.Result(St[0] > St[1]);

        static void OperatitonOverEq()
            => CLI.Result(St[0] >= St[1]);

        static void OperatitonEq()
            => CLI.Result(St[0] == St[1]);

        static void OperatitonNEq()
            => CLI.Result(St[0] != St[1]);

        static void Increment()
            => CLI.Result(++St[0]);

        static void Decrement()
            => CLI.Result(--St[0]);

        static void ToInt()
        {
            int money = St[0];
            CLI.Result(money);
        }

        static void ToDouble()
            => CLI.Result((double)St[0]);

        static void MoneyInt()
        {
            CLI.GetMode()(out int num, "Введите число: ");
            CLI.Result($"{St[0]} - {num} = {St[0] - num}");
        }

        static void IntMoney()
        {
            CLI.GetMode()(out int num, "Введите число: ");
            CLI.Result($"{num} - {St[0]} = {num - St[0]}");
        }

        static void ElemCount()
            => CLI.Result(Money.Count);

        static void EnterElems()
            => CLI.Result(new MoneyArray(St.ToArray()));

        static void CreateEnter()
        {
            Ar = Obj.GetMoneyArray(CLI.GetMode());
            CLI.Result(Ar);
        }

        static void FindMinimum()
        {
            if (Ar == null)
                return;
            Ar.Minimum(out int index, out Money money);
            CLI.Result(index, money);
        }
    }
}
