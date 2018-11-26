using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixMul
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();
        static int n = 1000;
        static int m = 1000;
        static Random r = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine($"Matrix size: {n},{m} x {m},{n}");
            float[,] mat1 = new float[n, m];
            float[,] mat2 = new float[m, n];
            float[,] result = new float[mat1.GetLength(0), mat2.GetLength(1)];

            mat1 = InitMat(mat1);
            mat2 = InitMat(mat2);

            //PrintMatrix(mat1);
            //PrintMatrix(mat2);

            sw.Start();
            result = Multiply(mat1, mat2);
            sw.Stop();
            Console.WriteLine("Sequential time: \t" + sw.ElapsedMilliseconds);
            sw.Reset();
            //PrintMatrix(result);

            sw.Start();
            result = MultiplyParallelTask(mat1, mat2);
            sw.Stop();
            Console.WriteLine("Parallel (Task) time: \t" + sw.ElapsedMilliseconds);
            sw.Reset();
            //PrintMatrix(result);

            sw.Start();
            result = MultiplyParallelThread(mat1, mat2);
            sw.Stop();
            Console.WriteLine("Parallel (Thread) time: " + sw.ElapsedMilliseconds);
            //PrintMatrix(result);
        }

        public static float[,] Multiply(float[,] mat1, float[,] mat2)
        {
            float[,] result = new float[mat1.GetLength(0), mat2.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < mat1.GetLength(1); k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }
            return result;
        }

        public static float[,] MultiplyParallelTask(float[,] mat1, float[,] mat2)
        {
            float[,] result = new float[mat1.GetLength(0), mat2.GetLength(1)];
            Task[] t = new Task[result.GetLength(0)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                int temp = i;
                t[i] = new Task(() =>
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[temp, j] = 0;
                        for (int k = 0; k < mat1.GetLength(1); k++)
                        {
                            result[temp, j] += mat1[temp, k] * mat2[k, j];
                        }
                    }
                });
                t[i].Start();
            }
            Task.WaitAll(t);
            return result;
        }

        public static float[,] MultiplyParallelThread(float[,] mat1, float[,] mat2)
        {
            float[,] result = new float[mat1.GetLength(0), mat2.GetLength(1)];
            Thread[] t = new Thread[result.GetLength(0)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                int temp = i;
                t[i] = new Thread(() =>
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[temp, j] = 0;
                        for (int k = 0; k < mat1.GetLength(1); k++)
                        {
                            result[temp, j] += mat1[temp, k] * mat2[k, j];
                        }
                    }
                });
                t[i].Start();
            }

            foreach (Thread item in t)
            {
                item.Join();
            }

            return result;
        }

        public static float[,] InitMat(float[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = (float)r.NextDouble();
                }
            }
            return mat;
        }

        public static void PrintMatrix(float[,] mat)
        {
            Console.WriteLine("[");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("]");
        }
    }
}
