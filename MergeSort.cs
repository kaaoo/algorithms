using System;

class Solution
{
    static void Main(String[] args)
    {
        var arr = new int[] { 7, 5, 2, 3 };
        var sorted = MergeSort(arr);
    }

    private static int[] MergeSort(int[] arr)
    {
        if (arr.Length == 1)
        {
            return arr;
        }

        var left = new int[arr.Length / 2];
        for (int i = 0; i < left.Length / 2 + 1; i++)
        {
            left[i] = arr[i];
        }
        var rigth = new int[arr.Length % 2 == 0 ? arr.Length / 2 : arr.Length / 2 - 1];
        for (int i = 0; i < rigth.Length / 2 + 1; i++)
        {
            rigth[i] = arr[i + arr.Length / 2];
        }

        left = MergeSort(left);
        rigth = MergeSort(rigth);

        var x = 0;
        var y = 0;
        var result = new int[left.Length + rigth.Length];
        for (int i = 0; i < left.Length + rigth.Length; i++)
        {
            if (x > left.Length - 1)
            {
                result[i] = rigth[y];
                y++;
                continue;
            }
            if (y > rigth.Length - 1)
            {
                result[i] = left[x];
                x++;
                continue;
            }

            if (left[x] < rigth[y])
            {
                result[i] = left[x];
                x++;
            }
            else if(y < rigth.Length)
            {
                result[i] = rigth[y];
                y++;
            }
        }

        return result;
    }
}
