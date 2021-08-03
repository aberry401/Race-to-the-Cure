using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class ContinuousMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if(music.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
