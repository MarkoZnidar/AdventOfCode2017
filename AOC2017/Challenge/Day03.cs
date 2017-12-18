using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2017.Challenge
{
    public class Day03
    {
        public int[,] CreateSpiralMatrix(int input)
        {

            int size = (int)Math.Round(Math.Sqrt(input))+1;

            int[,] matrix = new int[size, size];
            int positionX = size / 2; // The middle of the matrix
            int positionY = size % 2 == 0 ? (size / 2) - 1 : (size / 2);
            int direction = 0; // The initial direction is "right"
            int stepsCount = 1; // Perform 1 step in current direction
            int stepPosition = 0; // 0 steps already performed
            int stepChange = 0; // Steps count changes after 2 steps
            
            for (int i = 1; i < size * size; i++)
            {
                // Fill the current cell with the current value
                matrix[positionY, positionX] = i;
                // Check for direction / step changes
                if (stepPosition < stepsCount)
                {
                    stepPosition++;
                }
                else
                {
                    stepPosition = 1;
                    if (stepChange == 1)
                    {
                        stepsCount++;
                    }
                    stepChange = (stepChange + 1) % 2;
                    direction = (direction + 1) % 4;
                }

                // Move to the next cell in the current direction
                switch (direction)
                {
                    case 0:
                        positionY++;
                        break;
                    case 1:
                        positionX--;
                        break;
                    case 2:
                        positionY--;
                        break;
                    case 3:
                        positionX++;
                        break;
                }
            }
            return matrix;
        }


        public int[,] CreateZeroMatrix(int input)
        {
            int size = (int) Math.Round(Math.Sqrt(input))+1;
            int[,] matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[j, i] = 0;
                }
            }

            return matrix;
        }

        public object ComputeSteps(int[,] matrix, int seekValue)
        {
            var originCoordiantes = matrix.CoordinatesOf(1);
            var seekValueCoordinates = matrix.CoordinatesOf(seekValue);
            var x = seekValueCoordinates.Item1 - originCoordiantes.Item1;
            var y = seekValueCoordinates.Item2 - originCoordiantes.Item2;

            var steps = Math.Abs(x) + Math.Abs(y);

            return steps;
        }

        public int FillWithAdjacentValuesAndCompute(int[,] matrix, int size, int seekValue)
        {
                        
            int positionX = size / 2; // The middle of the matrix
            int positionY = size % 2 == 0 ? (size / 2) - 1 : (size / 2);
            int direction = 0; // The initial direction is "right"
            int stepsCount = 1; // Perform 1 step in current direction
            int stepPosition = 0; // 0 steps already performed
            int stepChange = 0; // Steps count changes after 2 steps
            int adjElementsSum = 0;
           

            for (int i = 1; i < size * size; i++)
            {
                // Fill the current cell with the current value
                if (i == 1)
                {
                    matrix[positionY, positionX] = i;
                }
                else
                {

                    var adjElements =  AdjacentElements(matrix, positionY, positionX);

                    if (seekValue != -1)
                    {
                       
                        adjElementsSum = adjElements.Sum();
                        if (adjElementsSum > seekValue)
                        {
                            return adjElementsSum;
                        }

                        matrix[positionY, positionX] = adjElementsSum;
                    }
                    else
                    {
                        matrix[positionY, positionX] = adjElements.Sum();
                    }

                    
                }
                
                // Check for direction / step changes
                if (stepPosition < stepsCount)
                {
                    stepPosition++;
                }
                else
                {
                    stepPosition = 1;
                    if (stepChange == 1)
                    {
                        stepsCount++;
                    }
                    stepChange = (stepChange + 1) % 2;
                    direction = (direction + 1) % 4;
                }

                // Move to the next cell in the current direction
                switch (direction)
                {
                    case 0:
                        positionY++;
                        break;
                    case 1:
                        positionX--;
                        break;
                    case 2:
                        positionY--;
                        break;
                    case 3:
                        positionX++;
                        break;
                }
            }

            return -1;
        }

        public static IEnumerable<T> AdjacentElements<T>(T[,] arr, int row, int column)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            for (int j = row - 1; j <= row + 1; j++)
            for (int i = column - 1; i <= column + 1; i++)
                if (i >= 0 && j >= 0 && i < columns && j < rows && !(j == row && i == column))
                    yield return arr[j, i];
        }
    }

    public static class ExtensionMethods
    {
        public static Tuple<int, int> CoordinatesOf<T>(this T[,] matrix, T value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}