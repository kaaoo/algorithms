using System;
using System.Diagnostics;

class Solution
{
    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < q; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            long n = Convert.ToInt64(tokens_n[0]);
            long m = Convert.ToInt64(tokens_n[1]);
            long x = Convert.ToInt64(tokens_n[2]);
            long y = Convert.ToInt64(tokens_n[3]);

            var paths = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                paths[i] = new bool[n];
            }

            for (int a1 = 0; a1 < m; a1++)
            {
                string[] tokens_city_1 = Console.ReadLine().Split(' ');
                int city_1 = Convert.ToInt32(tokens_city_1[0]);
                int city_2 = Convert.ToInt32(tokens_city_1[1]);
                paths[city_1 - 1][city_2 - 1] = true;
                paths[city_2 - 1][city_1 - 1] = true;
            }

            if (x <= y)
            {
                Console.WriteLine(x * n);

                continue;
            }

            var hasPathToLibrary = new bool[n];
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (!hasPathToLibrary[i])
                {
                    // build library 
                    hasPathToLibrary[i] = true;
                    sum = sum + x;
                    for (int j = 0; j < n; j++)
                    {
                        if (paths[i][j])
                        {
                            // build the road
                            hasPathToLibrary[j] = true;
                            sum += y;
                        }
                    }
                }
            }
            
            Console.WriteLine(sum);
        }

        Console.ReadKey();
    }
}
