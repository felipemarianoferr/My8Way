using UnityEngine;

public class GameController
{
    private static int collectableCount;

    public static bool timeUp { get; private set; }

    public static float finalElapsed { get; private set; }
    public static float finalRemaining { get; private set; }

    public static bool gameOver
    {
        get { return collectableCount <= 0 || timeUp; }
    }

    public static void Init()
    {
        collectableCount = 4;

        timeUp = false;
        finalElapsed = 0f;
        finalRemaining = 0f;
    }

    public static void Collect()
    {
        collectableCount--;
        if (collectableCount <= 0)
        {
            if (GameTimer.Instance != null)
            {
                finalRemaining = GameTimer.Instance.TimeRemaining;
                finalElapsed = GameTimer.Instance.StartSeconds - finalRemaining;
            }
        }
    }

    public static void NotifyTimeUp(float startSeconds, float remaining)
    {
        timeUp = true;
        finalRemaining = Mathf.Max(0f, remaining);
        finalElapsed = Mathf.Max(0f, startSeconds - remaining);
    }
}
