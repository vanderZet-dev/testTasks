using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTasks.Models
{
    public class CustomTaskStack : CustomStack<Task>, IJobExecutor
    {

        public int Amount => items.Count;

        private CancellationTokenSource cancelTokenSource;

        public CustomTaskStack(int limit, CancellationTokenSource cancelTokenSource) : base(limit)
        {
            this.cancelTokenSource = cancelTokenSource;
        }

        public void Start(int maxConcurrent)
        {
            int started = 0;
            while (true)
            {
                //Console.WriteLine(taskItems.Count);
                if (started < maxConcurrent)
                {
                    var task = GetNext(false);
                    //if (!Equals(task, null))
                    if (task!=null && task.Status == TaskStatus.Created)
                    {
                        Interlocked.Increment(ref started);
                        task.ContinueWith((t =>
                        {
                            Interlocked.Decrement(ref started);
                            Console.WriteLine(" threadID - " + Thread.CurrentThread.ManagedThreadId + " | Задача завершена. Started: " + started + " Left: " + items.Count);
                        }));
                        task.Start();
                    }
                    
                }
            }
        }

        

        public void Stop()
        {
            cancelTokenSource.Cancel();
        }

        public void Add(Action action)
        {
            Task newTask = new Task(action);
            //taskItems.Push(newTask);
            AddItem(newTask);
        }

        public void Clear()
        {
            Stop();

            while (items.Count > 0)
            {
                items.Remove(GetNext());
            }
        }
    }
}
