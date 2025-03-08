using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02PM
{
    public class Frag
    {
        public static double[,] Floyd(double[,] a, int n)
        {
            double[,] d = new double[n, n];
            d = (double[,])a.Clone();
            for (int i = 1; i <= n; i++)
                for (int j = 0; j <= n - 1; j++)
                    for (int k = 0; k <= n - 1; k++)
                        if (d[j, k] > d[j, i - 1] + d[i - 1, k])
                            d[j, k] = d[j, i - 1] + d[i - 1, k];
            return d;
        }
    }
}
