using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MatrixConnectedOnes
    {
        //Each time I encounter a 1, I use BFS to mark all the 1s in this group as -1. That way we can restore the matrix afterwards if needed and also avoid the need for extra memory.

        static int numGroups(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        count++;
                        traverse(matrix, i, j);
                    }
                }
            }
            return count;
        }

        static void traverse(int[][] matrix, int i, int j) 
        {
          if(i<=0 || j<=0)
            return;
          if(i>=matrix.Length || j>=matrix[0].Length)
            return;
          if(matrix[i][j] != 1)
            return;
          matrix[i][j] = -1;
          traverse(matrix, i-1, j);
          traverse(matrix, i+1, j);
          traverse(matrix, i, j-1);
          traverse(matrix, i, j+1);
        }

        public int Island(int[][] matrix)
        {
            if (matrix == null) return 0;
            int row = matrix.Length, column = matrix[0].Length, res = 0;
            if (row * column == 0) return 0;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    if (matrix[i][j] == 1)
                    {
                        res++;
                        mark(matrix, i, j);
                    }
            return res;
        }
                    
        public void mark(int[][] matrix, int x, int y)
        {  
            int row = matrix.Length,column = matrix[0].Length;
            if(x<=0 || x>= row || y<=0 ||y>=column) return;
            if (matrix[x][y] == 1) matrix[x][y] = 0;
            else return;
            mark(matrix,x+1,y+1);
            mark(matrix,x+1,y-1);
            mark(matrix,x-1,y+1);
            mark(matrix,x-1,y-1);          
        }
    }
}
