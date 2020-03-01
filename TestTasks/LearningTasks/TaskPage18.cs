using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage18
    {
        public TaskPage18()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Задача про явное/неявное преобразование. Собсвтенно реализация в классе Person. Демонстрация ниже. Создаем из строки класс - сделал в явном виде. Выводим в консоль через неявное преобразование. ");
            Person person = (Person)"Иванов Иван";
            Console.WriteLine(person);
            ConsoleTool.WriteLineConsoleGreenMessage("Делаем сравнение через оператор ==");
            Console.WriteLine((person == "Иванов Иван").ToString());
            ConsoleTool.WriteLineConsoleGreenMessage("Делаем сравнение через оператор Equals. По дефолту Equals при сравнении ссылочных типов (а строка это ссылочный тип) будет проверять именно ссылки. Т.к. в этом случаи ссылки ссылаются на разные области в куче, то ответ будет отрицательным.");
            Console.WriteLine((person.Equals("Иванов Иван")).ToString());
        }
    }
}
