using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Exceptions;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage36
    {
        private UniqueCollection<string> uniqueStringCollection;
        private UniqueCollection<int> uniqueIntCollection;
        private UniqueCollection<Person> uniquePersonCollection;

        public TaskPage36()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Пробуем добавлять в нашу уникальную коллекцию не совсем уникальные элементы (string). Ждем исключение: ");
            uniqueStringCollection = new UniqueCollection<string>();
            try
            {
                uniqueStringCollection.AddItem("тест");
                uniqueStringCollection.AddItem("тест2");
                uniqueStringCollection.AddItem("тест");
            }
            catch (ItemIsAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

            ConsoleTool.WriteLineConsoleGreenMessage("Пробуем добавлять в нашу уникальную коллекцию не совсем уникальные элементы (int). Ждем исключение: ");
            uniqueIntCollection = new UniqueCollection<int>();
            try
            {
                uniqueIntCollection.AddItem(5);
                uniqueIntCollection.AddItem(3);
                uniqueIntCollection.AddItem(5);
            }
            catch (ItemIsAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

            ConsoleTool.WriteLineConsoleGreenMessage("Пробуем добавлять в нашу уникальную коллекцию не совсем уникальные элементы (Person). Ждем исключение: ");
            uniquePersonCollection = new UniqueCollection<Person>();
            try
            {
                uniquePersonCollection.AddItem(new Person() { FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3" });
                uniquePersonCollection.AddItem(new Person() { FirstName = "Степанов", LastName = "Игорь", PaterName = "Сергеевич", BirthPlace = "Брянск", Passport = "4453422334231sd3" });
                uniquePersonCollection.AddItem(new Person() { FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3" });
            }
            catch (ItemIsAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
