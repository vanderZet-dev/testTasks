using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage58
    {
        public TaskPage58()
        {

        }

        public void ConsoleGetNumbersFromText()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Выделим числа их текста:");

            string someText = "1, 1000, 1 000 000, 100.23";

            Regex regex = new Regex(@",");
            var result = regex.Split(someText);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i].Replace(" ", ""));
            }
        }

        public void ConsoleGetParamsFromURL()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Выделим параметры из строки запроса:");

            string someText = "http://ya.ru/api?r=1&x=23";

            Regex regex = new Regex(@"=\d{1,}");
            var result = regex.Matches(someText);
            foreach (Match match in result)
            {
                Console.WriteLine(match.Value.Replace("=",""));
            }
        }

        public void ConsoleRemoveRepeatableSpaces()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Удалим лишние пробелы из строки: ");

            string someText = "  ea1359 29105    c4f29   a0f51           17d2  960 926f";
            ConsoleTool.WriteLineConsoleGreenMessage(someText);

            Regex regex = new Regex(@"\s{1,}");
            var result = regex.Replace(someText, " ");
            Console.WriteLine(result);
        }

        public void ConsoleCheckForCorrectNumber()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Проверить на корректность введенные номера телефонов: ");
            List<string> numbers = new List<string>
            {
                "+373 77767852",
                "77767852",
                "0 (777) 67852",
            };
            Regex regex = new Regex(@"^0?(\+\d{3})?\s?\(?\d{3}\)?\s?\d{5}$");
            foreach (var number in numbers)
            {
                Console.WriteLine($"{number} результат проверки: {regex.IsMatch(number)}");
            }
        }

        
    }
}
