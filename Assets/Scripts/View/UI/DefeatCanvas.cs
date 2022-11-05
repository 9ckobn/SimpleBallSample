using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatCanvas : MonoBehaviour
{
    [SerializeField] private Text TotalTime;
    [SerializeField] private Text TotalTries;

    void OnEnable()
    {
        TotalTime.text = ((int)Game.Statistic.pastTryTime).ToString();
        TotalTries.text = Game.Statistic.TotalTriesCount.ToString();
    }

    public void RetryButton()
    {
        Game.Statistic.TotalTriesCount++;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        EventListener.OnUIClick();
    }
}
