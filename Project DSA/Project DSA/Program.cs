using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Lenght of Array:");
            int num = Convert.ToInt16(Console.ReadLine());
            int[] arr = new int[num];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = 0;
            Console.WriteLine("Enter Elements in Array");
            for (int i = 0; i < num; i++)
            {
                if (i > num)
                    Console.WriteLine("Array Out Of Bond");
                else
                    arr[i] = Convert.ToInt16(Console.ReadLine());
            }
            //Object of pigeonhole sort class. 
            PigeonHole_Sort ph = new PigeonHole_Sort();
            arr = ph.pigeonhole_sort(arr, num);
            ph.Print(arr);
        }
    }
    class PigeonHole_Sort
    {
        public int[] pigeonhole_sort(int[] arr, int n)
        {
            int min = arr[0];
            int max = arr[0];
            int range, i, j, index;

            //To Find Min and Max in Array.
            for (int a = 0; a < n; a++)
            {
                if (arr[a] > max)
                    max = arr[a];
                if (arr[a] < min)
                    min = arr[a];
            }

            //Initializing Range.
            range = max - min + 1;

            //Container Array.
            int[] phole = new int[range];

            //initializing Phole array elements to zero.
            for (i = 0; i < n; i++)
                phole[i] = 0;

            //PigeonHole Sort.
            for (i = 0; i < n; i++)
                phole[arr[i] - min]++;

            index = 0;
            for (j = 0; j < range; j++)
                while (phole[j]-- > 0)
                    arr[index++] = j + min;


            return arr;
        }
        //Function to print sorted array.
        public void Print(int[] arr)
        {
            Console.WriteLine("Sorted Array:");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(+arr[i] + " ");
        }
    }
}
