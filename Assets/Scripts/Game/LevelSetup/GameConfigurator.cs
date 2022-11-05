using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConfigurator : MonoBehaviour
{
    [SerializeField] private string GameSceneName;

    public void StartGame()
    {
        EventListener.OnUIClick();
        SceneManager.LoadSceneAsync(GameSceneName);
    }
}
