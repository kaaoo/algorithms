using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            var countOfTests = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfTests; i++)
            {
                var piggyInfo = Console.ReadLine().Split(' ');
                var maxWeigth = int.Parse(piggyInfo[1]) - int.Parse(piggyInfo[0]);
                var countOfCoinType = int.Parse(Console.ReadLine());
                var weigths = new int[countOfCoinType];
                var values = new int[countOfCoinType];
                for (int j = 0; j < countOfCoinType; j++)
                {
                    var pair = Console.ReadLine().Split(' ');
                    values[j] = int.Parse(pair[0]);
                    weigths[j] = int.Parse(pair[1]);
                }

                var solution = new List<Tuple<bool, int, int>>();
                for (int x = 0; x <= maxWeigth; x++)
                {
                    var currentMinValue = int.MaxValue;
                    var currentWeigth = int.MinValue;

                    solution.Add(Tuple.Create(false, 0, 0));

                    for (int y = 0; y < countOfCoinType; y++)
                    {
                        // сначала пробуем просто монетку посадить
                        if (weigths[y] == x && values[y] <= currentMinValue)
                        {
                            currentMinValue = values[y];
                            currentWeigth = weigths[y];
                        }
                    }

                    for (var f = 1; f < x; f++)
                    {
                        if (solution[f].Item1)
                        {
                            for (int y = 0; y < countOfCoinType; y++)
                            {
                                if (solution[f].Item3 + weigths[y] == x && solution[f].Item2 + values[y] <= currentMinValue)
                                {
                                    currentMinValue = values[y] + solution[f].Item2;
                                    currentWeigth = weigths[y] + solution[f].Item3;
                                }
                            }
                        }
                    }

                    if (currentMinValue != int.MaxValue && x != 0)
                    {
                        solution[x] = Tuple.Create(true, currentMinValue, currentWeigth);
                    }
                }

                Console.WriteLine(solution[maxWeigth].Item1
                    ? string.Format(@"The minimum amount of money in the piggy - bank is {0}.",
                        solution[maxWeigth].Item2)
                    : "This is impossible.");
            }

            Console.ReadKey();
        }
    }
}
