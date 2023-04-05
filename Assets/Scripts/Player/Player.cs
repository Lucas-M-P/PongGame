using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public int MaxPoints;

    [Header("UI")]
    public Image Image;


    public string Name;

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
        CheckMaxPoints();
    }

    public void ResetPlayer()
    {
        CurrentPoints = 0;
        UpdateIU();
    }

    private void UpdateIU()
    {
        TextPoints.text = CurrentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(CurrentPoints >= MaxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }
    }

    public void ChangeColor(Color color)
    {
        Image.color = color;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
}
