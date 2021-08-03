using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Berry

public class UIScript : MonoBehaviour
{
    public Button start, instructions, highscores, credits, quit;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(Play);
        instructions.onClick.AddListener(Instructions);
        highscores.onClick.AddListener(HighScores);
        credits.onClick.AddListener(Credits);
        quit.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Play()
    {
        SceneManager.LoadScene("Play");
    }

    void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    void Quit()
    {
        Application.Quit();
    }
}
