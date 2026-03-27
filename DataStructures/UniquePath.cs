namespace DataStructures;
/*
 * There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.
   
   Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.
   
   The test cases are generated so that the answer will be less than or equal to 2 * 10^(9).
    1 3 2 1
    1 2 3 4
 */
public class UniquePath
{
    public int UniquePaths(int m, int n)
    {
        if (m == 1 || n == 1)
        {
            return 1;
        }
        int[] noOfUniqueWaysFromPreviousRow = new int [n+1];
        int[] noOfUniqueWaysFromCurrentRow = new int [n+1];
        for (int col = 0; col < n; col++)
        {
            noOfUniqueWaysFromPreviousRow[col] = 1;
        }

        for (int row = m - 2; row >= 0; row--)
        {
            for (int col = n - 1; col >= 0; col--)
            {
                noOfUniqueWaysFromCurrentRow[col] =
                    noOfUniqueWaysFromCurrentRow[col + 1] + noOfUniqueWaysFromPreviousRow[col];
            }
            for (int col = n - 1; col >= 0; col--)
            {
                noOfUniqueWaysFromPreviousRow[col] =
                    noOfUniqueWaysFromCurrentRow[col];
            }
        }
        return noOfUniqueWaysFromPreviousRow[0];
    }
}