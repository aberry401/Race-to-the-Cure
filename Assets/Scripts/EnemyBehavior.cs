using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 movement1;
    private Vector3 movement2;
    public float speed;
    public float xMax;
    public float xMin; 
    public float zMax; 
    public float zMin; 
    public GameController gameController;

    void Start()
    {
        //establishes what angle each type of enemy will move at
        movement1 = new Vector3(1, 0.0f, 0.0f);
        movement2 = new Vector3(1, 0.0f, 1);
    }

    void FixedUpdate()
    {
        //enables Enemy1 objects to move horizontally between set points
        if(tag == "Enemy1")
        {
            transform.Translate(movement1 * speed * Time.deltaTime);
            if (transform.position.x > xMax || transform.position.x < xMin)
            {
                speed *= -1;
            }
        }

        //enables Enemy2 objects to move within set boundaries at a 45 degree angle
        if(tag == "Enemy2")
        {
            transform.Translate(movement2 * speed * Time.deltaTime);
            if (transform.position.x > xMax || transform.position.x < xMin)
            {
                movement2.x *= -1;
            }
            if(transform.position.z > zMax || transform.position.z < zMin)
            {
                movement2.z *= -1;
            }
        }
    }
}
