using System;
using Xunit;
using Exam_02PM;

namespace TestProject1
{
    public class UnitTest2
    {
        [Fact]
        public void TestFloydAlgorithm()
        {
            double[,] inputMatrix = new double[,]
            {
                {0, 1, 2, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue},
                {1, 0, 1, 2, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue},
                {2, 1, 0, 1, 2, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue},
                {double.MaxValue, 2, 1, 0, 1, 2, double.MaxValue, double.MaxValue, double.MaxValue},
                {double.MaxValue, double.MaxValue, 2, 1, 0, 1, 2, double.MaxValue, double.MaxValue},
                {double.MaxValue, double.MaxValue, double.MaxValue, 2, 1, 0, 1, 2, double.MaxValue},
                {double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 2, 1, 0, 1, 2},
                {double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 2, 1, 0, 1},
                {double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 2, 1, 0}
            };

            double[,] expectedMatrix = new double[,]
            {
                {0, 1, 2, 3, 4, 5, 6, 7, 8},
                {1, 0, 1, 2, 3, 4, 5, 6, 7},
                {2, 1, 0, 1, 2, 3, 4, 5, 6},
                {3, 2, 1, 0, 1, 2, 3, 4, 5},
                {4, 3, 2, 1, 0, 1, 2, 3, 4},
                {5, 4, 3, 2, 1, 0, 1, 2, 3},
                {6, 5, 4, 3, 2, 1, 0, 1, 2},
                {7, 6, 5, 4, 3, 2, 1, 0, 1},
                {8, 7, 6, 5, 4, 3, 2, 1, 0}
            };

            double[,] resultMatrix = Frag.Floyd(inputMatrix, 9);

            int rows = resultMatrix.GetLength(0);
            int cols = resultMatrix.GetLength(1);

            Assert.Equal(9, rows);
            Assert.Equal(9, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Assert.Equal(expectedMatrix[i, j], resultMatrix[i, j]);
                }
            }
        }
    }
}
