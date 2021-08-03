using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
//Berry

public class GameController : MonoBehaviour
{
    public Text ScoreText;
    public Text FinalScoreText;
    public PlayerController player;
    private bool over;
    private bool newhighscore = false;
    private StreamReader sr;
    private AudioSource gameover;
    public AudioSource toStop;
    public GameObject orb;
    private Scores scoreManager;

    void Start()
    {
        scoreManager = GetComponent<Scores>();
        scoreManager.GetScores("Scores.txt");
        gameover = GetComponent<AudioSource>();
        Load("Positions.txt");
    }


    public void GameWin()
    {
        gameover.Play();
        over = true;
        ScoreText.text = "";
        toStop.Stop();
        //stops the player when they reach the capsule
        player.CanMove(false);
        //lets the player restart the game
        FinalScoreText.text = "Final Score: " + player.score;
        foreach(HighScore h in scoreManager.highScores)
        {
            if(h != null && player.score > h.GetScore())
            {
                newhighscore = true;
                PlayerPrefs.SetInt("newscore", player.score);
                break;
            }
        }
    }

    void Update()
    {
        if(!over)
        {
            ScoreText.text = "Score: " + player.score;
        }
        else
        {
            if (!gameover.isPlaying)
            {
                if (newhighscore)
                {
                    SceneManager.LoadScene("NewHighScore");
                }
                else
                {
                    SceneManager.LoadScene("HighScores");
                }
            }
        }
    }

    void Load(string filename)
    {
        bool validFile = true;
        try
        {
            sr = new StreamReader(Application.dataPath + "/" + filename);
            string line = sr.ReadLine();
            bool isPlayer = true;
            while(line != null)
            {
                string[] vals = line.Split(',');
                float x = float.Parse(vals[0]);
                float y = float.Parse(vals[1]);
                float z = float.Parse(vals[2]);
                if (isPlayer)
                {
                    player.transform.position = new Vector3(x, y, z);
                    isPlayer = false;
                }
                else
                {
                    Instantiate(orb, new Vector3(x, y, z), Quaternion.identity);
                }
                line = sr.ReadLine();
            }
        }
        catch(IOException e)
        {
            validFile = false;
            Debug.Log(e.Message);
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("Invalid line in file");
        }
        catch (FormatException)
        {
            Debug.Log("Invalid line in file");
        }
        finally
        {
            if (validFile)
            {
                sr.Close();
            }
        }
    }
}
