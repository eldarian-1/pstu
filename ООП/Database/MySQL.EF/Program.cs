using System;
using System.Linq;

namespace MySQL.EF
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (DataContext context = new DataContext())
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                    Console.WriteLine("id {0}: {1}", user.Id, user.Name);
            }
            Console.ReadKey();
        }
    }
}
