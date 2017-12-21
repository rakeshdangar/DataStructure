using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TaskAndWorkers
    {
        public static void Init()
        {
            int[] input = { 2, 2, 3, 7, 1 };
            TaskAndWorkers taw = new TaskAndWorkers();
            Console.WriteLine("Minimun time required to completed tasks(2,2,3,7,1) with 2 workers is {0}", taw.getMini(input, 2).ToString());

        }

        public int getMini(int[] tasks, int k)
        {
            if (null == tasks || tasks.Length == 0 || k == 0)
                throw new ArgumentNullException(); //Error condition
            int min = 0;
            int[] workers = new int[k];
            List<int> temp = tasks.ToList();
            temp.Sort();
            tasks = temp.ToArray();
            for (int i = tasks.Length - 1; i >= 0; i--)
            {
                int minWorker = getCurrentMinWorker(workers);
                workers[minWorker] += tasks[i];
                if (min < workers[minWorker])
                    min = workers[minWorker];
            }

            return min;
            //return workers[getMaxWorker(workers)];
        }

        private int getCurrentMinWorker(int[] workers)
        {
            int index = 0;
            for (int i = 1; i < workers.Length; i++)
            {
                if (workers[index] > workers[i])
                    index = i;
            }
            return index;
        }

        //private int getMaxWorker(int[] workers)
        //{
        //    int index = 0;
        //    for (int i = 1; i < workers.Length; i++)
        //    {
        //        if (workers[index] < workers[i])
        //            index = i;
        //    }
        //    return index;
        //}
    }
}
