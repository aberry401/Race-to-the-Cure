using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class KillMusic : MonoBehaviour
{
    AudioSource newMusic;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject prevMusic = GameObject.FindWithTag("Music");
        AudioSource temp = prevMusic.GetComponent<AudioSource>();
        if (temp.isPlaying)
        {
            Destroy(prevMusic);
        }
        newMusic = gameObject.GetComponent<AudioSource>();
        newMusic.Play();
    }
}
