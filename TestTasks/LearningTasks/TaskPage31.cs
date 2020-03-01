using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage31
    {



        public void ConsoleTestStringComparer()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Тестируем работу оператора == для строки.");

            string a = "Строка 1";
            string b = "Строка 1";
            Console.WriteLine($"{a} == {b}");

            Console.WriteLine((a==b).ToString());
        }

        public void ConsoleTestPersonEqual()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проверяем работу преопределенного Equal. Создадим два экземпляра Person с одинаковыми полями. Ожидаем true.");
            Person person1 = new Person() {FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3"};
            Person person2 = new Person() { FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3" };
            Console.WriteLine(person1.Equals(person2));

            ConsoleTool.WriteLineConsoleGreenMessage("Изменим для одного из экземпляров один символ в паспорте и сравним повторно. Ожидаем false.");
            person2.Passport = "44534233423dsd4";
            Console.WriteLine(person1.Equals(person2));
        }

        public void ConsoleTestPersonGetHashCode()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проверяем работу преопределенного GetHashCode. Создадим два экземпляра Person с одинаковыми полями и выведем их хеши.");
            Person person1 = new Person() { FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3" };
            Person person2 = new Person() { FirstName = "Иван", LastName = "Иванов", PaterName = "Иванович", BirthPlace = "Москва", Passport = "44534233423dsd3" };
            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person2.GetHashCode());

            ConsoleTool.WriteLineConsoleGreenMessage("Изменим для одного из экземпляров один символ в паспорте и сделаем повторный вывод. Ожидаем различные хеши.");
            person2.Passport = "44534233423dsd1";
            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person2.GetHashCode());
        }
    }
}
