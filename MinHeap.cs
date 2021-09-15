using System;

namespace binary_heap
{
    class MinHeap<T> where T : IComparable
    {
        T[] data;
        int size_of_heap;
        int max_size;

        // max size of heap
        public int MaxSize { get => max_size; }
        // current number of elements
        public int SizeOfHeap { get => size_of_heap; }

        // creates a new heap with size_of_heap as max size
        public MinHeap(int size_of_heap)
        {
            // are u baka
            if (size_of_heap < 1)
                throw new ArgumentOutOfRangeException("Invalid heap size.");

            this.data = new T[size_of_heap + 1];
            this.size_of_heap = 0;
            this.max_size = size_of_heap;
        }

        // swaps elements
        void Swap(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // recursively moves element up
        void HeapifyUp(int i)
        {
            // if we already at the top, return
            if (i <= 1)
                return;

            // parent index is current index / 2
            int parent = i / 2;

            // if current element less than parent, swap
            if (data[i].CompareTo(data[parent]) == -1)
            {
                Swap(ref data[i], ref data[parent]);
                HeapifyUp(parent);
            }
        }

        // * adds an element
        public void Add(T element)
        {
            // overflow
            if (size_of_heap >= max_size)
                throw new IndexOutOfRangeException("Heap is overflow.");

            // add element to end
            size_of_heap++;
            data[size_of_heap] = element;

            // move element up
            HeapifyUp(size_of_heap);
        }

        // * min element
        public T GetMin()
        {
            // null or something if heap is empty
            if (size_of_heap == 0)
                return default(T);

            // its minheap so...
            return data[1];
        }

        // moves element down
        void HeapifyDown(int i)
        {
            int left = i * 2;
            int right = left + 1;
            int smallest = i;

            // we have left child and its less than current
            if (left <= size_of_heap && data[left].CompareTo(data[i]) == -1)
                smallest = left;
            // or we have right child and its less than current
            else if (right <= size_of_heap && data[right].CompareTo(data[i]) == -1)
                smallest = right;

            // if i == smallest recursion ends
            if (smallest != i)
            {
                Swap(ref data[i], ref data[smallest]);
                HeapifyDown(smallest);
            }
        }

        // * delete min element
        public void DeleteMin()
        {
            // empty heap
            if (size_of_heap == 0)
                throw new InvalidOperationException("Heap is empty.");

            // put last element at top and move it down
            data[1] = data[size_of_heap];
            size_of_heap--;
            HeapifyDown(1);
        }
    }
}