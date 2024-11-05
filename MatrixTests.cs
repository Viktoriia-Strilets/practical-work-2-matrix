using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;
using System;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Matrix_WithDimensions_GetCreateEmptyMatrixWithSpecifiedDimensions()
        {
            // Arrange
            int rows = 3, columns = 4;

            // Act
            IMatrix matrix = new Matrix(rows, columns);

            // Assert
            Assert.AreEqual(rows, matrix.Row);
            Assert.AreEqual(columns, matrix.Column);
        }
        [TestMethod]
        public void Matrix_WithNullArray_GetThrowArgumentOutOfRangeException()
        {
            // Arrange
            double[,] array = new double[0, 0];
            IMatrix matrix = new Matrix();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Matrix(array));
        }
        [TestMethod]
        public void Matrix_WithInvalidDimensions_GetThrowArgumentOutOfRangeException()
        {
            // Arrange
            int ROW = -1;
            IMatrix matrix = new Matrix();

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => matrix.Row = ROW);
        }
        [TestMethod]
        public void Matrix_FromArray_GetCopyArrayToMatrix()
        {
            // Arrange
            double[,] array = { { 1, 2 }, { 3, 4 } };

            // Act
            Matrix matrix = new Matrix(array);

            // Assert
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(4, matrix[1, 1]);
        }
        [TestMethod]
        public void ToString_GetDisplayMatrixElements()
        {
            // Arrange
            double[,] array = { { 1, 2 }, { 3, 4 } };
            IMatrix matrix = new Matrix(array);
            string expectedOutput = $"1 2 {Environment.NewLine}3 4 {Environment.NewLine}";

            // Act
            string output = matrix.ToString();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }
        [TestMethod]
        public void Operator_Addition_GetAddTwoMatrices()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix matrixB = new Matrix(new double[,] { { 4, 3 }, { 2, 1 } });
            Matrix expected = new Matrix(new double[,] { { 5, 5 }, { 5, 5 } });

            // Act
            Matrix result = matrixA + matrixB;

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Operator_Addition_InvalidDimensions_GetThrowException()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 2 } });
            Matrix matrixB = new Matrix(new double[,] { { 3, 4 }, { 5, 6 } });

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => matrixA + matrixB);
        }
        [TestMethod()]
        public void Operator_Multiplication_GetMultiplyTwoMatrices()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix matrixB = new Matrix(new double[,] { { 2, 0 }, { 1, 2 } });
            Matrix expected = new Matrix(new double[,] { { 4, 4 }, { 10, 8 } });

            // Act
            Matrix result = matrixA * matrixB;

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void Operator_Multiplication_InvalidDimensions_GetThrowException()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix matrixB = new Matrix(new double[,] { { 2, 0 } });

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => matrixA * matrixB);
        }
        [TestMethod]
        public void Operator_ScalarMultiplication_GetMultiplyMatrixByScalar()
        {
            // Arrange
            Matrix matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double scalar = 2;
            Matrix expected = new Matrix(new double[,] { { 2, 4 }, { 6, 8 } });

            // Act
            Matrix result = matrix * scalar;

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Operator_Determinant_GetReturnCorrectDeterminantFor2x2Matrix()
        {
            // Arrange
            Matrix matrix = new Matrix(new double[,] { { 4, 6 }, { 3, 8 } });
            double expectedDet = 14;

            // Act
            double determinant = ~matrix;

            // Assert
            Assert.AreEqual(expectedDet, determinant);
        }
        public void Operator_Determinant_GetReturnCorrectDeterminantFor4x4Matrix()
        {
            // Arrange
            Matrix matrix = new Matrix(new double[,] { { 4, 6, 6, 9 }, { 3, 8, 5, 2 }, { 2, 5, 0, 1 }, { 0, 4, 3, 4 } });
            double expectedDet = -407;

            // Act
            double determinant = ~matrix;

            // Assert
            Assert.AreEqual(expectedDet, determinant);
        }
        [TestMethod]
        public void Operator_Determinant_NonSquareMatrix_GetThrowException()
        {
            // Arrange
            Matrix matrix = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ~matrix);

        }
        [TestMethod]
        public void Equals_TwoIdenticalMatrices_GetTrue()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix matrixB = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            // Act 
            bool res = (matrixA == matrixB);
           
            // Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Equals_TwoDifferentMatrices_GetTrue()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix matrixB = new Matrix(new double[,] { { 4, 3 }, { 2, 1 } });

            // Act 
            bool res = (matrixA != matrixB);
            // Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_True_ValidMatrix_GetTrue()
        {
            // Arrange
            Matrix matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            bool r;
            // Act 
            if (matrix)
                r = true;
            else
                r = false;
            //Assert
            Assert.IsTrue(r);
        }
        [TestMethod]
        public void ExplicitConversion_ToArray_GetCorrect2DArray()
        {
            // Arrange

            Matrix matrix = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            double[,] expectedArray = { { 1, 2 }, { 3, 4 } };

            // Act
            double[,] resultArray = (double[,])matrix;

            // Assert
            
            Assert.AreEqual(expectedArray[0, 0], resultArray[0, 0]);
            Assert.AreEqual(expectedArray[0, 1], resultArray[0, 1]);
            Assert.AreEqual(expectedArray[1, 0], resultArray[1, 0]);
            Assert.AreEqual(expectedArray[1, 1], resultArray[1, 1]);
        }
        [TestMethod]
        public void ImplicitConversion_From2DArray_GetInitializeMatrixCorrectly()
        {
            // Arrange
            double[,] array = { { 5, 6 }, { 7, 8 } };

            // Act
            Matrix matrix = array;

            // Assert
            Assert.AreEqual(5, matrix[0, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
        }
        [TestMethod]
        public void Indexer_GetValue_GetCorrectElement()
        {
            // Arrange
            Matrix matrix = new Matrix(new double[,] { { 9, 10 }, { 11, 12 } });

            // Act
            double value = matrix[0, 1];

            // Assert
            Assert.AreEqual(10, value);
        }
        [TestMethod]
        public void Operator_GreaterThan_GetTrueForLargerDeterminant()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 3, 0 }, { 0, 2 } }); // Det = 6
            Matrix matrixB = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1

            // Act 
            bool res = (matrixA > matrixB);
            //  Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_GreaterThan_GetFalseForLargerDeterminant()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            Matrix matrixB = new Matrix(new double[,] { { 2, 0 }, { 0, 3 } }); // Det = 6

            // Act 
            bool res = (matrixA > matrixB);
            //  Assert
            Assert.IsFalse(res);
        }
        [TestMethod]
        public void Operator_LessThan_GetTrueForSmallerDeterminant()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            Matrix matrixB = new Matrix(new double[,] { { 3, 0 }, { 0, 2 } }); // Det = 6

            // Act 
            bool res = (matrixA < matrixB);
            //  Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_LessThan_GetFalseForSmallerDeterminant()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 4, 0 }, { 0, 1 } }); // Det = 4
            Matrix matrixB = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1

            // Act 
            bool res = (matrixA < matrixB);
            //  Assert
            Assert.IsFalse(res);
        }
        [TestMethod]
        public void Operator_LessThanOrEqual_GetTrueForEqualOrSmallerDeterminant_Equal()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            Matrix matrixB = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            // Act 
            bool res = (matrixA <= matrixB);
            //  Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_LessThanOrEqual_GetTrueForEqualOrSmallerDeterminant_Smaller()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            Matrix matrixB = new Matrix(new double[,] { { 4, 0 }, { 0, 1 } }); // Det = 4
            // Act 
            bool res = (matrixA <= matrixB);
            //  Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_LessThanOrEqual_GetFalseForEqualOrSmallerDeterminant()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            Matrix matrixB = new Matrix(new double[,] { { 4, 0 }, { 0, 1 } }); // Det = 4
            // Act 
            bool res = (matrixB <= matrixA);
            //  Assert
            Assert.IsFalse(res);
        }
        [TestMethod]
        public void Operator_GreaterThanOrEqual_GetTrueForEqualOrLargerDeterminant_Larger()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } }); // Det = 4
            Matrix matrixB = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1

            // Act 
            bool res = (matrixA >= matrixB);
            //  Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_GreaterThanOrEqual_GetTrueForEqualOrLargerDeterminant_Equal()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1
            Matrix matrixB = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1

            // Act 
            bool res = (matrixA >= matrixB);
            //  Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Operator_GreaterThanOrEqual_GetFalseForEqualOrLargerDeterminant()
        {
            // Arrange
            Matrix matrixA = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } }); // Det = 4
            Matrix matrixB = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } }); // Det = 1

            // Act 
            bool res = (matrixB >= matrixA);
            //  Assert
            Assert.IsFalse(res);
        }
    }
}



    
