using System;
using System.Text;
using MatrixLibrary;

namespace MatrixClientProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Matrix matrixA = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix matrixB = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
            Matrix matrixC = new Matrix(2, 2); // Initialized with zeros

            Console.WriteLine("Matrix A:");
            Console.WriteLine(matrixA);

            Console.WriteLine("Matrix B:");
            Console.WriteLine(matrixB);

            Console.WriteLine("Matrix C:");
            Console.WriteLine(matrixC);

            // Test addition operator
            Console.WriteLine("A + B:");
            Console.WriteLine(matrixA + matrixB);

            // Test matrix multiplication
            Console.WriteLine("A * B:");
            Console.WriteLine(matrixA * matrixB);

            // Test scalar multiplication
            Console.WriteLine("A * 2:");
            Console.WriteLine(matrixA * 2);

            // Test determinant calculation
            Console.WriteLine("Determinant of A:");
            Console.WriteLine(~matrixA);
            Console.WriteLine();

            // Test true/false operator (non-empty matrix is true, empty would be false)
            if (matrixA)
            {
                Console.WriteLine("Matrix A is non-zero and has a valid size.");
            }
            else
            {
                Console.WriteLine("Matrix A is zero or has invalid dimensions.");
            }
            Console.WriteLine();

            // Test explicit and implicit conversion
            double[,] arrayFromMatrix = (double[,])matrixB;
            Console.WriteLine("Array created from matrix B:");
            for (int i = 0; i < arrayFromMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayFromMatrix.GetLength(1); j++)
                {
                    Console.Write($"{arrayFromMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            double[,] array = { { 1, 1 }, { 2, 1 } };
            Matrix matrixFromArray = array; 
            Console.WriteLine("Matrix created from array:");
            Console.WriteLine(matrixFromArray);

            // Test indexer for getting and setting elements
            Console.WriteLine("Original value at (1, 1) in A:");
            Console.WriteLine(matrixA[1, 1]);
            Console.WriteLine();

            matrixA[1, 1] = 10;
            Console.WriteLine("Updated Matrix A:");
            Console.WriteLine(matrixA);

            // The Equals method
            Matrix matrixD = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
            Console.WriteLine("B == D?");
            Console.WriteLine(matrixB == matrixD);
            Console.WriteLine("B != D?");
            Console.WriteLine(matrixB != matrixD);

            Console.WriteLine("A == B?");
            Console.WriteLine(matrixA == matrixD);
            Console.WriteLine("A != B?");
            Console.WriteLine(matrixA != matrixD);

            // Test comparison operators
            Console.WriteLine("Is A > B?");
            Console.WriteLine(matrixA > matrixB);

            Console.WriteLine("Is A < B?");
            Console.WriteLine(matrixA < matrixB);

            Console.WriteLine("Is A >= B?");
            Console.WriteLine(matrixA >= matrixB);

            Console.WriteLine("Is A <= B?");
            Console.WriteLine(matrixA <= matrixB);


            Console.ReadLine();
        }

    }
}
    

