using System;
using System.Threading;

namespace Tema5Datc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var count = 0;
            while (true)
            {
                Console.WriteLine("Cycle no." + count.ToString());
                Console.WriteLine("Date: " + DateTime.Now.ToLocalTime());
                count++;
                Thread.Sleep(2000);
            }
        }
    }
}
