using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solve();

            // tests
            var matrix = new[] { 0, 7, 6 };
            SortQuick(matrix, 0, matrix.Length - 1);
            foreach (var i in matrix)
            {
                Console.Write(i + " ");
            }
        }

        public static int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public static void SortQuick(int[] arr, int left, int right)
        {
            // For Recusrion  
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    SortQuick(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    SortQuick(arr, pivot + 1, right);
            }
        }
    }
}
