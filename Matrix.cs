using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary
{
    public class Matrix : IMatrix
    {

        private int _row;
        private int _column;
        private double[,] array;
        public int Row 
        {
            get => _row;
                
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The number of rows in the matrix must be greater than 0..");
                else
                    _row = value;
            }
        }
        public int Column
        {
            get => _column;

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The number of coluns in the matrix must be greater than 0..");
                else
                    _column = value;
            }
        }
        public double[,] Array
        {
            get => array;
            set
            {
                if (array == null)
                    throw new ArgumentNullException(nameof(array), "Array cannot be null.");

                array = value;

            }
        }
        public Matrix() : this(2, 2)
        {
            array = new double[2, 2] { { 0, 0 }, { 0, 0 } };
        }
        public Matrix(int r, int c)
        {
            if (r <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException();

            _row = r;
            _column = c;            
            array = new double[_row, _column];
            
        }
        public Matrix(double[,] A):this(A.GetLength(0), A.GetLength(1))
        {
            int r = A.GetLength(0);
            int c = A.GetLength(1);
            array = new double[r, c];
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    array[i, j] = A[i, j];
                }
            }
        }
        public Matrix(Matrix A):this(A._row, A._column)
        {
            array = new double[_row, _column];
            for (int i = 0; i < _row; ++i)
            {
                for (int j = 0; j < _column; ++j)
                {
                    array[i, j] = A.array[i, j];
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    sb.Append(array[i, j] + " ");   
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static Matrix operator +(Matrix A, Matrix B)
        {                       
            if (A._row != B._row || A._column != B._column)
                throw new ArgumentOutOfRangeException("For addition, matrices must be of the same size");
            Matrix C = new Matrix(A._row, A._column);

             for (int i = 0; i < A._row; i++)
             {
                 for (int j = 0; j < A._column; j++)
                 {
                     C.array[i, j] = A.array[i, j] + B.array[i, j];
                 }
             }

             return C;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A._column != B._row)
            {
                throw new ArgumentOutOfRangeException("For multiplication, the number of columns of the first matrix must be equal to the number of rows of the second");
            }

            Matrix C = new Matrix(A._row, B._column);

            for (int i = 0; i < A._row; i++)
            {
                for (int j = 0; j < B._column; j++)
                {
                    C.array[i, j] = 0;
                    for (int t = 0; t < A._column; t++)
                    {
                        C.array[i, j] += A.array[i, t] * B.array[t, j];
                    }
                }
            }

            return C;
        }
        public static Matrix operator *(Matrix A, double num)
        {
            Matrix C = new Matrix(A._row, A._column);

            for (int i = 0; i < A._row; i++)
            {
                for (int j = 0; j < A._column; j++)
                {
                    C.array[i, j] = A.array[i, j] * num;
                }
            }
            return C;
        }
        public static double operator ~(Matrix A)
        {           

            if (A._row != A._column)
                throw new ArgumentOutOfRangeException("The determinant can only be found for a square matrix");
            int n = A._row;
            if (n == 1)
                return A.array[0, 0];
            if (n == 2)
                return (A.array[0, 0] * A.array[1, 1]) - (A.array[0, 1] * A.array[1, 0]);
            double det = 0;
            for (int k = 0; k < n; k++)
            {
                Matrix subMatrix = new Matrix(n - 1, n - 1);
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j < k)
                            subMatrix.array[i - 1, j] = A.array[i, j];
                        else if (j < k)
                            subMatrix.array[i - 1, j - 1] = A.array[i, j];
                    }
                }
                det += Math.Pow(-1, k) * A.array[0, k] * ~subMatrix;

            }
            return det;
        }                
        public static bool operator true(Matrix A)
        {
            return (A._row != 0) && (A._column != 0) && (A.array != null);
        }
        public static bool operator false(Matrix A)
        {
            return (A._row == 0) || (A._column == 0) || (A.array == null);
        }
        
        public static explicit operator double[,](Matrix A)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A), "Matrix cannot be null.");

            return A.array;
        }
        
        public static implicit operator Matrix(double[,] a)
        {
            return new Matrix(a);
        }

        public double this[int i, int j]
        {
            get { return array[i, j]; }
            set { array[i, j] = value; }            
        }
        public override int GetHashCode()
        {            
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Matrix)) return false;
            if (obj is Matrix A)
            {
                if (_row != A._row || _column != A._column)
                    return false;

                for (int i = 0; i < _row; i++)
                {
                    for (int j = 0; j < _column; j++)
                    {
                        if (array[i, j] != A.array[i, j])
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool operator ==(Matrix A, Matrix B)
        {
            if (A is null && B is null) return true;
            return  A.Equals(B);
        }
        public static bool operator !=(Matrix A, Matrix B)
        {
            return !(A == B); 
        }
        public static bool operator >(Matrix A, Matrix B)
        {
            return (~A > ~B) && (A != B);
        }
        public static bool operator <(Matrix A, Matrix B)
        {
            return !(A > B) && (A != B);
        }
        public static bool operator <=(Matrix A, Matrix B)
        {
            return (A < B) || (A == B);
        }
        public static bool operator >=(Matrix A, Matrix B)
        {
            return (A > B) || (A == B);
        }

    } 
}
