using System;

namespace FinalizableDisposableClass
{
    class MyResourceWrapper : IDisposable
    {
        private bool isDispose = false;

        private void CleanUp(bool disposing)
        {
            if (!isDispose)
            {
                if (disposing)
                {
                    Console.WriteLine("Dispose");
                }
                Console.WriteLine("Clean up unmanaged resources here.");
            }

            isDispose = true;
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        ~MyResourceWrapper()
        {
            Console.Beep();
            CleanUp(false);
        }
    }

    class Program
    {
        static void MyMethod()
        {
            MyResourceWrapper resourceWrapper1 = new();
            resourceWrapper1.Dispose();

            MyResourceWrapper resourceWrapper2 = new();
        }
        static void Main(string[] args)
        {
            MyMethod();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }
    }
}
