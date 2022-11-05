using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    float VerticalSpeed = PlayerStats.VerticalSpeed;
    new Rigidbody2D rigidbody2D;
    new CircleCollider2D collider2D;

    private IInputService inputService;

    public bool isActivated = false;
    void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.gravityScale = 0;

        inputService = Game.InputService;
    }

    void Update()
    {
        transform.localEulerAngles -= Vector3.forward / 2;

        if (isActivated)
        {
            Vector3 movementVector = Vector3.down;

            if (inputService.Axis.sqrMagnitude > float.Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(inputService.Axis);
                movementVector.x = 0;
                movementVector.Normalize();
            }

            transform.position += movementVector * PlayerStats.VerticalSpeed;
        }
    }
}
