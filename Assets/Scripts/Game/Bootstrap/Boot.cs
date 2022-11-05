using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Boot : MonoBehaviour
{
    private Game _game;

    void Awake()
    {
        _game = new Game();
    }


    void OnApplicationQuit()
    {
        var gameData = JsonConvert.SerializeObject(Game.Statistic);
        File.WriteAllBytesAsync(Path.Combine(Application.persistentDataPath , "Data.json"), Encoding.ASCII.GetBytes(gameData));
    }
}
