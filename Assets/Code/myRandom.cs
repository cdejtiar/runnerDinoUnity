public static class myRandom
{

    public static bool RandomBool(float chance)
    {
        return UnityEngine.Random.Range(0f, 1f) < chance;
    }
}