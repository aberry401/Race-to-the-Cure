using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//Berry

public class ScoreRetriever : MonoBehaviour
{
    public Text scores;
    private StreamReader sr;
    private bool validFile = true;
    // Start is called before the first frame update
    void Start()
    {
        WriteScores("Scores.txt");
    }

    void WriteScores(string filename)
    {
        try
        {
            sr = new StreamReader(Application.dataPath + "/" + filename);
            string line = sr.ReadLine();
            for(int i = 1; i < 6; i++)
            {
                if (line != null)
                {
                    string[] vals = line.Split(',');
                    scores.text += i + ". " + vals[0] + "   " + vals[1] + "\n";
                    line = sr.ReadLine();
                }
            }
        }
        catch(IOException ioe)
        {
            validFile = false;
            Debug.Log(ioe.Message);
        }
        catch (System.FormatException)
        {
            Debug.Log("Invalid line in file");
        }
        catch (System.IndexOutOfRangeException)
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
