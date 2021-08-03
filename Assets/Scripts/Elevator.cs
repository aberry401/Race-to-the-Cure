using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class Elevator : MonoBehaviour
{
    private Vector3 vert;
    public float speed;
    public float minHeight;
    public float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        vert = new Vector3(0.0f, 1, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the yellow platform near the end up and down
        transform.Translate(vert * speed * Time.deltaTime);
        if(transform.position.y < minHeight || transform.position.y > maxHeight)
        {
            speed *= -1;
        }
    }
}
