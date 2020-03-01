using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTasks.Models;

namespace TestTasks.LearningTasks
{
    public class TaskPage63_2
    {
        public CustomTaskStack CustomTaskStack;

        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        public TaskPage63_2()
        {
            var locker = new object();
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;

            CustomTaskStack = new CustomTaskStack(100, cancelTokenSource);

            Action<object> generateNewTasks = GenerateNewTasks;

            ThreadPool.QueueUserWorkItem(_ => // запуск параллельного потока
            {
                while (true)
                {
                    CustomTaskStack.Start(5);
                    Thread.Sleep(10000);
                }
            });

            Thread.Sleep(5000);

            ThreadPool.QueueUserWorkItem(_ => // запуск параллельного потока
            {
                for (int i = 1; i <= 10; i++)
                {
                    generateNewTasks.Invoke(locker);
                    Thread.Sleep(5000);
                }
            });

            Thread.Sleep(5000);

            CustomTaskStack.Stop();
            
            Thread.Sleep(5000);

            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;

            Thread.Sleep(10000);
            
            CustomTaskStack.Clear();

            Thread.Sleep(200000);
        }


        private void GenerateNewTasks(object locker)
        {
            ThreadPool.QueueUserWorkItem(_ => // запуск параллельного потока
            {
                lock (locker) // синхронизация
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        Action action = SomeWork;
                        CustomTaskStack.Add(action);
                    }
                }
            });
        }

        private void SomeWork()
        {
            int counter = 10;
            Console.WriteLine("Start task: threadID - " + Thread.CurrentThread.ManagedThreadId);
            while (counter -- > 0)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                Thread.Sleep(10);
            }
        }

    }
}
