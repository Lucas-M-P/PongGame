using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Key setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.W;
    public KeyCode KeyCodeMoveDown = KeyCode.S;

    [Header("Moviment setup")]
    public float Speed = 15;
    public Rigidbody2D MyRigidbody2D;

    [Header("Points")]
    public int CurrentPoints;
    public TextMeshProUGUI TextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

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

    public void AddPoints()
    {
        CurrentPoints++;
        UpdateIU();
    }

    private void ResetPlayer()
    {
        CurrentPoints = 0;
        UpdateIU();
    }

    private void UpdateIU()
    {
        TextPoints.text = CurrentPoints.ToString();
    }
}
