using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Lab2.Class
{
    internal class Matrix
    {
        private int[,] matrix;
        private int? determinator = null;
        private bool isDeterminatorActual = false;

        // Constructors
        public Matrix(int[,] matrix) => this.matrix = matrix;
        public Matrix(int h, int w) => this.matrix = new int[h, w];

        // Properties
        public int? Determinator
        {
            get {
                if (!isDeterminatorActual) CalcDeterminator();
                return determinator;
            }
            private set
            {
                determinator = value;
            }
        }
        
        // Public Methods

        // Get sizes of the matrix in a format:
        // [int height, int width]
        public (int, int) GetSize() {
            return (matrix.GetLength(0), matrix.GetLength(1)); 
        }   

        // Set new size of the matrix
        public void SetSize(int newHeight, int newWidth) {
            int[,] newMatrix = new int[newHeight, newWidth];
            var (oldHeight, oldWidth) = GetSize();

            // Fill newMatrix with oldMatrix's number until we finish traversing either of them
            for (int i = 0; i < ((oldHeight < newHeight) ? oldHeight : newHeight ); i++) 
            {
                for (int j = 0; j < ((oldWidth < newWidth) ? oldWidth : newWidth); j++) 
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            this.matrix = newMatrix; // hail new matrix!

            isDeterminatorActual = false;
        }

        public override string ToString()
        {
            string s = "";
            var (h, w) = GetSize();

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    s += $"{matrix[i, j]} ";
                }
                s += "\n";
            }
            return s;
        }

        // Private Methods

        private void CalcDeterminator() 
        {
            var (h, w) = GetSize();
            if (h != w)
            {
                determinator = null;
                return;
            }

            HashSet<int> colDel = new HashSet<int>(w);
            determinator = GetDeterminator_rec(colDel, 0);
            isDeterminatorActual = true;
        }

        private int GetDeterminator_rec(HashSet<int> colDel, int i) {
            var (h, w) = GetSize();

            if (i + 1 == h)
            {
                for (int j = 0; j <= w; j++)
                {
                    if (!colDel.Contains(j)) return matrix[i, j];
                }
            }

            int det = 0;
            int delColNum = 0; // number of deleted columns
            for (int j = 0; j < w; j++)
            {
                if (colDel.Contains(j))
                {
                    delColNum++;
                    continue;
                }

                int sign = ((j+delColNum) % 2 == 0) ? 1 : -1;
                colDel.Add(j);
                det += matrix[i, j] * GetDeterminator_rec(colDel, i+1) * sign;
                colDel.Remove(j);
            }
            return det;
        }

        // Indexator
        public int this[int i, int j]
        {
            get 
            {
                if ((i >= 0 && i < matrix.GetLength(0)) && (j >= 0 && j < matrix.GetLength(1)))
                {
                    return matrix[i, j];
                }
                else 
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
            }
            set 
            {
                if ((i >= 0 && i < matrix.GetLength(0)) && (j >= 0 && j < matrix.GetLength(1)))
                {
                    matrix[i, j] = value;
                    isDeterminatorActual = false;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
            }
        }

        // Operators

        // Addition of all elements
        public static Matrix operator ++(Matrix matrix1)
        {
            var (h, w) = matrix1.GetSize();
            Matrix newMatrix = new Matrix(new int[h, w]);
            

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    newMatrix[i, j] = matrix1[i, j] + 1;
                }
            }
            return newMatrix;
        }

        // Subtraction of all elements
        public static Matrix operator --(Matrix matrix1)
        {
            var (h, w) = matrix1.GetSize();
            Matrix newMatrix = new Matrix(new int[h, w]);


            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    newMatrix[i, j] = matrix1[i, j] - 1;
                }
            }
            return newMatrix;
        }

        // Comparision by determinator (module)
        public static bool operator != (Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Determinator != matrix2.Determinator;
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Determinator == matrix2.Determinator;
        }

        // Implicit int casting by counting number of zero elements
        public static implicit operator int (Matrix matrix1)
        {
            var (h, w) = matrix1.GetSize();
            int zeroAmount = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    zeroAmount += (matrix1[i, j] == 0) ? 1 : 0;
                }
            }

            return zeroAmount;
        }
    }
}
