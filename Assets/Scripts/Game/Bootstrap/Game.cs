using System.Text;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Game
{
    public static IInputService InputService;

    public static GameStatistic Statistic;

    public static AudioManager AudioHandler;

    public static DefeatCanvas defeatCanvas;

    public Game()
    {
        RegisterInputService();

        RegisterStatsManager();
    }

    private static void RegisterInputService()
    {
#if PLATFORM_STANDALONE || UNITY_EDITOR
        InputService = new StandaloneInputModule();
#endif
    }

    private static void RegisterStatsManager()
    {
        if (File.Exists(Application.persistentDataPath + "Data.json"))
        {
            var data = File.ReadAllBytesAsync(Path.Combine(Application.persistentDataPath , "Data.json")).Result;
            Statistic = JsonConvert.DeserializeObject<GameStatistic>(Encoding.ASCII.GetString(data));
        }

        if (Statistic == null)
            Statistic = new GameStatistic();
    }
}
