using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTasks.Models;
using TestTasks.Tools;

namespace TestTasks.LearningTasks
{
    public class TaskPage63_2_Alter
    {
        private CustomParralelStack customParralelStack;
        
        CancellationTokenSource _cancelTokenSource;
        CancellationToken _token;

        public TaskPage63_2_Alter()
        {
            customParralelStack = new CustomParralelStack();

            while (true)
            {
                ConsoleTool.WriteLineConsoleGreenMessage("1 - состояние очереди задач.");
                ConsoleTool.WriteLineConsoleGreenMessage("2 - запустить выполнение задач.");
                ConsoleTool.WriteLineConsoleGreenMessage("3 - остановить выполнение задач.");
                ConsoleTool.WriteLineConsoleGreenMessage("4 - добавить 20 задач на выполнение.");
                ConsoleTool.WriteLineConsoleGreenMessage("5 - очистить очередь.");
                ConsoleTool.WriteLineConsoleGreenMessage("Любая другая клавиша - завершение работы.");



                var cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        customParralelStack.ConsoleMainInfo();
                        break;
                    case "2":
                            _cancelTokenSource = new CancellationTokenSource();
                            _token = _cancelTokenSource.Token;
                            Task.Factory.StartNew(() => customParralelStack.Start(4, _cancelTokenSource));
                        break;
                    case "3":
                        Task.Factory.StartNew(() => customParralelStack.Stop());
                        break;
                    case "4":
                        GenerateNewTasks();
                        break;
                    case "5":
                        Task.Factory.StartNew(() => customParralelStack.Clear());
                        break;
                    default:
                        return;
                }
            }
        }



        private void GenerateNewTasks()
        {
            ThreadPool.QueueUserWorkItem(_ => // запуск параллельного потока
            {
                for (int i = 1; i <= 20; i++)
                {
                    Action action = SomeWork;
                    customParralelStack.Add(action);
                }

                Console.WriteLine("Добавлено 20 новых задач.");
            });
        }

        private void SomeWork()
        {
            try
            {
                _token.ThrowIfCancellationRequested();

                int counter = 5;
                Console.WriteLine("Start task: threadID - " + Thread.CurrentThread.ManagedThreadId);
                while (counter-- > 0)
                {
                    if (_token.IsCancellationRequested)
                    {
                        _token.ThrowIfCancellationRequested();
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("task: threadID - " + Thread.CurrentThread.ManagedThreadId + " отменена.");
            }
            
        }

    }
}
