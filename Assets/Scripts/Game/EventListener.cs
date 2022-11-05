using UnityEngine;

public static class EventListener
{
    public static void OnLVLStart()
    {
        Time.timeScale = 1;
        Game.Statistic.pastTryTime = 0;
    }

    public static void OnObstaclePass()
    {
        Game.AudioHandler.PlaySound(Game.AudioHandler.ObstaclePassSound);
    }

    public static void OnDefeated(float totalTime)
    {
        Game.AudioHandler.PlaySound(Game.AudioHandler.DefeatedSound);

        Game.Statistic.pastTryTime = totalTime;

        Game.defeatCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public static void OnUIClick()
    {
        Game.AudioHandler.PlaySound(Game.AudioHandler.UIClicked);
    }
}
