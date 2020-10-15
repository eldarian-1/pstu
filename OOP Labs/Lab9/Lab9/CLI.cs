using System;

namespace Lab9
{
    static class CLI
    {
        private const string c_sCount = "Количество элементов";
        private const string c_sRuble = "Рубли: ";
        private const string c_sPenny = "Копейки: ";
        private const string c_sReadNumber = "{0}) {1}";
        private const string c_sResult = "Результат: {0}\n";
        private const string c_sMinimum = "Минимум: Array[{0}] == {1}\n";
        private const string c_sIncorrectlyValue = "Некорректное значение!\n";
        private const string c_sInvalidArgument = "Некорректные аргументы!\n";
        private const string c_sInvalidOperation = "Некорректная операция!\n";
        private const string c_sEmptyArray = "Массив пуст.\n";
        private const string c_sException = "Неизвестная ошибка!\n";
        private const string c_sModus =
            "Введите способ получения чисел (1 - ввод, - 2 случайное): ";

        public static void IncorrectValue()
            => Console.WriteLine(c_sIncorrectlyValue);

        public static void Result<T>(T arg)
            => Console.WriteLine(c_sResult, arg);

        public static void Result<T, P>(T arg1, P arg2)
            => Console.WriteLine(c_sMinimum, arg1, arg2);

        public static void ReadNum(out int number, string thing, int i = -1)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                if (i == -1)
                    Console.Write(thing);
                else
                    Console.Write(c_sReadNumber, i, thing);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
                if (!flag)
                    IncorrectValue();
            }
        }

        public static void RandNum(out int number, string thing, int i)
        {
            if (thing == c_sCount)
                number = Core.Rand.Next(Core.MinArray, Core.MaxArray);
            else if (thing == c_sRuble)
                number = Core.Rand.Next(0, Core.MaxRubles);
            else
                number = Core.Rand.Next(0, Core.MaxPennies);
        }

        public static GetNumber GetMode()
        {
            string key = "";
            do
            {
                Console.Write(c_sModus);
                key = Console.ReadLine();
            } while (key != "1" && key != "2");
            if (key == "1")
                return ReadNum;
            else
                return RandNum;
        }

        public static void GetValid(out int number, GetNumber GetNum, IsValidate IsValid, string thing, int i = -1)
        {
            while (true)
            {
                GetNum(out number, thing);
                if (IsValid(number))
                    break;
                else
                    IncorrectValue();
            }
        }

        public static int GetValidNum(GetNumber GetNum, string text)
        {
            GetValid(out int num, GetNum, Core.IsValidNum, text);
            return num;
        }

        public static Money GetMoney(GetNumber GetNum, int i = -1)
        {
            GetValid(out int ruble, GetNum, Core.IsValidRuble, c_sRuble, i);
            GetValid(out int penny, GetNum, Core.IsValidPenny, c_sPenny, i);
            return new Money(ruble, penny);
        }

        public static void Run(GetTask task)
        {
            while (true)
            {
                try
                {
                    task()();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(c_sEmptyArray);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(c_sInvalidArgument);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine(c_sInvalidOperation);
                }
                catch (ApplicationException)
                {
                    break;
                }              
                catch (Exception)
                {
                    Console.WriteLine(c_sException);
                }
            }
        }
    }
}
