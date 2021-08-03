using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Berry

public class HighScoreCreator : MonoBehaviour
{
    private int score;
    public Button nextScene;
    private Scores scoreManager;
    public InputField box;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GetComponent<Scores>();
        scoreManager.GetScores("Scores.txt");
        score = PlayerPrefs.GetInt("newscore");
        nextScene.onClick.AddListener(Go);
    }

    void Go()
    {
        string initials = box.text;
        if (initials.Length == 3)
        {
            initials = initials.ToUpper();
            HighScore newscore = new HighScore(initials, score);
            scoreManager.UpdateScores(newscore, "Scores.txt");
            SceneManager.LoadScene("HighScores");
        }
    }

}
