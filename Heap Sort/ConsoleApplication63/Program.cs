using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication63
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t***************");
            Console.WriteLine("\t\t\t\t\t*  HEAP SORT  *");
            Console.WriteLine("\t\t\t\t\t***************");
            Console.Write("\n\n Enter the Number of Element to Sort : ");
            try
            {
                int n = int.Parse(Console.ReadLine());
                int[] array = new int[n];
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" array[{0}] = ", i);
                    array[i] = int.Parse(Console.ReadLine());
                }
                label:
                Console.WriteLine("\n For Ascending Order Press 'A' or 'a'\n For Descending Order Press 'D' or 'd'");
                ConsoleKeyInfo press = Console.ReadKey(true);
                Stopwatch time_execution = new Stopwatch();
                switch (press.KeyChar)
                {
                    case 'A':
                    case 'a':
                        Ascending_HeapSort obj1 = new Ascending_HeapSort();
                        time_execution.Start();
                        obj1.heap_sort(array);
                        time_execution.Stop();
                        break;
                    case 'D':
                    case 'd':
                        Descending_HeapSort obj2 = new Descending_HeapSort();
                        time_execution.Start();
                        obj2.heap_sort(array);
                        time_execution.Start();
                        break;
                    default:
                        Console.WriteLine("\n You Have Press the Wrong Letter");
                        goto label;
                }
                Console.WriteLine();
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(" "+array[i]);
                }
                Console.WriteLine("\n Time Taken by Heap Sort to Sort {0} Number of Elements : " + time_execution.Elapsed.TotalSeconds + " Seconds", array.Length);
            }
            catch(FormatException)
            {
                Console.WriteLine("\n Enter Data in the Correct Format");
            }
        }
    }
    public class Ascending_HeapSort
    {
        public void heap_sort(int[] array)   // Function to perform heap sort
        {
            Max_Heap H1 = new Max_Heap(array.Length);   // Making object of Heap class
            int[] arr = new int[array.Length + 1];   // Create array with +1 length.
            array.CopyTo(arr, 1);   // Store from 1st index to easily know the child of parent
            H1.ConstructHeap(arr);   // Constructing a heap of array
            int unsorted_elements = arr.Length - 1;   // To count how many elements are in sorted form.
            while(unsorted_elements>1)
            {
                H1.swap(arr, 1, unsorted_elements);   // Swapping the root of heap with last element
                unsorted_elements--;   // Decrement in unsorted elements 
                H1.Heapify(1,unsorted_elements);   // Satisfying the heap property
            }
            Array.Copy(H1.heap, 1, array, 0, H1.heap.Length-1);   // copy sorted heap array into argumented array
        
        }
    }
    public class Max_Heap
    {
        public int[] heap;
        public Max_Heap(int length)
        {
            heap=new int[length+1];   // Initializing a heap
        }
        public void ConstructHeap(int[] array)   // Converting the array into Heap
        {
            array.CopyTo(heap,0);
            int parent_index=(heap.Length-1)/2;   // Store the last parent index
            while(parent_index>=1)
            {
                Heapify(parent_index,heap.Length-1);   // Constructing heap
                parent_index--;   // Decrement in parent index
            }
        }
        public void Heapify(int i,int unsorted_element)   // Rearrage a heap to maintain the heap property 
        {
            int left_child = 2 * i;   // Store left child of the current parent
            int right_child = ((2 * i) + 1);   // Store the right child of the current parent
            int largest;
            if(unsorted_element>=left_child&&heap[i]<heap[left_child])
            {
                largest = left_child;
            }
            else
            {
                largest = i;
            }
            if(unsorted_element>=right_child&&heap[right_child]>heap[largest])
            {
                largest = right_child;
            }
            if(largest!=i)
            {
                swap(heap, largest, i);  // Swapping the largest child with parent
                Heapify(largest,unsorted_element);   // Satisfying the heap property
            }
        }
        public void swap(int[] array,int a,int b)  // Function to swap the array elements
        {
            int temp = heap[a];
            heap[a] = heap[b];
            heap[b] = temp;
        }
    }
    public class Descending_HeapSort
    {
        public void heap_sort(int[] array)   // Function to perform heap sort
        {
            Min_Heap H1 = new Min_Heap(array.Length);   // Making object of Heap class
            int[] arr = new int[array.Length + 1];   // Create array with +1 length.
            array.CopyTo(arr, 1);   // Store from 1st index to easily know the child of parent
            H1.ConstructHeap(arr);   // Constructing a heap of array
            int unsorted_elements = arr.Length - 1;   // To count how many elements are in sorted form.
            while (unsorted_elements > 1)
            {
                H1.swap(arr, 1, unsorted_elements);   // Swapping the root of heap with last element
                unsorted_elements--;   // Decrement in unsorted elements 
                H1.Heapify(1, unsorted_elements);   // Satisfying the heap property
            }
            Array.Copy(H1.heap, 1, array, 0, H1.heap.Length - 1);   // copy sorted heap array into argumented array

        }
    }
    public class Min_Heap
    {
        public int[] heap;
        public Min_Heap(int length)
        {
            heap = new int[length + 1];   // Initializing a heap
        }
        public void ConstructHeap(int[] array)   // Converting the array into Heap
        {
            array.CopyTo(heap, 0);
            int parent_index = (heap.Length - 1) / 2;   // Store the last parent index
            while (parent_index >= 1)
            {
                Heapify(parent_index, heap.Length - 1);   // Constructing heap
                parent_index--;   // Decrement in parent index
            }
        }
        public void Heapify(int i, int unsorted_element)   // Rearrage a heap to maintain the heap property 
        {
            int left_child = 2 * i;   // Store left child of the current parent
            int right_child = ((2 * i) + 1);   // Store the right child of the current parent
            int largest;
            if (unsorted_element >= left_child && heap[i] > heap[left_child])
            {
                largest = left_child;
            }
            else
            {
                largest = i;
            }
            if (unsorted_element >= right_child && heap[right_child] < heap[largest])
            {
                largest = right_child;
            }
            if (largest != i)
            {
                swap(heap, largest, i);  // Swapping the largest child with parent
                Heapify(largest, unsorted_element);   // Satisfying the heap property
            }
        }
        public void swap(int[] array, int a, int b)  // Function to swap the array elements
        {
            int temp = heap[a];
            heap[a] = heap[b];
            heap[b] = temp;
        }
    }

}
