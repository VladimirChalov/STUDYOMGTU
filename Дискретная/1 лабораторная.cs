using System;
using System.Collections.Generic;
namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            int[,] praph = {
            {0, 1, 1, 0, 0, 0},
            {1, 0, 1, 0, 0, 0},
            {1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1},
            {0, 0, 0, 1, 0, 1},
            {0, 0, 0, 1, 1, 0}
        };

            List<int> verifiedNum = new List<int> { 1, 2, 3, 4, 5 };
            List<int> numDone = new List<int> { 0 };
            int result = 0;
            int shag = 0;

            for (int i = 1; i <= 6; i++)
            {
                int m = 0;
                int n;

                if (shag > (numDone.Count - 1))
                {
                    n = verifiedNum[0];
                    numDone.Add(n);
                    res++;
                }
                else
                {
                    n = numDone[shag];
                }

                for (m = 0; m < 6; m++)
                {
                    if (praph[n, m] == 1)
                    {
                        if (verifiedNum.Contains(m))
                        {
                            verifiedNum.Remove(m);
                        }
                        if (!numDone.Contains(m))
                        {
                            numDone.Add(m);
                        }
                    }
                }
                shag++;
            }

            Console.WriteLine(result + 1);
        }
    }
}
