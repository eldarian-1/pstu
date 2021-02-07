using System;
using System.Collections.Generic;

namespace MySQL.ADO.CRUD
{
    internal class Program
    {
        private static void SelectAllTest(DataRequester requester)
        {
            IEnumerable<User> users = requester.SelectAll();
            foreach (var user in users)
                Console.WriteLine($"id {user.Id}: {user.Name}");
        }

        private static User SelectOneTest(DataRequester requester, int id)
        {
            User user = requester.SelectOne(id);
            Console.WriteLine($"id {user.Id}: {user.Name}");
            return user;
        }

        private static void InsertTest(DataRequester requester, User user)
        {
            requester.Insert(user);
        }

        private static void UpdateTest(DataRequester requester, User user)
        {
            requester.Update(user);
        }

        private static void DeleteTest(DataRequester requester, User user)
        {
            requester.Delete(user);
        }

        public static void Main(string[] args)
        {
            DataRequester requester = new DataRequester();
            Console.WriteLine("Выборка всех пользователей:");
            SelectAllTest(requester);
            Console.WriteLine("\nВыборка пользователя по id 1:");
            User user = SelectOneTest(requester, 1);
            Console.WriteLine("\nДобавление пользователя:");
            InsertTest(requester, new User { Name = "Фридрих Ницше" });
            SelectAllTest(requester);
            Console.WriteLine("\nОбновление пользователя:");
            user.Name = "Чарльз Дарвин";
            UpdateTest(requester, user);
            SelectAllTest(requester);
            Console.WriteLine("\nУдаление пользователя:");
            DeleteTest(requester, user);
            SelectAllTest(requester);
            Console.ReadKey();
        }
    }
}
