using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartup : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private BorderCreator bottomBorder;
    [SerializeField] private BorderCreator upBorder;
    [SerializeField] private ObstacleCreator obstacleCreator;
    [SerializeField] private DefeatCanvas DefeatCanvas;
    [SerializeField] private float playerHorizontalSpeed;

    Player player;

    IEnumerator routine;

    void Start()
    {
        routine = levelHarding();

        StartCoroutine(routine);

        bottomBorder.CreateBorders(true);
        upBorder.CreateBorders(false);

        obstacleCreator.enabled = true;

        player = Instantiate(PlayerPrefab, Vector2.zero, Quaternion.identity, Camera.main.transform).AddComponent<Player>();

        Game.defeatCanvas = DefeatCanvas;

        EventListener.OnLVLStart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            player.isActivated = true;
            EventListener.OnUIClick();
        }

        if (player.isActivated)
            Camera.main.transform.position += new Vector3(playerHorizontalSpeed, 0, 0);
    }

    IEnumerator levelHarding()
    {
        while(true)
        {
            yield return new WaitForSeconds(15);

            playerHorizontalSpeed *= 1.25f;
        }
    }
}
