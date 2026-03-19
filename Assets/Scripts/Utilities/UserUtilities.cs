using UnityEngine;

public static class UserUtilities
{
    public static int GenerateRandomInt(int minInclusive, int maxInclusive)
    {
        return Random.Range(minInclusive, maxInclusive + 1);
    }
}
