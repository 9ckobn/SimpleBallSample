using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : Creator
{
    [SerializeField] private Obstacle ObstaclePrefab;
    GameObject Obstacle;

    Vector3 startPosition;
    Vector3 ObstaclePosition;

    Bounds obstacleBounds;

    [ContextMenu("Generate")]
    void Start()
    {
        startPosition = WorldCorners(0, 0);

        ObstaclePosition = NewPosition(startPosition);

        Obstacle = Instantiate(ObstaclePrefab.gameObject, ObstaclePosition, Quaternion.identity);

        obstacleBounds = Obstacle.GetComponent<BoxCollider2D>().bounds;
    }

    Vector3 NewPosition(Vector3 pastPosition) => new Vector3(pastPosition.x + LevelConfig.fieldSize * LevelConfig.obstacleDistance, pastPosition.y, 0);

    void Update()
    {
        if (WorldCorners(0, 0).x > Obstacle.transform.position.x)
        {
            var pastPosition = Obstacle.transform.position;
            Obstacle.transform.position = NewPosition(pastPosition);
            Obstacle.GetComponent<Obstacle>().SetNewPosition();
        }
    }
}
