using System;
using System.IO;
using System.Threading;

namespace HilosPool
{
    class Program
    {
        const string path = @"C:\Users\hp\Desktop\Tercero\archivoc\";
        static void Main(string[] args)
        {
            for (int i=0; i<=50; i++) 
            {
                ThreadPool.QueueUserWorkItem(CrearTxt, i);
            }
            while (ThreadPool.PendingWorkItemCount > 0) ;


        }
        static void CrearTxt(object data)
        {
            int i = (int)data;

            using (var sw = new StreamWriter(path+i+".txt"))
            {
                sw.WriteLine("Hola soy el hilo: "+Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Hola soy el hilo: " + Thread.CurrentThread.ManagedThreadId);

        }
    }
}
