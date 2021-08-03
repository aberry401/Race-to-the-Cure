using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //sets how far the camera will be from the player
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //makes sure the camera stays with the player at fixed offset as they move
        transform.position = player.transform.position + offset;
    }
}
