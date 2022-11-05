public static class LevelConfig
{
    public static Difficulty currentDifficulty
    {
        set
        {
            switch (value)
            {
                case Difficulty.easy:
                    PlayerStats.VerticalSpeed = 0.02f;
                    break;
                case Difficulty.medium:
                    PlayerStats.VerticalSpeed = 0.075f;
                    break;
                case Difficulty.hard:
                    PlayerStats.VerticalSpeed = 0.1f;
                    break;
                default:
                    currentDifficulty = Difficulty.easy;
                    break;
            }
        }
    }

    public static int obstacleDistance = 15;

    public static float fieldSize;
}

public enum Difficulty
{
    easy,
    medium,
    hard
}
