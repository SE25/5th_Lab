using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace _5th_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //LVL1_ex_1();
            //LVL1_ex_2();
            //LVL2_ex_6();
            //LVL2_ex_10();
            //LVL2_ex_23(); 
            //LVL3_ex_6();
            //LVL3_ex_4();
        }

        #region LVL1_ex_1
        static void LVL1_ex_1()
        {
            Console.WriteLine(Assemble(5, 8));
            Console.WriteLine(Assemble(5, 10));
            Console.WriteLine(Assemble(5, 11));
        }
        static int Assemble(int teammatesNumber, int candidatesNumber)
        {
            if (teammatesNumber > 0 && candidatesNumber > 0)
            {
                int numberOfCombinations = Factorial(candidatesNumber) / (Factorial(teammatesNumber) * Factorial(candidatesNumber - teammatesNumber));
                return numberOfCombinations;
            }
            else return 0;
        }

        static int Factorial(int n)
        {
            for (int i = n - 1; i > 0; i--)
            {
                n *= i;
            }
            return n;
        }
        #endregion

        #region LVL1_ex_2

        static void LVL1_ex_2()
        {
            Triangle triangle1 = new Triangle(5, 6, 9);
            Triangle triangle2 = new Triangle(4, 5, 9);
            double area1 = triangle1.Area;
            double area2 = triangle2.Area;
            Console.WriteLine($"Triangle #{Max(area1, area2)}");
        }
        static string Max(double a, double b)
        {
            if (a > b) return "1";
            else return "2";
        }


        #endregion

        #region LVL2_ex_6
        static void LVL2_ex_6()
        {
            int[] listA = new int[] { 4, 1, 2, 3, 9, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] listB = new int[] { 4, 1, 2, 3, 9, 0, 5, 12 };
            DeleteMax(listA);
            DeleteMax(listB);
            int c = 0;
            for(int i = listA.Length - listB.Length - 1; i < listA.Length && c < listB.Length; i++)
            {
                listA[i] = listB[c];
                c++;
            }
            for (int i = 0; i < listA.Length - 1; i++)
            {
                Console.Write(listA[i] + "; ");
            }
        }

        static void DeleteMax(int[] list)
        {
            int index = 0;
            int max = list[0];
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > max) { max = list[i]; index = i; }
            }
            list[index] = 0;
            for (int i = index; i < list.Length - 1; i++)
            {
                list[i] = list[i + 1];
            }
        }
        #endregion

        #region LVL2_ex_10

        static void LVL2_ex_10()
        {
            Task();
        }
        static int Task()
        {
            int rows = 0;
            int cols = 0;
            Console.Write("Enter the number of rows: ");
            if (int.TryParse(Console.ReadLine(), out rows))
            {
                Console.Write("Enter the number of cols: ");
                if (int.TryParse(Console.ReadLine(), out cols))
                {
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Enter correct data!");
            if (rows <= 0 || cols <= 0) return 0;
            int[,] matrix13 = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Rows {i + 1}");
                string[] rowElements = Console.ReadLine().Split(' ');
                if (rowElements.Length == cols)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (int.TryParse(rowElements[j], out int element))
                        {
                            matrix13[i, j] = element;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data");
                            return 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not enough elements");
                    return 0;
                }
            }
            int max = matrix13[0, 0];
            int maxIndex = 0;
            int min = matrix13[0, cols - 1];
            int minIndex = cols - 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix13[i, j] > max)
                    {
                        max = matrix13[i, j];
                        maxIndex = j;
                    }
                }
                for (int j = i + 1; j < cols; j++)
                {
                    if (matrix13[i, j] < min)
                    {
                        min = matrix13[i, j];
                        minIndex = j;
                    }
                }
            }
            if(rows == 2 && cols == 2)
            {
                Console.WriteLine("Empty");
                return 0;
            }
            if (maxIndex == minIndex)
            {
                DeleteColumn(minIndex, matrix13, rows, cols);
                cols = cols - 1;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix13[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                DeleteColumn(minIndex, matrix13, rows, cols);
                DeleteColumn(maxIndex, matrix13, rows, cols);
                cols = cols - 2;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix13[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            return 0;
        }
        static void DeleteColumn(int index, int[,] matrix, int rows, int cols)
        {
            cols = cols - 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = index; j < cols; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
            }
        }

        #endregion

        #region LVL2_ex_23 (tackle later)

        static void LVL2_ex_23()
        {
            Matrix matrix1 = new Matrix(6, 6);
            Matrix matrix2 = new Matrix(6, 6);
            matrix1.CreateMatrix();
            matrix2.CreateMatrix();
            int numberOfMaxElements = 5;
            List<(int, int)> elementsToChange1 = new List<(int, int)>(numberOfMaxElements);
            List<(int, int)> elementsToChange2 = new List<(int, int)>(numberOfMaxElements);
            List<(int, int)> alreadyMax1 = new List<(int, int)>();
            List<(int, int)> alreadyMax2 = new List<(int, int)>();
            Console.WriteLine("Matrix 1");
            matrix1.Print();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Matrix 2");
            matrix2.Print();
            Console.WriteLine("------------------------------------------");
            for(int i = 0; i < numberOfMaxElements; i++)
            {
                elementsToChange1.Add(Max(matrix1.CreatedMatrix, alreadyMax1));
            }
            for (int i = 0; i < numberOfMaxElements; i++)
            {
                elementsToChange2.Add(Max(matrix2.CreatedMatrix, alreadyMax2));
            }
            ChangeMatrix(matrix1.CreatedMatrix, elementsToChange1);
            ChangeMatrix(matrix2.CreatedMatrix, elementsToChange2);
            Console.WriteLine("Matrix 1 (changed)");
            matrix1.Print();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Matrix 2 (changed)");
            matrix2.Print();
            Console.WriteLine("------------------------------------------");
        }

        static (int, int) Max(int[,] matrix, List<(int, int)> list)
        {
            int max = -1000;
            (int, int) indexOfMax = (0, 0);
            (int, int) buffer = (0, 0);
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0;j < matrix.GetLength(1); j++)
                {
                    buffer = (i, j);
                    if (matrix[i, j] > max && list.Contains(buffer) == false)
                    {
                        max = matrix[i, j];
                        indexOfMax = (i, j);   
                    }
                }
            }
            list.Add(indexOfMax);
            return indexOfMax;
        }
        static void ChangeMatrix(int[,] list, List<(int, int)> indexes)
        {
            (int, int) tuple;
            for (int i = 0; i < list.GetLength(0); i++)
            {
                for(int j = 0; j < list.GetLength(1); j++)
                {
                    tuple = (i, j);
                    if (indexes.Contains(tuple) && list[i, j] > 0)
                    {
                        list[i, j] *= 2;
                    }
                    else if (indexes.Contains(tuple) && list[i, j] < 0)
                    {
                        list[i, j] /= 2;
                    }
                    else if(list[i, j] > 0)
                    {
                        list[i, j] /= 2;
                    }
                    else
                    {
                        list[i, j] *= 2;
                    }
                }
            }
        }
        #endregion

        #region LVL3_ex_6

        static void LVL3_ex_6()
        {
            Matrix matrix = new Matrix(5, 5);
            matrix.CreateMatrix();
            Console.WriteLine("Initial matrix");
            matrix.Print();
            Console.WriteLine();
            ReassembleColumns(matrix.CreatedMatrix, MaxOnDiagonal, MaxInFirstRow);
            Console.WriteLine("Reassembled matrix");
            matrix.Print();
        }

        static void ReassembleColumns(int[,] matrix, MaxValue index1, MaxValue index2)
        {
            int buffer;
            int indexOfMaxOnDiagonal = index1(matrix);
            int indexOfMaxInRow = index2(matrix);
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                buffer = matrix[i,indexOfMaxInRow];
                matrix[i, indexOfMaxInRow] = matrix[i, indexOfMaxOnDiagonal];
                matrix[i, indexOfMaxOnDiagonal] = buffer;
            }
        }

        static int MaxOnDiagonal(int[,] matrix)
        {
            int max = matrix[0, 0];
            int maxIndex = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max) { max = matrix[i, i]; maxIndex = i; }
            }
            return maxIndex;
        }

        static int MaxInFirstRow(int[,] matrix)
        {
            int max = matrix[0, 0];
            int maxIndex = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[0, i] > max) { max = matrix[0, i]; maxIndex = i; }
            }
            return maxIndex;
        }
        delegate int MaxValue(int[,] matrix);
        #endregion

        #region LVL3_ex_4

        static void LVL3_ex_4()
        {
            Matrix matrix = new Matrix(4, 4);
            matrix.CreateMatrix();
            double sum = SumSquared(matrix.CreatedMatrix, AssembleVector);
            Console.WriteLine("Matrix");
            matrix.Print();
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }

        static double SumSquared(int[,] matrix, Vector vector)
        {
            double sum = 0;
            foreach(int i in vector(matrix, "Upper"))
            {
                sum += Math.Pow(i, 2);
            }
            return sum;
        }

        static int[] AssembleVector(int[,] matrix, string triangle)
        {
            List<int> vector = new List<int>();
            if (triangle == "Lower")
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        vector.Add(matrix[i, j]);
                    }
                }
                return vector.ToArray();
            }
            else if (triangle == "Upper")
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        vector.Add(matrix[i, j]);
                    }
                }
                return vector.ToArray();
            }
            else return vector.ToArray();
        }

        delegate int[] Vector(int[,] matrix, string triangle);
        #endregion
    }

    class Triangle
    {
        private int a;
        private int b;
        private int c;
        private double area;
        private int peremiter;

        public int A
        {
            get
            {
                return a;
            }
            set
            {
                if (a < 0)
                {
                    throw new Exception("No negative numbers allowed");
                }
                else
                {
                    a = value;
                }
            }
        }

        public int B
        {
            get
            {
                return b;
            }
            set
            {
                if (b < 0)
                {
                    throw new Exception("No negative numbers allowed");
                }
                else
                {
                    b = value;
                }
            }
        }

        public int C
        {
            get
            {
                return c;
            }
            set
            {
                if (c < 0)
                {
                    throw new Exception("No negative numbers allowed");
                }
                else
                {
                    c = value;
                }
            }
        }

        public double Area
        {
            get
            {
                return area;
            }
            set
            {
                if (area < 0)
                {
                    throw new Exception("No negative numbers allowed");
                }
                else
                {
                    area = value;
                }
            }
        }
        public int Peremiter
        {
            get
            {
                return peremiter;
            }
            set
            {
                if (peremiter < 0)
                {
                    throw new Exception("No negative numbers allowed");
                }
                else
                {
                    peremiter = value;
                }
            }
        }

        public Triangle(int a, int b, int c)
        {
            if (a + b > c || a + c > b || b + c > a)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                peremiter = a + b + c;
                area = Math.Sqrt(peremiter / 2 * (peremiter / 2 - a) * (peremiter / 2 - b) * (peremiter / 2 - c));
            }
            else Console.WriteLine("This triangle can't exist");
        }
    }

    class Matrix
    {
        private int rows;
        private int cols;
        private int[,] matrix;

        public int Rows
        {
            get { return rows; }
            set 
            {
                if (rows <= 0) throw new Exception("Number of rows must be a positive integer");
                else rows = value;
            }
        }
        public int Cols
        {
            get { return cols; }
            set
            {
                if (cols <= 0)
                {
                    throw new Exception("Number of rows must be a positive integer");
                }
                else cols = value;
            }
        }

        public int[,] CreatedMatrix
        {
            get { if (matrix != null) return matrix; else throw new Exception("Matrix is empty"); }
            set
            {
                if (matrix == null)
                {
                    throw new Exception("Matrix is empty");
                }
                else matrix = value;
            }
        }
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows, cols];
        }

        public void CreateMatrix()
        {
            int seed = DateTime.Now.Second;
            Random r = new Random(seed);
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    matrix[i, j] = r.Next(0, 9);
                }
            }
        }

        public void Print()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
