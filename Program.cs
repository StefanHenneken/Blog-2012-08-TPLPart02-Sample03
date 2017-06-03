using System;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public struct TaskPara
        {
            public string Name;
            public int Age;
        }
        
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Console.WriteLine("Run Start");
            TaskPara taskPara;
            taskPara.Name = "Karl";
            taskPara.Age = 30;
            Task task1 = Task.Factory.StartNew(new Action<Object>(TaskMethod), taskPara);
            // Task task1 = Task.Factory.StartNew(TaskMethod, taskPara);
            // Task task1 = Task.Factory.StartNew((para) => TaskMethod(para), taskPara);
            // Task task1 = Task.Factory.StartNew(delegate(object para)
            //    {
            //        Console.WriteLine("Name: {0}  Age: {1}", ((TaskPara)para).Name, ((TaskPara)para).Age);
            //    }, taskPara);
            // Task task1 = Task.Factory.StartNew((para) =>
            //    {
            //        Console.WriteLine("Name: {0}  Age: {1}", ((TaskPara)para).Name, ((TaskPara)para).Age);
            //    }, taskPara);
            // Task task1 = new Task(new Action<Object>(TaskMethod), taskPara);
            // task1.Start();
            task1.Wait();
            Console.WriteLine("Run End");
            Console.ReadLine();
        }
        public void TaskMethod(Object para)
        {
            Console.WriteLine("Name: {0}  Age: {1}", ((TaskPara)para).Name, ((TaskPara)para).Age);
        }
    }
}
