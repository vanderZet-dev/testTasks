using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage40
    {
        public TaskPage40()
        {
            List<Person> persons = new List<Person>();
        }

        public void ConsoleTestINotifyPropertyChanged()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Демонстрация работы INotifyPropertyChanged. Создаем объект, реализующий этот интерфейс. Подписываемся на событие PropertyChanged. При изменении property выводим его название.");
            Person p = new Person() { FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3" };
            p.PropertyChanged += OnModelPropertyChanged;
            p.FirstName = "Дмитрий";
            p.BirthPlace = "Вашингтон";
        }

        void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Изменено свойство: {e.PropertyName}");
        }

        public void ConsoleTestStackWithNotify()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Тестируем стек с оповещением.");
            CustomStack<string> customStack = new CustomStack<string>(2);
            customStack.EventAddedNewItem += OnItemAdded;
            customStack.EventLimitExceeded += OnLimitExceeded;
            customStack.EventStackIsEmpty += OnStackIsEmpty;

            customStack.AddItem("1");
            customStack.AddItem("2");
            customStack.AddItem("3");
            customStack.AddItem("4");

            ConsoleTool.WriteLineConsoleGreenMessage("В безконечном цикле извлекаем все элементы в порядке очереди, до исключения. Бесконечный цикл потому, что нужно исключение.");
            while (true)
            {
                try
                {
                    Console.WriteLine($"Извлечен item: {customStack.GetNext()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        void OnItemAdded()
        {
            Console.WriteLine("Эй, добавлен новый элемент.");
        }
        void OnStackIsEmpty()
        {
            Console.WriteLine("Очередь пустая.");
        }
        void OnLimitExceeded()
        {
            Console.WriteLine("Превышен заданный лимит очереди.");
        }

        public void ConsoleTestNumberAnalyzer()
        {
            NumberAnalyzer numberAnalyzer = new NumberAnalyzer(100, 4);
            numberAnalyzer.EventTooHightDifference +=
                () => Console.WriteLine("Число отличается на недопустимую велчину.");

            Random random = new Random();

            ConsoleTool.WriteLineConsoleGreenMessage("Исходные данные 100 и от него допуск 4% вперед и назад. Проверим числа в диапазоне от 0 до 199. Тут точно будут недопустимые величины.");
            for (int i = 0; i < 5; i++)
            {
                int testNumber = random.Next(0, 200);
                Console.WriteLine($"Проверка числа: {testNumber}");
                numberAnalyzer.DifferenceChecker(testNumber);
            }

            ConsoleTool.WriteLineConsoleGreenMessage("А теперь скормим заведомо подходящие числа от 97 до 103");
            for (int i = 0; i < 5; i++)
            {
                int testNumber = random.Next(97, 104);
                Console.WriteLine($"Проверка числа: {testNumber}");
                numberAnalyzer.DifferenceChecker(testNumber);
            }

        }
    }
}
