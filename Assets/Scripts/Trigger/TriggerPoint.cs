using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public string TagToCheck = "Ball";

    public Player Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TagToCheck)
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        Player.AddPoints();
    }
}
