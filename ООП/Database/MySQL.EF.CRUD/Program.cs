using System;
using System.Linq;
using System.Collections.Generic;

namespace MySQL.EF.CRUD
{
    internal class Program
    {
        private static void SelectAllTest(DataContext context)
        {
            IEnumerable<User> users = context.Users.ToList();
            foreach (var user in users)
                Console.WriteLine($"id {user.Id}: {user.Name}");
        }

        private static User SelectOneTest(DataContext context, int id)
        {
            User user = context.Users.Find(id);
            Console.WriteLine($"id {user.Id}: {user.Name}");
            return user;
        }

        private static void InsertTest(DataContext context, User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        private static void UpdateTest(DataContext context, User user)
        {
            context.Users.Find(user.Id).Name = user.Name;
            context.SaveChanges();
        }

        private static void DeleteTest(DataContext context, User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public static void Main(string[] args)
        {
            DataContext context = new DataContext();
            Console.WriteLine("Выборка всех пользователей:");
            SelectAllTest(context);
            Console.WriteLine("\nВыборка пользователя по id 4:");
            User user = SelectOneTest(context, 4);
            Console.WriteLine("\nДобавление пользователя:");
            InsertTest(context, new User { Name = "Фридрих Ницше" });
            SelectAllTest(context);
            Console.WriteLine("\nОбновление пользователя:");
            user.Name = "Абрахам Линкольн";
            UpdateTest(context, user);
            SelectAllTest(context);
            Console.WriteLine("\nУдаление пользователя:");
            DeleteTest(context, user);
            SelectAllTest(context);
            Console.ReadKey();
        }
    }
}
