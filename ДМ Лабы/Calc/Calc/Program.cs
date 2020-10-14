using System;

namespace Calc
{
    delegate void Task();
    delegate void GetNumber(out int number, char simbol, int i = -1);
    delegate GetNumber ModeGetNumber();
    delegate bool IsValidate(int x, int top);

    class NullArrayException : Exception { }
    class NullFunctionException : Exception { }

    class Program
    {
        public const char c_cA = 'A';
        public const char c_cB = 'B';
        public const char c_ca = 'a';
        public const char c_cb = 'b';
        public const char c_cN = 'N';

        private const int c_iMinArray = 10;
        private const int c_iMaxArray = 20;
        private const int c_iMinNumber = 0;
        private const int c_iMaxNumber = 30;
        public const int c_iMaxInt = 2147483647;
        public const int c_iCountUniversal = 200;

        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sReadNumberA = "Введите {0}{1}: ";
        private const string c_sGetMode =
            "Введите способ получения чисел (1 - ввод, - 2 случайное): ";
        private const string c_sGetTask =
            "МЕНЮ\n" +
            "1. Вывод множеств\n" +
            "2. Получить левое множество\n" +
            "3. Получить правое множество\n" +
            "4. Выполнить операцию \"" + c_sExcept + "\"\n" +
            "5. Выполнить операцию \"" + c_sIntersect + "\"\n" +
            "6. Выполнить операцию \"" + c_sUnite + "\"\n" +
            "7. Выполнить операцию \"" + c_sSymmetricDifference + "\"\n" +
            "8. Выполнить операцию \"" + c_sInversion + "\" левого множества\n" +
            "9. Выполнить операцию \"" + c_sInversion + "\" правого множества\n" +
            "0. Выход\n" +
            "Выберете действие: ";

        private const string c_sNullArray = "Ошибка! Массив не создан.\n";
        private const string c_sNullFunction = "Спасибо за работу!";

        private const string c_sResult = "{0}: {1}\n";
        private const string c_sOutput = "{0} {1}: {2}";
        private const string c_sLeft = "Левое";
        private const string c_sRight = "Правое";
        private const string c_sSet = "множество";
        private const string c_sExcept = "Вычитание";
        private const string c_sIntersect = "Пересечение";
        private const string c_sUnite = "Объединение";
        private const string c_sSymmetricDifference = "Симметрическая разность";
        private const string c_sInversion = "Отрицание";

        private static Random s_rand = new Random();
        private static int[] left;
        private static int[] right;
        public static int[] universal;

        private static IsValidate IsValid = (x, top) => (x >= 0 && x <= top);


        public static void Main()
        {
            SetUniversal();
            while (true)
            {
                try
                {
                    GetTask()();
                }
                catch (NullArrayException)
                {
                    Console.WriteLine(c_sNullArray);
                }
                catch (NullFunctionException)
                {
                    Console.Write(c_sNullFunction);
                    break;
                }
            }

            Console.ReadKey();
        }

        private static void SetUniversal()
        {
            universal = new int[c_iCountUniversal];
            for (int i = 0; i < c_iCountUniversal; ++i)
                universal[i] = i + 1;
        }

        public static void CheckArray()
        {
            if (left == null || right == null)
                throw new NullArrayException();
        }

        public static void ReadNum(out int number, char simbol, int i)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                if (i == -1)
                    Console.Write(c_sReadNumber, simbol);
                else
                    Console.Write(c_sReadNumberA, simbol, i);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
            }
        }

        public static void RandNum(out int number, char simbol, int i)
        {
            if (simbol == c_cN)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else
                number = s_rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        private static GetNumber GetMode()
        {
            string key = "";
            do
            {
                Console.Write(c_sGetMode);
                key = Console.ReadLine();
            } while (key != "1" && key != "2");
            if (key == "1")
                return ReadNum;
            else
                return RandNum;
        }

        private static void GetValid(out int number, GetNumber GetNum, char simbol, int top)
        {
            do GetNum(out number, simbol);
            while (!IsValid(number, top));
        }

        private static void Formation(out int[] array, GetNumber GetNum, char simbol)
        {
            GetValid(out int n, GetNum, c_cN, c_iMaxInt);
            array = new int[n];
            for (int i = 0; i < n; ++i)
                GetNum(out array[i], simbol, i);
            Console.WriteLine();
        }

        private static void Output()
        {
            CheckArray();
            Console.WriteLine(c_sOutput, c_sLeft, c_sSet, string.Join(" ", left));
            Console.WriteLine(c_sOutput, c_sRight, c_sSet, string.Join(" ", right));
            Console.WriteLine();
        }

        private static void FormationLeft()
        {
            Console.WriteLine(c_sLeft + c_sSet);
            Formation(out left, GetMode(), c_ca);
        }

        private static void FormationRight()
        {
            Console.WriteLine(c_sRight + c_sSet);
            Formation(out right, GetMode(), c_cb);
        }

        private static void OperationExcept()
        {
            CheckArray();
            Console.WriteLine(c_sResult, c_sExcept, string.Join(" ", left.MyExcept(right)));
        }

        private static void OperationIntersect()
        {
            CheckArray();
            Console.WriteLine(c_sResult, c_sIntersect, string.Join(" ", left.MyIntersect(right)));
        }

        private static void OperationUnite()
        {
            CheckArray();
            Console.WriteLine(c_sResult, c_sUnite, string.Join(" ", left.MyUnite(right)));
        }

        private static void OperationSymmetricDifference()
        {
            CheckArray();
            Console.WriteLine(c_sResult, c_sSymmetricDifference, string.Join(" ", left.MySymmetricDifference(right)));
        }

        private static void OperationInversionLeft()
        {
            if (left == null)
                throw new NullArrayException();
            Console.WriteLine(c_sResult, c_sInversion, string.Join(" ", universal.MyExcept(left)));
        }

        private static void OperationInversionRight()
        {
            if (right == null)
                throw new NullArrayException();
            Console.WriteLine(c_sResult, c_sInversion, string.Join(" ", universal.MyExcept(right)));
        }

        private static Task GetTask()
        {
            bool flag = true;
            while (flag)
            {
                Console.Write(c_sGetTask);
                switch (Console.ReadLine())
                {
                    case "1":
                        return Output;
                    case "2":
                        return FormationLeft;
                    case "3":
                        return FormationRight;
                    case "4":
                        return OperationExcept;
                    case "5":
                        return OperationIntersect;
                    case "6":
                        return OperationUnite;
                    case "7":
                        return OperationSymmetricDifference;
                    case "8":
                        return OperationInversionLeft;
                    case "9":
                        return OperationInversionRight;
                    case "0":
                        flag = false;
                        break;
                    default:
                        continue;
                }
            }
            throw new NullFunctionException();
        }
    }
}