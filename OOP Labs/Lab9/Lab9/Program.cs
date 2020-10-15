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
               "\t8. Привести первый объект int из Money (=> Money)\n" +
               "\t9. Привести первый объект Money из int (=> Money)\n" +
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
        }

        static void PopStack()
        {
            St.RemoveAt(0);
        }

        static void Compare()
        {
            if(St.Count < 2)
            {
                Console.WriteLine("Слишком мало элементов в стеке");
                return;
            }
            Obj.Run(Compares, OperatitonLess, OperatitonLessEq,
                OperatitonOver, OperatitonOverEq, OperatitonEq, OperatitonNEq);
        }

        static void Increment()
        {

        }

        static void Decrement()
        {

        }

        static void ToInt()
        {

        }

        static void ToDouble()
        {

        }

        static void MoneyInt()
        {

        }

        static void IntMoney()
        {

        }

        static void ElemCount()
        {

        }

        static void EnterElems()
        {
            for (int i = 0, n = St.Count; i < n; ++i)
                Console.Write("{0} ", St[i]);
            Console.WriteLine();
        }

        static void CreateEnter()
        {

        }

        static void FindMinimum()
        {

        }

        static void OperatitonLess()
            => Console.WriteLine(St[0] < St[1]);

        static void OperatitonLessEq()
            => Console.WriteLine(St[0] <= St[1]);

        static void OperatitonOver()
            => Console.WriteLine(St[0] > St[1]);

        static void OperatitonOverEq()
            => Console.WriteLine(St[0] >= St[1]);

        static void OperatitonEq()
            => Console.WriteLine(St[0] == St[1]);

        static void OperatitonNEq()
            => Console.WriteLine(St[0] != St[1]);
    }
}
