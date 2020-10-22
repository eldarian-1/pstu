using System;
using System.Collections.Generic;

namespace Lab9
{
    static class Program
    {
        private const string c_sEnterIndex = "Введите индекс: ";
        private const string c_sEnterRuble = "Введите рубли: ";
        private const string c_sEnterPenny = "Введите копейки: ";
        private const string c_sValue = "значение";
        private const string c_sNewValue = "новое значение";
        private const string c_sMoneyArray = "MoneyArray";
        private const string c_sThanksForJob = "Спасибо за работу!";

        private const string c_sMainMenu =
               "Главное меню\n" +
               "1. Money (1 и 2 части)\n" +
               "2. MoneyArray (3 часть)\n" +
               "0. Выход\n" +
               "Выберете действие: ";

        private const string c_sMoneyMenu =
               "Меню Money\n" +
               "1. Добавить объект в список\n" +
               "2. Удалить первый объект из списка\n" +
               "3. Сравнение двух первых объектов в списке (1 часть)\n" +
               "4. Операции над первым объектом в списке (2 часть)\n" +
               "5. Вывести количество созданных объектов\n" +
               "6. Вывести список объектов\n" +
               "0. Назад\n" +
               "Выберете действие: ";

        private const string c_sFirstPart =
               "МЕНЮ ОПЕРАЦИЙ\n" +
               "1. Меньше\n" +
               "2. Меньше или равно\n" +
               "3. Больше\n" +
               "4. Больше или равно\n" +
               "5. Равно\n" +
               "6. Не равно\n" +
               "0. Назад\n" +
               "Выберете операцию: ";

        private const string c_sSecondPart =
               "Меню Money (2 часть)\n" +
               "1. Инкрементировать первый объект\n" +
               "2. Декрементировать первый объект\n" +
               "3. Привести первый объект неявно к int\n" +
               "4. Привести первый объект явно к double\n" +
               "5. Вычесть int (копейки) из Money (=> Money)\n" +
               "6. Вычесть Money из int (копейки) (=> Money)\n" +
               "0. Назад\n" +
               "Выберете действие: ";

        private const string c_sThirdPart =
               "Меню MoneyArray\n" +
               "1. Создать массив\n" +
               "2. Вывести массив\n" +
               "3. Посмотреть значение по индексу\n" +
               "4. Обновить значение по индексу\n" +
               "5. Найти минимальное значение\n" +
               "0. Назад\n" +
               "Выберете действие: ";

        private static CLIObject Obj;
        private static List<Money> St;
        private static MoneyArray Ar;

        static void Main(string[] args)
        {
            Obj = new CLIObject(c_sMainMenu, MoneyMenu, ThirdPart);
            St = new List<Money>();
            Obj.Run();
            Console.WriteLine(c_sThanksForJob);
            Console.ReadKey();
        }

        static void MoneyMenu()
        {
            Console.WriteLine();
            Obj.Run(c_sMoneyMenu, AddStack, PopStack,
                FirstPart, SecondPart, ElemCount, EnterElems);
        }

        static void FirstPart()
        {
            if (St.Count < 2)
                throw new InvalidOperationException();
            Console.WriteLine();
            Obj.Run(c_sFirstPart, OperatitonLess, OperatitonLessEq,
                OperatitonOver, OperatitonOverEq, OperatitonEq, OperatitonNEq);
        }

        static void SecondPart()
        {
            if (St.Count == 0)
                throw new InvalidOperationException();
            Console.WriteLine();
            Obj.Run(c_sSecondPart, Increment, Decrement,
                ToInt, ToDouble, MoneyInt, IntMoney);
        }

        static void ThirdPart()
        {
            Console.WriteLine();
            Obj.Run(c_sThirdPart, CreateArray, OutputArray, OutputByIndex, UpdateByIndex, FindMinimum);
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
            CLI.GetValid(out int num, CLI.GetMode(), Core.IsValidNum, c_sEnterPenny);
            CLI.Result($"{St[0]} - {num}к = {St[0] - num}");
        }

        static void IntMoney()
        {
            CLI.GetValid(out int num, CLI.GetMode(), Core.IsValidNum, c_sEnterPenny);
            CLI.Result($"{num}к - {St[0]} = {num - St[0]}");
        }

        static void ElemCount()
            => CLI.Result(Money.Count);

        static void EnterElems()
        {
            if (St.Count == 0)
                throw new ArgumentNullException();
            CLI.Result(new MoneyArray(St.ToArray()));
        }

        static void CreateArray()
        {
            Ar = Obj.GetMoneyArray(CLI.GetMode());
            OutputArray();
        }

        static void OutputArray()
        {
            if (Ar == null)
                throw new ArgumentNullException();
            CLI.Result(Ar);
        }

        static void OutputByIndex()
        {
            if (Ar == null)
                throw new ArgumentNullException();
            CLI.GetValid(out int index, CLI.ReadNum, Core.IsValidNum, c_sEnterIndex);
            CLI.Result($"{c_sValue} {c_sMoneyArray}[{index}] == {Ar[index]}");
        }

        static void UpdateByIndex()
        {
            if (Ar == null)
                throw new ArgumentNullException();
            CLI.GetValid(out int index, CLI.ReadNum, Core.IsValidNum, c_sEnterIndex);
            Ar[index] = null;
            GetNumber GetNum = CLI.GetMode();
            CLI.GetValid(out int ruble, GetNum, Core.IsValidRuble, c_sEnterRuble);
            CLI.GetValid(out int penny, GetNum, Core.IsValidPenny, c_sEnterPenny);
            Ar[index] = new Money(ruble, penny);
            CLI.Result($"{c_sNewValue} {c_sMoneyArray}[{index}] == {Ar[index]}");
        }

        static void FindMinimum()
        {
            if (Ar == null)
                throw new ArgumentNullException();
            Core.MinimumMoneyArray(Ar, out int index, out Money money);
            CLI.Result(index, money);
        }
    }
}
