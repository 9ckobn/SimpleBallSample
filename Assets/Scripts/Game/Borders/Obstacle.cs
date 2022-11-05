using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector2 minMax;
    [ContextMenu("Set new size")]
    public void SetNewPosition()
    {
        transform.position = new Vector2(transform.position.x, Random.Range(minMax.x, minMax.y));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EventListener.OnObstaclePass();
    }
}
