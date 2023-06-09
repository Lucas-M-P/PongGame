using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball Ball;

    public static GameManager Instance;

    public float TimeToSetBallFree = 1f;

    public List<Player> ListPlayers;

    [Header("Menus")]
    public GameObject UiMainMenu;

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

    public void SetBallFree()
    {
        Ball.CanMove(true);
    }

    public void StartGame()
    {
        StateMachine.Instance.StartGame();
    }

    public void EndGame()
    {
        StateMachine.Instance.EndGame();
    }

    public void ShowMenu()
    {
        UiMainMenu.SetActive(true);
        Ball.CanMove(false);

        foreach (var item in ListPlayers)
        {
            item.ResetPlayer();
        }
    }
}
