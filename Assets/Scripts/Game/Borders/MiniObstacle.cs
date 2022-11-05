using UnityEngine;

public class MiniObstacle : MonoBehaviour
{
    private float totalTime;

    void Update()
    {
        totalTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EventListener.OnDefeated(totalTime);
    }
}
