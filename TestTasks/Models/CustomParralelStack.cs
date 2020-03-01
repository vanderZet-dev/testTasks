using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTasks.Models
{
    public class CustomParralelStack : IJobExecutor
    {
        private ConcurrentStack<Task> items = new ConcurrentStack<Task>();
        private ConcurrentStack<Task> itemsIsCreated
        {
            get { return new ConcurrentStack<Task>(items.Where(x => x.Status == TaskStatus.Created).ToList());  }
        }
       
        private CancellationTokenSource _cancelTokenSource;

        public int Amount => items.Count;
        private int AmountIsCreated => items.Where(x => x.Status== TaskStatus.Created).Count();
        private int AmountCanceled => items.Where(x=>x.Status == TaskStatus.Canceled).Count();
        private int AmountFaulted => items.Where(x => x.Status == TaskStatus.Faulted).Count();
        private int AmountRanToCompletiond => items.Where(x => x.Status == TaskStatus.RanToCompletion).Count();
        private int AmountRunning => items.Where(x => x.Status == TaskStatus.Running).Count();
        private int AmountWaitingToRun => items.Where(x => x.Status == TaskStatus.WaitingToRun).Count();
        

        public void Start(int maxConcurrent, CancellationTokenSource cancelTokenSource)
        {
            _cancelTokenSource = cancelTokenSource;
            Start(maxConcurrent);
        }

        public void Start(int maxConcurrent)
        {
            int started = 0;
            while (true)
            {
                if (_cancelTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Все операции будут принудительно завершены.");
                    return;
                }

                if (started < maxConcurrent)
                {
                    Task task;
                    itemsIsCreated.TryPeek(out task);
                    if (task != null && task.Status == TaskStatus.Created)
                    {
                        Interlocked.Increment(ref started);
                        task.ContinueWith(t =>
                        {
                            Interlocked.Decrement(ref started);
                            Console.WriteLine(" threadID - " + Thread.CurrentThread.ManagedThreadId + " | Задача завершена со статусом " + task.Status + ". Started: " + started + " Handled: " + this);
                        });

                        task.Start();
                    }
                }
            }
        }

        public void Stop()
        {
            _cancelTokenSource.Cancel();
        }

        public void Add(Action action)
        {
            var task = new Task(action);
            items.Push(task);
        }

        public void Clear()
        {
            items.Clear();

            if (items.IsEmpty)
            {
                Console.WriteLine("Очередь очищена.");
            }
        }

        public void ConsoleMainInfo()
        {
            Console.WriteLine($"{Amount} - задач в очереди. В том числе:");
            Console.WriteLine($"{AmountIsCreated} - необроаботанные.");
            Console.WriteLine($"{AmountCanceled} - отмененные.");
            Console.WriteLine($"{AmountFaulted} - завершены с ошибкой.");
            Console.WriteLine($"{AmountRanToCompletiond} - завершены.");
            Console.WriteLine($"{AmountRunning} - запущенные.");
            Console.WriteLine($"{AmountWaitingToRun} - ожидают запуска.");
        }

        public override string ToString()
        {
            return $"{AmountRanToCompletiond}/{Amount}";
        }
    }
}
