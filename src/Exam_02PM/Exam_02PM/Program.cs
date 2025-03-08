using Exam_02PM;
using System;
using System.Globalization;
using System.IO;

class Program
{
    private static int n = 9;

    private static int GetValidInput(string message, int min, int max)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value >= min && value <= max)
                return value;
            Console.WriteLine("Ошибка: введите корректное число в указанном диапазоне.");
        }
    }

    private static double[,] ReadMatrixFromFile(string filename)
    {
        double[,] matrix = new double[n, n];
        try
        {
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < n; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < n; j++)
                {
                    string value = values[j].Trim();
                    if (value == "Inf")
                        matrix[i, j] = double.MaxValue;
                    else
                    {
                        if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out matrix[i, j]))
                        {
                            Console.WriteLine($"Ошибка при парсинге числа: {value}");
                            matrix[i, j] = double.MaxValue;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка при чтении файла: " + e.Message);
        }
        return matrix;
    }

    static void Main()
    {
        Console.Write("Введите имя файла с данными: ");
        string filename = Console.ReadLine();

        double[,] matrix = ReadMatrixFromFile(filename);

        double[,] shortestPaths = Frag.Floyd(matrix, n);

        Console.WriteLine("Введите три номера точек маршрута (от 1 до 9):\n");
        int point1 = GetValidInput("Первая точка: ", 1, n) - 1;
        int point2 = GetValidInput("Вторая точка: ", 1, n) - 1;
        int point3 = GetValidInput("Третья точка: ", 1, n) - 1;

        int[] order = { point1, point2, point3 };
        double minDistance = double.MaxValue;
        int[] bestOrder = new int[3];

        foreach (int[] perm in new int[][]{
            new int[] { point1, point2, point3 },
            new int[] { point1, point3, point2 },
            new int[] { point2, point1, point3 },
            new int[] { point2, point3, point1 },
            new int[] { point3, point1, point2 },
            new int[] { point3, point2, point1 }
        })
        {
            double dist = shortestPaths[perm[0], perm[1]] + shortestPaths[perm[1], perm[2]];
            if (dist < minDistance)
            {
                minDistance = dist;
                bestOrder = (int[])perm.Clone();
            }
        }

        Console.WriteLine($"Оптимальный маршрут: {bestOrder[0] + 1} -> {bestOrder[1] + 1} -> {bestOrder[2] + 1}");
        Console.WriteLine($"Длина маршрута: {minDistance}");
    }
}
