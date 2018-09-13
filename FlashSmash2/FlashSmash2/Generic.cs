namespace ChangeMe
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Generic
    {
        private static IEnumerable<T[]> ConvertToSingleDimension<T>(this T[,] source)
        {
            for (var row = 0; row < source.GetLength(0); ++row)
            {
                var arRow = new T[source.GetLength(1)];
                for (var col = 0; col < source.GetLength(1); ++col)
                    arRow[col] = source[row, col];
                yield return arRow;
            }
        }
        private static T[,] ConvertToMultiDimensional<T>(this IEnumerable<T[]> source)
        {
            var arrayOfArray = source.ToArray();
            var numberofColumns = (arrayOfArray.Length > 0) ? arrayOfArray[0].Length : 0;
            var twoDimensional = new T[arrayOfArray.Length, numberofColumns];
            for (int row = 0; row < arrayOfArray.GetLength(0); ++row)
                for (int col = 0; col < numberofColumns; ++col)
                    twoDimensional[row, col] = arrayOfArray[row][col];
            return twoDimensional;
        }
    }
}
