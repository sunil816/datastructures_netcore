namespace DataStructures;

public class HouseRobbery
{
    public int RobWithOutFirstAndLast(int[] houseWealth)
    {
        int[] maxWealthFromCurrentHouseIndex = new int [houseWealth.Length];
        for (int currentHouseIndex = 0; currentHouseIndex < houseWealth.Length; currentHouseIndex++)
        {
            maxWealthFromCurrentHouseIndex[currentHouseIndex] = -1;
        }
        int maxWealthExcludingLast = MaxWealthFromRobbery(houseWealth, maxWealthFromCurrentHouseIndex, 0, houseWealth.Length - 2);
        for (int currentHouseIndex = 0; currentHouseIndex < houseWealth.Length; currentHouseIndex++)
        {
            maxWealthFromCurrentHouseIndex[currentHouseIndex] = -1;
        }
        int maxWealthExcludingFirst = MaxWealthFromRobbery(houseWealth, maxWealthFromCurrentHouseIndex, 1, houseWealth.Length - 1);
        return Math.Max(maxWealthExcludingFirst, maxWealthExcludingLast);
    }

    private int MaxWealthFromRobbery(int[] houseWealth, int[] maxWealthFromCurrentHouseIndex, int currentHouseIndex, int endHouseIndex)
    {
        if (currentHouseIndex > endHouseIndex)
        {
            return 0;
        }
        if (currentHouseIndex == (houseWealth.Length - 1))
        {
            return houseWealth[currentHouseIndex];
        }

        if (maxWealthFromCurrentHouseIndex[currentHouseIndex] != -1)
        {
            return maxWealthFromCurrentHouseIndex[currentHouseIndex];
        }
        int wealthWithCurrentHouseRob =
            houseWealth[currentHouseIndex] + MaxWealthFromRobbery(houseWealth, maxWealthFromCurrentHouseIndex,currentHouseIndex + 2, endHouseIndex);
        int wealthWithOutCurrentHouseRob = MaxWealthFromRobbery(houseWealth, maxWealthFromCurrentHouseIndex, currentHouseIndex + 1, endHouseIndex);
        int maxWealth = Math.Max(wealthWithCurrentHouseRob, wealthWithOutCurrentHouseRob);
        maxWealthFromCurrentHouseIndex[currentHouseIndex] = maxWealth;
        return maxWealth;
    }
}