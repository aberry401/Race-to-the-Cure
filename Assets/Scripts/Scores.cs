using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//Berry

public class HighScore : IComparable<HighScore>
{
    private string initials;
    private int score;
    public HighScore()
    {
        initials = "AAA";
        score = 0;
    }

    public HighScore(string i, int s)
    {
        initials = i;
        score = s;
    }

    public int CompareTo(HighScore other)
    {
        return score - other.GetScore();
    }

    public int GetScore()
    {
        return score;
    }

    public string GetInitials()
    {
        return initials;
    }
}

public class Scores : MonoBehaviour
{
    public HighScore[] highScores = new HighScore[5];
    private bool validfile = true;
    private StreamReader sr;
    private StreamWriter sw;

    public void GetScores(string filename)
    {
        try
        {
            sr = new StreamReader(Application.dataPath + "/" + filename);
            string line = sr.ReadLine();
            for(int i = 0; i < 5; i++)
            {
                if (line != null)
                {
                    string[] vals = line.Split(',');
                    string initials = vals[0];
                    int score = int.Parse(vals[1]);
                    highScores[i] = new HighScore(initials, score);
                    line = sr.ReadLine();
                }
            }
        }
        catch(IOException ioe)
        {
            validfile = false;
            Debug.Log(ioe.Message);
        }
        catch(FormatException)
        {
            Debug.Log("Invalid line in file");
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("Invalid line in file");
        }
        finally
        {
            if (validfile)
            {
                sr.Close();
            }
        }

    }

    public void UpdateScores(HighScore newScore, string filename)
    {
        highScores[4] = newScore;
        for (int i = 3; i >= 0; i--)
        {
            if (newScore.CompareTo(highScores[i]) > 0)
            {
                highScores[Array.IndexOf(highScores, newScore)] = highScores[i];
                highScores[i] = newScore;
            }
        }

        try
        {
            using (sw = new StreamWriter(Application.dataPath + "/" + filename))
            {
                foreach (HighScore h in highScores)
                {
                    sw.WriteLine(h.GetInitials() + "," + h.GetScore());
                }
            }
        }
        catch (IOException ioe)
        {
            Debug.Log(ioe.Message);
        }
        catch (Exception)
        {
            Debug.Log("What did you do?");
        }
        finally
        {
            sr.Close();
        }
    }
}
