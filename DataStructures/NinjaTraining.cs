namespace DataStructures;
/*
 * Ninja is planing this ‘N’ days-long training schedule. Each day, he can perform any one of these three activities. (Running, Fighting Practice or Learning New Moves). Each activity has some merit points on each day. As Ninja has to improve all his skills, he can’t do the same activity in two consecutive days. Can you help Ninja find out the maximum merit points Ninja can earn?
   
   You are given a 2D array of size N*3 ‘POINTS’ with the points corresponding to each day and activity. Your task is to calculate the maximum number of merit points that Ninja can earn.
   
   For Example
   If the given ‘POINTS’ array is [[1,2,5], [3 ,1 ,1] ,[3,3,3] ],the answer will be 11 as 5 + 3 + 3.
 */
public class NinjaTraining
{
    public int MaxMeritPoints(int n, int [][] trainingSchedule)
    {
        int [][] maxMeritPointsRowLevel = new int [n][];
        for (int row = 0; row < n; row++)
        {
            maxMeritPointsRowLevel[row] = new int[3];
            for (int col = 0; col < 3; col++)
            {
                maxMeritPointsRowLevel[row][col] = -1;
            }
        }
        return CalCulateMaxMeritPoints(0, trainingSchedule, maxMeritPointsRowLevel, -1);
    }

    public int CalculateMaxMeritPointsIterative(int n, int[][] trainingSchedule)
    {
        int[] maxMeritPreviousRow = new int[3];
        int maxMeritPoints = 0;
        for (int index = 0; index < 3; index++)
        {
            maxMeritPreviousRow[index] = trainingSchedule[n-1][index];
        }
        int[] maxMeritCurrentRow = new int[3];

        for (int day = n - 2; day >= 0; day--)
        {
            for (int meritIndex = 0; meritIndex < 3; meritIndex++)
            {
                maxMeritCurrentRow[meritIndex] = trainingSchedule[day][meritIndex] 
                    + Math.Max(maxMeritPreviousRow[(meritIndex+1)%3], maxMeritPreviousRow[(meritIndex+2)%3]);
            }
            for (int meritIndex = 0; meritIndex < 3; meritIndex++)
            {
                maxMeritPreviousRow[meritIndex] = maxMeritCurrentRow[meritIndex];
            }
        }
        for (int index = 0; index < 3; index++)
        {
            if (maxMeritPoints < maxMeritPreviousRow[index])
            {
                maxMeritPoints = maxMeritPreviousRow[index];
            }
        }
        return maxMeritPoints;
    }

    int CalCulateMaxMeritPoints(int currentDay, int[][] trainingSchedule, int [][] maxMeritPointsRowLevel, int prevDayScheduleIndex)
    {
        if (currentDay >= trainingSchedule.Length)
        {
            return 0;
        }
        int maxMeritPoints = Int32.MinValue;
        for (int scheduleIndex = 0; scheduleIndex < 3; scheduleIndex++)
        {
            if (scheduleIndex != prevDayScheduleIndex)
            {
                if (maxMeritPointsRowLevel[currentDay][scheduleIndex] == -1)
                {
                    maxMeritPointsRowLevel[currentDay][scheduleIndex] = trainingSchedule[currentDay][scheduleIndex] +
                                                                        CalCulateMaxMeritPoints(currentDay + 1,
                                                                            trainingSchedule, maxMeritPointsRowLevel,
                                                                            scheduleIndex);
                }

                if (maxMeritPoints < maxMeritPointsRowLevel[currentDay][scheduleIndex])
                {
                    maxMeritPoints = maxMeritPointsRowLevel[currentDay][scheduleIndex];
                }
            }
        }
        return maxMeritPoints;
    }
}