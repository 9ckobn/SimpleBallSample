using System.Collections.Generic;
using UnityEngine;

public class BorderCreator : Creator
{
    private Vector2 leftCorner;
    private Vector2 rightCorner;

    private Vector3 pastPosition;

    private float borderLength;

    private new BoxCollider2D collider2D;

    [SerializeField] private GameObject TilePrefab;
    [SerializeField] private Vector3 SpawnOffset;
    [SerializeField] private float ColliderXOffset;
    [SerializeField] private bool GenerateObstacles;

    private List<Transform> tiles = new List<Transform>();

    private Bounds tileBounds;

    float totalTime = 0;

    public void CreateBorders(bool isBottom)
    {
        if (isBottom)
        {
            leftCorner = WorldCorners(0, 0);
            rightCorner = WorldCorners(1, 0);
            GenerateBorder(leftCorner, rightCorner);
        }
        else
        {
            leftCorner = WorldCorners(0, 1);
            rightCorner = WorldCorners(1, 1);
            GenerateBorder(leftCorner, rightCorner);
        }
    }

    void GenerateBorder(Vector3 leftBorder, Vector3 RightBorder)
    {
        var firstPrefab = Instantiate(TilePrefab, leftCorner, Quaternion.identity, gameObject.transform);
        tiles.Add(firstPrefab.transform);

        tileBounds = firstPrefab.GetComponent<SpriteRenderer>().bounds;

        pastPosition = firstPrefab.transform.position;

        var prefabLength = firstPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        LevelConfig.fieldSize = prefabLength;

        borderLength += prefabLength;

        var tileCount = Vector2.Distance(rightCorner, leftCorner) / prefabLength;

        for (int i = 1; i < tileCount + 5; i++)
        {
            var prefab = Instantiate(TilePrefab, new Vector2(pastPosition.x + prefabLength, pastPosition.y), Quaternion.identity, gameObject.transform);
            pastPosition = prefab.transform.position;
            borderLength += prefabLength;
            tiles.Add(prefab.transform);
        }

        collider2D = gameObject.AddComponent<BoxCollider2D>();
        collider2D.size = new Vector2(borderLength, tileBounds.size.y);
        collider2D.offset = new Vector2(ColliderXOffset, firstPrefab.transform.position.y);
        collider2D.isTrigger = true;
        ColliderXOffset = collider2D.offset.x;

        var rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (WorldCorners(0, 0, SpawnOffset).x > tiles[0].position.x + 5)
        {
            tiles[0].position = new Vector2(tiles[tiles.Count - 1].position.x + tileBounds.size.x, tiles[0].position.y);

            tiles.Add(tiles[0]);
            tiles.Remove(tiles[0]);

            collider2D.offset = new Vector2(ColliderXOffset + tileBounds.size.x, tiles[0].position.y);
            ColliderXOffset = collider2D.offset.x;
        }

        totalTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EventListener.OnDefeated(totalTime);
    }
}
