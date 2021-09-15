using System;

namespace binary_heap
{
    class Program
    {
        static MinHeap<int> GetRandomIntMinHeap(int size = 10000)
        {
            var rand = new Random();
            MinHeap<int> temp_minheap = new MinHeap<int>(size);
            Console.Write("Random numbers: ");
            for (int i = 0; i < 20; i++)
            {
                int temp = rand.Next(1, 20);
                Console.Write("   " + temp);
                temp_minheap.Add(temp);
            }
            return temp_minheap;
        }

        public static void PrettyOutput<T>(string comment, MinHeap<T> test_heap) where T : IComparable, IFormattable
        {
            Console.WriteLine("\n" + comment + "\n" + test_heap.ToStringArray() + "\n" + test_heap.ToString());
        }

        static void Dialog()
        {
            Console.WriteLine(@"    /\_____/\
   /  o   o  \       HI!! IM CATHEAP!!
  ( ==  ^  == )
   )         (
  (           )
 ( (  )   (  ) )
(__(__)___(__)__)");
            string answer = "";
            while (true)
            {
                // 1. demo 2. manual mode
                Console.WriteLine("1 — demo, 2 — manual mode, 3 — exit");
                answer = Console.ReadLine();
                if (answer == "3")
                    break;
                // demo:
                if (answer == "1")
                {
                    // empty heap
                    MinHeap<int> test_heap = new MinHeap<int>(20);
                    Console.WriteLine("Delete from empty heap:");
                    try
                    {
                        test_heap.DeleteMin();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }

                    // random heap
                    test_heap = GetRandomIntMinHeap(20);
                    PrettyOutput("Random heap:", test_heap);
                    // add element to overflow heap
                    Console.WriteLine("Add element to overflow heap:");
                    try
                    {
                        test_heap.Add(1);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    // min element
                    int temp = test_heap.GetMin();
                    // delete min
                    test_heap.DeleteMin();
                    PrettyOutput("Deleted element: " + temp, test_heap);
                    // add random elem
                    temp = new Random().Next(1, 20);
                    test_heap.Add(temp);
                    PrettyOutput("Added element: " + temp, test_heap);
                }
                // manual mode:
                if (answer == "2")
                {
                    Console.WriteLine("Size of heap:");
                    answer = Console.ReadLine();

                    int size = 0;
                    Int32.TryParse(answer, out size);
                    Console.WriteLine("Elements:");
                    string elems = Console.ReadLine();
                    MinHeap<int> temp_minheap = new MinHeap<int>(size);
                    foreach (var elem in elems.Split(' '))
                        temp_minheap.Add(Int32.Parse(elem));
                    PrettyOutput("Your heap: ", temp_minheap);
                    while (true)
                    {
                        Console.WriteLine("\n1. Add elem; 2. Get min; 3. Delete min; 4. Exit.");
                        answer = Console.ReadLine();
                        if (answer == "4")
                            break;
                        if (answer == "1")
                        {
                            Console.WriteLine("Element:");
                            int element = Int32.Parse(Console.ReadLine());
                            temp_minheap.Add(element);
                            PrettyOutput("Element added", temp_minheap);
                        }
                        if (answer == "2")
                            Console.WriteLine("Min: " + temp_minheap.GetMin());
                        if (answer == "3")
                        {
                            temp_minheap.DeleteMin();
                            PrettyOutput("Min deleted", temp_minheap);
                        }
                    }
                }

            }
        }


        static void Main(string[] args)
        {
            Dialog();
        }
    }
}
