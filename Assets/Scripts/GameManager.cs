using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball Ball;

    public static GameManager Instance;

    public float TimeToSetBallFree = 1f;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        Ball.CanMove(false);
        Ball.ResetPosition();
        Invoke(nameof(SetBallFree), TimeToSetBallFree);
    }

    private void SetBallFree()
    {
        Ball.CanMove(true);
    }

    public void StartGame()
    {
        Ball.CanMove(true);
    }
}
