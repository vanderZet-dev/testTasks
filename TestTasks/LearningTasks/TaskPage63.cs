using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage63
    {
        private Random random;

        private int procCount;

        private decimal[] generalArray1000mb;

        private decimal[] generalArray100mb;

        private decimal[] generalArray10mb;

        public TaskPage63()
        {
            random = new Random();
            generalArray1000mb = new decimal[62500000];
            for (int i = 0; i < generalArray1000mb.Length; i++)
            {
                generalArray1000mb[i] = random.Next(0, 10);
            }

            generalArray100mb = new decimal[6250000];
            for (int i = 0; i < generalArray100mb.Length; i++)
            {
                generalArray100mb[i] = random.Next(0, 10);
            }

            generalArray10mb = new decimal[625000];
            for (int i = 0; i < generalArray10mb.Length; i++)
            {
                generalArray10mb[i] = random.Next(0, 10);
            }

            procCount = Environment.ProcessorCount;
            Console.WriteLine("Количество процессоров(ядер): {0}", procCount);
        }

        public void ConsoleAverageDecimal10Mb()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Производим последовательный расчет среднего арифметического для значений decimal массива размером в 10 мегабайт:");
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal summ = 0;
            for (int i = 0; i < generalArray10mb.Length; i++)
            {
                summ += generalArray10mb[i];
            }
            decimal average = summ / generalArray10mb.Length;

            stopwatch.Stop();

            Console.WriteLine($"summ: {summ}");
            Console.WriteLine($"Среднее значение: {average}, найдено за {stopwatch.Elapsed}");
        }
        public void ConsoleParallelAverageDecimal10Mb()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Производим параллельный расчет среднего арифметического для значений decimal массива размером в 10 мегабайт:");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal summ = generalArray10mb.AsParallel().Sum(arg => arg);

            decimal average = summ / generalArray10mb.Length;

            stopwatch.Stop();

            Console.WriteLine($"summ: {summ}");
            Console.WriteLine($"Среднее значение: {average}, найдено за {stopwatch.Elapsed}");
        }


        public void ConsoleAverageDecimal100Mb()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Производим последовательный расчет среднего арифметического для значений decimal массива размером в 100 мегабайт:");
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal summ = 0;
            for (int i = 0; i < generalArray100mb.Length; i++)
            {
                summ += generalArray100mb[i];
            }
            decimal average = summ / generalArray100mb.Length;

            stopwatch.Stop();

            Console.WriteLine($"summ: {summ}");
            Console.WriteLine($"Среднее значение: {average}, найдено за {stopwatch.Elapsed}");
        }
        public void ConsoleParallelAverageDecimal100Mb()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Производим параллельный расчет среднего арифметического для значений decimal массива размером в 100 мегабайт:");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal summ = generalArray100mb.AsParallel().Sum(arg => arg);

            decimal average = summ / generalArray100mb.Length;

            stopwatch.Stop();

            Console.WriteLine($"summ: {summ}");
            Console.WriteLine($"Среднее значение: {average}, найдено за {stopwatch.Elapsed}");
        }

        public void ConsoleAverageDecimal1000Mb()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Производим последовательный расчет среднего арифметического для значений decimal массива размером в 1000 мегабайт:");
            
            var decimalArrayOne = generalArray1000mb;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal summ = 0;

            for (int i = 0; i < decimalArrayOne.Length; i++)
            {
                summ += decimalArrayOne[i];
            }

            decimal average = summ / decimalArrayOne.Length;

            stopwatch.Stop();

            Console.WriteLine($"summ: {summ}");
            Console.WriteLine($"Среднее значение: {average}, найдено за {stopwatch.Elapsed}");
        }
        public void ConsoleParallelAverageDecimal1000Mb()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Производим параллельный расчет среднего арифметического для значений decimal массива размером в 1000 мегабайт:");

            var decimalArrayOne = generalArray1000mb;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decimal summ = decimalArrayOne.AsParallel().Sum(arg => arg);

            decimal average = summ / decimalArrayOne.Length;

            stopwatch.Stop();
            
            Console.WriteLine($"summ: {summ}");
            Console.WriteLine($"Среднее значение: {average}, найдено за {stopwatch.Elapsed}");
        }

        public void ConsoleResultDescription()
        {
            ConsoleTool.WriteLineConsoleGreenMessage("Исходя из наблюдения, можно сделать вывод, что при 10 мегабайтах использовать параллельный подсчет не выгодно. Для случаев со 100 и 1000 мегабайт праллельное вычисление дало прирост скорости подсчетов.");
        }
    }
}
