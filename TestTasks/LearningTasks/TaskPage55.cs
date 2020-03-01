using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage55
    {
        private List<User> users;

        public TaskPage55()
        {
            users = new List<User>();

            var user1 = new User(1, "login1");
            var user2 = new User(2, "login2");
            var user3 = new User(3, "login3");
            var user4 = new User(4, "login4");

            var userDetail1 = new UserDetail(8, "Степанов");
            var userDetail2 = new UserDetail(9, "Иванов");
            var userDetail3 = new UserDetail(10, "Петров");
            var userDetail4 = new UserDetail(11, "Григорьев");

            user1.UserDetail = userDetail1;
            user2.UserDetail = userDetail2;
            user3.UserDetail = userDetail3;
            user4.UserDetail = userDetail4;

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
        }

        public void ConsoleBinaryTest()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проверяем сериализацию и десериализацию: ");
            BinaryFormatter formatter = new BinaryFormatter();

            List<User> deserilizeUsers;
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, users);

                var base64 = Convert.ToBase64String(stream.ToArray());
                Console.WriteLine("Сериализованные данные:\n{0}", base64);
                stream.Position = 0;
                
                deserilizeUsers = (List<User>)formatter.Deserialize(stream);
            }

            Console.WriteLine();
            Console.WriteLine("Десериализованные данные:");

            foreach (var u in deserilizeUsers)
            {
                Console.WriteLine(u.ToString() + " " + u.UserDetail.ToString());
            }
        }

        public void ConsoleBinaryRecursionTest()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проверяем сериализацию и десериализацию при возможной рекурсии (вроде бы ничего не отвалилось): ");
            var user1 = new User(1, "login1");
            var userDetail1 = new UserDetail(8, "Степанов");
            user1.UserDetail = userDetail1;
            userDetail1.ToUser = user1;

            BinaryFormatter formatter = new BinaryFormatter();

            User deserilizeUser;
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, user1);

                var base64 = Convert.ToBase64String(stream.ToArray());
                Console.WriteLine("Сериализованные данные:\n{0}", base64);
                stream.Position = 0;

                deserilizeUser = (User)formatter.Deserialize(stream);
            }

            Console.WriteLine();
            Console.WriteLine("Десериализованные данные:");
           
            Console.WriteLine(deserilizeUser.ToString()  + " " + deserilizeUser.UserDetail.ToString());
        }
    }
}
