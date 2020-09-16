using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas=null;
            int size=0;
            int answer1,answer2;
            bool ok;
            Random rnd = new Random();

            do
            {
                Console.WriteLine(@"1. Формирование массива
2. Вывод массива
3. Удаление из массива
4. Добавление в массив
5. Поиск
6. Сортировка
9. Выход");
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out answer1);
                    if (ok == false)
                    {
                        Console.WriteLine("Ошибка при вводе числа");
                    }
                } while (ok == false);//!ok

                switch (answer1)
                {
                    case 1:
                        {
                            //формирование массива
                            do
                            {
                                Console.WriteLine("Введите количество элементов массива");
                                ok = int.TryParse(Console.ReadLine(), out size);
                                if (ok == false)
                                {
                                    Console.WriteLine("Ошибка при вводе числа");
                                }
                            } while (ok == false);//!ok
                            mas = new int[size];

                            // меню для формирования массива
                            do
                            {
                                Console.WriteLine(@"1. С помощью ДСЧ
2. Ввод с клавиатуры
3. Выход");
                                do
                                {
                                    ok = int.TryParse(Console.ReadLine(), out answer2);
                                    if (ok == false)
                                    {
                                        Console.WriteLine("Ошибка при вводе числа");
                                    }
                                } while (ok == false);//!ok
                                switch (answer2)
                                {
                                    case 1:
                                        {
                                            //формирование ДСЧ
                                            for (int i = 0; i < size; i++)
                                                mas[i] = rnd.Next(-100, 100);
                                            Console.WriteLine("Массив сформирован");
                                            break;
                                        }
                                    case 2:
                                        {
                                            //ввод массива с клавиатуры
                                          
                                            for (int i = 0; i < size; i++)
                                            {
                                                do
                                                {
                                                    Console.WriteLine("Введите  элемент массива");
                                                    ok = int.TryParse(Console.ReadLine(), out mas[i]);
                                                    if (ok == false)
                                                    {
                                                        Console.WriteLine("Ошибка при вводе числа");
                                                    }
                                                } while (ok == false);//!ok
                                                Console.WriteLine("Массив сформирован");
                                            }
                                            break;
                                        }
                                }
                            } while (answer2 <= 2);
                            break;
                        }//конец case 1
                    case 2:
                        {
                            //печать массива
                            if (size == 0) Console.WriteLine("Пустой массив");
                            for (int i = 0; i < size; i++)
                                Console.Write(mas[i] + " ");
                            Console.WriteLine();
                            break;
                        }//конец case 2
                    case 3:
                        {
                            //удаление элемента из массива
                            if (size == 0)
                            {
                                Console.WriteLine("Массив пустой, удаление невозможно");
                                break;
                            }
                            //шаг 1 поиск минимального элемента
                            int min = mas[0];
                            int number = 0;
                            for (int i = 0; i < size; i++)
                                if (min > mas[i])
                                {
                                    min = mas[i];
                                    number = i;
                                }
                            //шаг 2 удаление элемента с номером number
                            int[] temp = new int[size - 1];
                            int j = 0;
                            for(int i=0;i<size;i++)
                            {
                                if(i!=number)
                                {
                                    temp[j] = mas[i];
                                    j++;
                                }
                            }
                            mas = temp;
                            size--;
                            Console.WriteLine("Минимальный элемент удален");
                            break;
                        }
                }//конец switch 1
            } while (answer1 < 9);

        }
    }
}
