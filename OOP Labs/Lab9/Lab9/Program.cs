using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        private const string Tasks =
               "МЕНЮ ЗАДАЧ\n" +
               "Money\n" +
               "\t1. Добавить объект в список\n" +
               "\t2. Удалить первый объект из списка\n" +
               "\t3. Сравнение двух первых объектов в списке\n" +
               "\t4. Инкрементировать первый объект\n" +
               "\t5. Декрементировать первый объект\n" +
               "\t6. Привести первый объект неявно к int\n" +
               "\t7. Привести первый объект явно к double\n" +
               "\t8. Вычесть int (копейки) из Money (=> Money)\n" +
               "\t9. Вычесть Money из int (копейки) (=> Money)\n" +
               "\t10. Вывести количество созданных объектов\n" +
               "\t11. Вывести список объектов\n" +
               "MoneyArray\n" +
               "\t12. Создать и вывести\n" +
               "\t13. Найти минимальное значение\n" +
               "0. Выход\n" +
               "Выберете действие: ";

        private const string Compares =
               "МЕНЮ ОПЕРАЦИЙ\n" +
               "1. Меньше\n" +
               "2. Меньше или равно\n" +
               "3. Больше\n" +
               "4. Больше или равно\n" +
               "5. Равно\n" +
               "6. Не равно\n" +
               "0. Назад\n" +
               "Выберете операцию: ";

        private static CLIObject Obj;
        private static List<Money> St;
        private static MoneyArray Ar;

        static void Main(string[] args)
        {
            Obj = new CLIObject(Tasks, AddStack, PopStack,
                Compare, Increment, Decrement, ToInt, ToDouble, MoneyInt,
                IntMoney, ElemCount, EnterElems, CreateEnter, FindMinimum);
            St = new List<Money>();
            Obj.Run();
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

        static void Compare()
        {
            if(St.Count < 2)
            {
                Console.WriteLine("Слишком мало элементов в стеке\n");
                return;
            }
            Console.WriteLine();
            Obj.Run(Compares, OperatitonLess, OperatitonLessEq,
                OperatitonOver, OperatitonOverEq, OperatitonEq, OperatitonNEq);
        }

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
            CLI.Result(Ar.Minimum);
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
    }
}
