using UnityEngine;
public static class ScreenUtility
{
    private static int width;
    private static int height;
    private static bool initialized = false;

    public static void Initialize()
    {
        if (!initialized)
        {
            width = Screen.width;
            height = Screen.height;
            initialized = true;
        }
    }

    public static int GetScreenWidth()
    {
        if (!initialized) Initialize();
        return width;
    }

    public static int GetScreenHeight()
    {
        if (!initialized) Initialize();
        return height;
    }
}
