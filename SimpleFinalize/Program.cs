using System;

namespace SimpleFinalize
{
    class Program
    {
        class MyResourceWrapper
        {
            ~MyResourceWrapper() => Console.Beep();
        }

        public static void MyMethod()
        {
            MyResourceWrapper rw = new MyResourceWrapper();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit the return key to shut down this app");
            Console.WriteLine("and force the GC to invoke Finalize()");
            Console.WriteLine("for finalizable objects created in this AppDomain.");
            MyMethod();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }
    }
}
