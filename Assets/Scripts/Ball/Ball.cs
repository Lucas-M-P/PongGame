using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 Speed = new Vector3(1, 1);

    public double SpeedDelay = 0.001;

    private double TimePassed = 0;

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;

        if(TimePassed >= SpeedDelay)
        {
            transform.Translate(Speed);
            TimePassed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Speed.x *= -1;
        }
        else
        {
            Speed.y *= -1;
        }
    }
}
