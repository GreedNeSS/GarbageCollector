using System;

namespace SimpleDispose
{
    class Program
    {
        class MyResourceWrapper : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("***** Index Dispose *****!");
            }
        }
        static void Main(string[] args)
        {
            using(MyResourceWrapper mr1 = new(),
                mr2 = new(), mr3 = new())
            {
                Console.WriteLine("Work");
            }
        }
    }
}
