using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] Difficulty _difficulty;
    public void ChangeDifficulty()
    {
        EventListener.OnUIClick();
       LevelConfig.currentDifficulty = _difficulty;
    }

}
