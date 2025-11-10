using System;
using System.Runtime.CompilerServices;
using Lab2.Class;

// Problems
// determinator for non-square matrix (should give null)

public static class Program
{
    static void Main(string[] args)
    {
        // ShowcaseMatrix();
        Matrix matrix1 = new Matrix(new int[,] {
            { 0, 2, 3 },
            { 4, 0, 6 },
            { 1, 2, 0 }
        });
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine(matrix1.Determinator);
    }

    static void ShowcaseMatrix()
    {
        Console.WriteLine("=== Matrix Class Demonstration ===\n");

        // Showcase 1: Creating matrices
        Console.WriteLine("1. Creating Matrices:");
        Matrix matrix1 = new Matrix(new int[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        });

        Matrix matrix2 = new Matrix(new int[,] {
            {2, 0, 1},
            {1, 2, 3},
            {0, 1, 2}
        });

        Matrix nonSquareMatrix = new Matrix(new int[,] {
            {1, 2, 3},
            {4, 5, 6}
        });

        Console.WriteLine("Matrix 1:\n" + matrix1);
        Console.WriteLine("Matrix 2:\n" + matrix2);
        Console.WriteLine("Non-square Matrix:\n" + nonSquareMatrix);

        // Showcase 2: GetSize method
        Console.WriteLine("2. Matrix Sizes:");
        var size1 = matrix1.GetSize();
        var size2 = nonSquareMatrix.GetSize();
        Console.WriteLine($"Matrix 1 size: {size1.Item1}x{size1.Item2}");
        Console.WriteLine($"Non-square matrix size: {size2.Item1}x{size2.Item2}");

        // Showcase 3: SetSize method
        Console.WriteLine("\n3. Resizing Matrix:");
        Console.WriteLine("Before resize:\n" + matrix1);
        matrix1.SetSize(4, 2);
        Console.WriteLine("After resizing to 4x2:\n" + matrix1);

        // Reset matrix1 for further tests
        matrix1 = new Matrix(new int[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        });

        // Showcase 4: Determinator property
        Console.WriteLine("4. Determinants:");
        Console.WriteLine($"Matrix 1 determinant: {matrix1.Determinator}");
        Console.WriteLine($"Matrix 2 determinant: {matrix2.Determinator}");
        Console.WriteLine(String.Format("Non-square matrix determinant: {0}", (nonSquareMatrix.Determinator == null) ? "null" : nonSquareMatrix.Determinator));

        // Showcase 5: Indexer
        Console.WriteLine("\n5. Indexer Access:");
        Console.WriteLine($"matrix1[0,0] = {matrix1[0, 0]}");
        Console.WriteLine($"matrix1[1,1] = {matrix1[1, 1]}");

        // Modify using indexer
        matrix1[1, 1] = 99;
        Console.WriteLine($"After matrix1[1,1] = 99:\n{matrix1}");
        Console.WriteLine($"Determinant after modification: {matrix1.Determinator}");

        // Showcase 6: Increment/Decrement operators
        Console.WriteLine("6. Increment/Decrement Operators. Postfix:");
        Matrix incremented = matrix1++; // incremented must be same as matrix1
        Matrix decremented = matrix1--; // decremented must be same as matrix1++
        // postfix decrement operation will be executed in the end
        Console.WriteLine("Incremented matrix:\n" + incremented);
        Console.WriteLine("Decremented matrix:\n" + decremented);

        // Showcase 7: Increment/Decrement operators
        Console.WriteLine("7. Increment/Decrement Operators. Prefix:");
        incremented = ++matrix1; // incremented must be same as matrix1++
        decremented = --matrix1; // decremented must be same as (matrix1++)--, i.e same as matrix1
        Console.WriteLine("Incremented matrix:\n" + incremented);
        Console.WriteLine("Decremented matrix:\n" + decremented);

        // Showcase 8: Comparison operators
        Console.WriteLine("8. Comparison Operators:");
        Console.WriteLine($"matrix1 == matrix2: {matrix1 == matrix2}");
        Console.WriteLine($"matrix1 != matrix2: {matrix1 != matrix2}");

        // Showcase 9: Implicit conversion to int
        Console.WriteLine("\n9. Implicit Conversion to int:");
        int zeroCount = matrix2; // matrix2 has one zero element
        Console.WriteLine($"Number of zeros in matrix2: {zeroCount}");

        // Showcase 10: String extension method demonstration
        Console.WriteLine("\n10. String Extension Method:");
        string testString = "Hello World";
        char[] searchChars = { 'x', 'y', 'z' };
        char[] searchChars2 = { 'H', 'e', 'l' };

        Console.WriteLine($"String '{testString}' contains any of ['x','y','z']: {testString.Contains(searchChars)}");
        Console.WriteLine($"String '{testString}' contains any of ['H','e','l']: {testString.Contains(searchChars2)}");

        // Showcase 11: Matrix extension method
        Console.WriteLine("\n11. Matrix Extension Method:");
        Console.WriteLine($"matrix1 is square: {matrix1.IsSquare()}");
        Console.WriteLine($"nonSquareMatrix is square: {nonSquareMatrix.IsSquare()}");

        // Showcase 12: Error handling with indexer
        Console.WriteLine("\n12. Error Handling:");
        try
        {
            int value = matrix1[10, 10]; // Invalid index
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }

        // Showcase 13: Determinant recalculation after modification
        Console.WriteLine("\n13. Determinant Recalculation:");
        Matrix testMatrix = new Matrix(new int[,] {
            {1, 2},
            {3, 4}
        });
        Console.WriteLine("Initial matrix:\n" + testMatrix);
        Console.WriteLine($"Initial determinant: {testMatrix.Determinator}");

        testMatrix[0, 0] = 5;
        Console.WriteLine("After modifying [0,0] to 5:\n" + testMatrix);
        Console.WriteLine($"Recalculated determinant: {testMatrix.Determinator}");

        Console.WriteLine("\n=== Demonstration Complete ===");
    }

    private static bool Contains (this string str, char[] cArr)
    {
        HashSet<char> cSet = new HashSet<char>(cArr); // transform arr to set for faster search
        cSet.IntersectWith(str);
        return cSet.Count != 0; // if cSet intersection is not 0 than str contains at least one char from cArr
    }

    private static bool IsSquare (this Matrix matrix)
    {
        var (h, w) = matrix.GetSize();
        return h == w;
    }
}

