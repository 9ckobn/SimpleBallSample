using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Obstacle;

    private Vector3 startPoint;
    private Vector3 ObstaclePoint;

    [ContextMenu("Generate")]
    void Generate()
    {
        startPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        ObstaclePoint = new Vector3(startPoint.x + LevelConfig.fieldSize * LevelConfig.obstacleDistance, 0, 0);

        Instantiate(Obstacle, ObstaclePoint, Quaternion.identity, gameObject.transform);

    }
}
