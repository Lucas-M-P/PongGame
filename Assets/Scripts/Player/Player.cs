using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Key setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.W;

    public KeyCode KeyCodeMoveDown = KeyCode.S;

    [Header("Moviment setup")]
    public float Speed = 15;

    public Rigidbody2D MyRigidbody2D;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCodeMoveUp))
        {
            MyRigidbody2D.MovePosition(transform.position + transform.up * Speed);
        }
        else if (Input.GetKey(KeyCodeMoveDown))
        {
            MyRigidbody2D.MovePosition(transform.position + transform.up * Speed * -1);
        }
    }
}
