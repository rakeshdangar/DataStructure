using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MatrixRectangleCoOrdinates
    {
        // Imagine we have an image. We’ll represent this image as a simple 2D array where every pixel is a 1 or a 0. The image you get is known to have a single rectangle of 0s on a background of 1s. Write a function that takes in the image and returns the coordinates of the rectangle -- either top-left and bottom-right; or top-left, width, and height.
        // {x: 3, y: 2, width: 3, height: 2}
        // [[2,3],[3,5]]
        // [[3,2],[5,3]] //same answer, just with reversed columns/rows
        // {y1: 2, x1: 3, y2: 3, x2: 5}
        // [2, 3, 3, 5]
        // “2 3 3 5” 

        public static void Init()
        {
            int[][] image = new int[][] 
            {
              new int[] {1, 1, 1, 1, 1, 1, 0},
              new int[] {1, 1, 1, 1, 1, 1, 0},
              new int[] {1, 1, 1, 1, 1, 1, 0},
              new int[] {1, 1, 1, 1, 1, 1, 1},
              new int[] {1, 1, 1, 1, 1, 1, 1}
            };
            Console.WriteLine(FindCoordinates(image));
        }

        private static string FindCoordinates(int[][] image)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image[i].Length; j++)
                {
                    if (image[i][j] == 0)
                    {
                        //store the first coordinates
                        sb.AppendLine("x:" + j.ToString() + ", y:" + i.ToString());

                        //Get second coordinates.
                        if(i==image.GetLength(0)-1 && j==image[i].Length-1)
                            sb.Append("x:" + j.ToString() + ", y:" + i.ToString());
                        else
                            sb.Append(FindSecondCo(image, i, j));
                        return sb.ToString();
                    }
                }
            }
            return string.Empty;
        }

        private static string FindSecondCo(int[][] image, int y, int x)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = y; i < image.GetLength(0); i++)
            {
                for (int j = x; j < image[i].Length; j++)
                {                    
                    if (image[i][j] == 0)
                    {
                        y = i;
                        x = j;
                    }
                    else
                        break;
                }
            }
            sb.Append("x:" + (x).ToString() + ", y:" + y.ToString());
            return sb.ToString();
        }
    }
}