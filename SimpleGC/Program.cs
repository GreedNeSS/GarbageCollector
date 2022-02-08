using System;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Estimated bytes on heap: {GC.GetTotalMemory(false)}");
            Console.WriteLine($"This OS has {GC.MaxGeneration + 1} object generations.\n");

            Car newCar = new Car("Zippo", 100);
            Console.WriteLine(newCar);

            Console.WriteLine($"Generation if newCar is: {GC.GetGeneration(newCar)}");

            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
            {
                tonsOfObjects[i] = new object();
            }

            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"Generation if newCar is: {GC.GetGeneration(newCar)}");

            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine($"Generation if tonsOfObjects[9000] is: {GC.GetGeneration(tonsOfObjects[9000])}");
            }
            else
                Console.WriteLine($"tonsOfObjects[9000] is not longer alive.");

            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
        }
    }
}
