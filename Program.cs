using System;

namespace binary_heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var rand = new Random();
            MinHeap<int> temp_minheap = new MinHeap<int>(21);
            for (int i = 0; i < 20; i++)
            {
                int temp = rand.Next(1, 20);
                Console.Write("   " + temp);
                temp_minheap.Add(temp);
            }

            Console.WriteLine("\n\n" + temp_minheap.ToString());
            Console.WriteLine("\n\n" + temp_minheap.ToStringArray());
        }
    }
}
