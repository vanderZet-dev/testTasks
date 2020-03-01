using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage20
    {
        public TaskPage20()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Измерим скорость операции упаковки: ");
            Stopwatch stopwatch = new Stopwatch();
            int testValue = 5;
            stopwatch.Start();
            object packedValue = testValue;
            stopwatch.Stop();
            Console.WriteLine("ElapsedTicks: {0}", stopwatch.ElapsedTicks);
            stopwatch.Reset();
            ConsoleTool.WriteLineConsoleGreenMessage("Измерим скорость операции упаковки: ");
            stopwatch.Start();
            int unPackedValue = (int)packedValue;
            stopwatch.Stop();
            Console.WriteLine("ElapsedTicks: {0}", stopwatch.ElapsedTicks);
        }
    }
}
