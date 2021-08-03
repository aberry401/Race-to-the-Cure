using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Berry

public class SendToCheckpoint : MonoBehaviour
{
    private GameObject player;
    private Vector3 sendto = new Vector3(0, 0.5f, 0);

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        //sends players back to their respective starting points and halts their momentum
        if (other.CompareTag("Player"))
        {
            other.transform.position = sendto;
            other.GetComponent<Rigidbody>().Sleep();
        }
    }
}
