using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class WallOscillator : MonoBehaviour
{
    private Vector3 osc = new Vector3(1, 0.0f, 0.0f);
    public float speed;
    public float xMax;
    public float xMin;

    void FixedUpdate()
    {
        //allows walls to move horizontally between two set points
        transform.Translate(osc * speed * Time.deltaTime);
        if(transform.position.x < xMin || transform.position.x > xMax)
        {
            speed *= -1;
        }
    }
}
