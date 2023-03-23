using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 Speed = new Vector3(1, 1);
    private Vector3 _startSpeed;

    [Header("Ball speed control")]
    public double SpeedDelay = 0.001;
    private double TimePassed = 0;

    [Header("Randomizantion")]
    public Vector2 RandSpeedY = new Vector2(-7, 7);
    public Vector2 RandSpeedX = new Vector2(3, 7);

    private Vector3 _startPosition;

    private bool _canMove = false; 

    private void Awake()
    {
        _startPosition = transform.position;
        _startSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canMove)
        {
            return;
        }


        TimePassed += Time.deltaTime;

        if (TimePassed >= SpeedDelay)
        {
            transform.Translate(Speed);
            TimePassed = 0;
        }

        //transform.Translate(Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnPlayerCollision();
        }
        else
        {
            Speed.y *= -1;
        }
    }

    private void OnPlayerCollision()
    {
        Speed.x *= -1;

        float rand = Random.Range(RandSpeedX.x, RandSpeedX.y);

        if(Speed.x < 0)
        {
            rand *= -1;
        }

        Speed.x = rand;

        rand = Random.Range(RandSpeedY.x, RandSpeedY.y);
        Speed.y = rand;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
        Speed = _startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
