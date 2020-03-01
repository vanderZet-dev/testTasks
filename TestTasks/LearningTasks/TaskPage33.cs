using System;
using System.Collections.Generic;
using System.Threading;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage33
    {
        private Dictionary<Person, string> workCatalog;

        private List<string> testList;

        public TaskPage33()
        {
            workCatalog = new Dictionary<Person, string>();

            Person person1 = new Person(){ LastName = "Федоров", FirstName = "Алексей", PaterName = "Алексеевич", Passport = "11авы321dsdsad", BirthPlace = "Москва" };
            Person person2 = new Person() { LastName = "Иванов", FirstName = "Петр", PaterName = "Степанович", Passport = "13321d2sdsad", BirthPlace = "Тирасполь" };
            Person person3 = new Person() { LastName = "Шевчук", FirstName = "Кирилл", PaterName = "Дмитриевич", Passport = "13231dsdsad", BirthPlace = "Бендеры" };
            Person person4 = new Person() { LastName = "Васильев", FirstName = "Станислав", PaterName = "Черчесович", Passport = "13221dsdsad", BirthPlace = "Тирасполь" };
            Person person5 = new Person() { LastName = "Пимонов", FirstName = "Илья", PaterName = "Кириллович", Passport = "13вфы21dsdsad", BirthPlace = "Рыбница" };

            workCatalog.Add(person1, "Стройка");
            workCatalog.Add(person2, "Автомойка");
            workCatalog.Add(person3, "Секретариат");
            workCatalog.Add(person4, "СТО");
            workCatalog.Add(person5, "Библиотека");

            ConcurrentReadAndWriteToListTest();
        }

        private string FindPersonWorkPlaceByPersonData(string lastName, string firstName, string paterName, string passport, string birthPlace)
        {
            var person = new Person(){ LastName = lastName, FirstName = firstName, PaterName = paterName, Passport = passport, BirthPlace = birthPlace };
            string res = "";
            try
            {
               res = workCatalog[person];
            }
            catch (KeyNotFoundException e)
            {
                res = "Н/Д";
            }
            return res;
        }

        public void ConsoleFindPersonWorkPlaceByPersonData()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Пробуем найти объект, который точно есть в словаре: ");
            Console.WriteLine(FindPersonWorkPlaceByPersonData("Федоров", "Алексей", "Алексеевич", "11авы321dsdsad", "Москва"));

            ConsoleTool.WriteLineConsoleGreenMessage("Пробуем найти объект, которого нет в словаре: ");
            Console.WriteLine(FindPersonWorkPlaceByPersonData("Федоров1", "Алексей", "Алексеевич", "11авы321dsdsad", "Москва"));
        }

        private void ConcurrentReadAndWriteToListTest()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проверка на попытку использовать List из разных потоков одновременно. Ошибки не вылетали. Так должно быть? ");

            testList = new List<string>();
            testList.Add("add2s");
            testList.Add("adsdas2");
            testList.Add("ad23s");
            testList.Add("adsda");

            Thread myThread = new Thread(ReadAndWriteWithList);
            myThread.Start(); // запускаем поток

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Основной поток:");
                testList[1] = "1";
                testList.Add("adsda");
                Console.WriteLine(testList[1]);
            }

        }

        public void ReadAndWriteWithList()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Второй поток:");
                testList[1] = "2";
                Console.WriteLine(testList[1]);
            }
        }
    }
}




