using System;
using System.Collections.Generic;
using System.Text;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage49
    {
        public TaskPage49()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Тестирование метода расширения для int, который преобразует целое число в TimeSpan: ");
            int number = 61;
            Console.WriteLine(number + " : " + number.Seconds());
        }
    }


    public static class IntExtension
    {
        public static TimeSpan Seconds(this int number)
        {
            return TimeSpan.FromSeconds(number);
        }
    }
}
