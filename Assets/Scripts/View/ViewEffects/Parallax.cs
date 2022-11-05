using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float parallaxLength, startPosition;

    private new Camera camera;

    [SerializeField] private float parallaxEffect;

    void Start()
    {
        camera = Camera.main;

        startPosition = transform.position.x;
        parallaxLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));

        float dist = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector2(startPosition + dist, transform.position.y);

        if(temp > startPosition + parallaxLength) startPosition += parallaxLength;
        else if (temp < startPosition - parallaxLength) startPosition -= parallaxLength;
    }
}
