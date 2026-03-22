using System;

namespace DataStructures;

public class FrogJump
{
    public int MinEnergyRequiredForJump(int n, int[] heights)
    {
        if (n == 1)
        {
            return 0;
        }
        int minEnergyRequiredToTravelFromNMinus1Height = AbsoluteMinEnergyRequiredUsingHeighs(from: n-1, to: n, heights);
        
        if (n == 2)
        {
            return minEnergyRequiredToTravelFromNMinus1Height;
        }

        int directStep = AbsoluteMinEnergyRequiredUsingHeighs(from: n-2, to: n, heights);
        int intermediateStep = AbsoluteMinEnergyRequiredUsingHeighs(from: n-2, to: n-1, heights);
        int minEnergyRequiredToTravelFromNMinus2Height = Math.Min(directStep, intermediateStep + minEnergyRequiredToTravelFromNMinus1Height);
        
        if (n == 3)
        {
            return minEnergyRequiredToTravelFromNMinus2Height;
        }

        int minEnergyRequiredToTravelFromCurrentHeight = 0;
        for (int currentPosition = n - 3; currentPosition > 0; currentPosition--)
        {
            int reachDirectly2Steps = AbsoluteMinEnergyRequiredUsingHeighs(from: currentPosition, to: currentPosition+2, heights);
            int reachDirectly1Step = AbsoluteMinEnergyRequiredUsingHeighs(from: currentPosition, to: currentPosition+1, heights);
            minEnergyRequiredToTravelFromCurrentHeight = Math.Min(
                reachDirectly2Steps + minEnergyRequiredToTravelFromNMinus1Height,
                reachDirectly1Step + minEnergyRequiredToTravelFromNMinus2Height
                );
            minEnergyRequiredToTravelFromNMinus1Height = minEnergyRequiredToTravelFromNMinus2Height;
            minEnergyRequiredToTravelFromNMinus2Height = minEnergyRequiredToTravelFromCurrentHeight;
        }
        return minEnergyRequiredToTravelFromCurrentHeight;
    }

    private static int AbsoluteMinEnergyRequiredUsingHeighs(int from, int to, int[] heights)
    {
        return Math.Abs(heights[from - 1] - heights[to - 1]);
    }
}