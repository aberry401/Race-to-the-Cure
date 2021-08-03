using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//Berry

public class FileChecker : MonoBehaviour
{
    private StreamWriter sw;
    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.dataPath + "/Positions.txt"))
        {
            sw = new StreamWriter(Application.dataPath + "/Positions.txt");
            sw.WriteLine("0,0.5,0");
            sw.WriteLine("0,0.5,30.98405");
            sw.WriteLine("20.5,-10.8,207.5");
            sw.WriteLine("29.99983,-10.25,183.172");
            sw.WriteLine("-6.45,-16.7,139.2583");
            sw.WriteLine("12.5,-10.8,199.5");
            sw.WriteLine("28.5,-10.8,199.5");
            sw.WriteLine("9.59,-9.85,183.69");
            sw.WriteLine("0,-19.5,101");
            sw.WriteLine("-16.9,-16.7,128.32");
            sw.WriteLine("20.5,-10.8,191.5");
            sw.WriteLine("2,-18.5,99.5");
            sw.WriteLine("-6.45,-16.7,119.08");
            sw.WriteLine("-2,-18.5,99.5");
            sw.WriteLine("4,-18.5,99.5");
            sw.WriteLine("-5.073761,0.5,12.46348");
            sw.WriteLine("0,-18.5,99.5");
            sw.WriteLine("-4,-18.5,99.5");
            sw.WriteLine("20.4,-18,220.414");
            sw.WriteLine("24.4,-5,220.414");
            sw.WriteLine("16.4,-5,220.414");
            sw.WriteLine("20.4,6,220.414");
            sw.WriteLine("20.3,4.5,248");
            sw.WriteLine("20.3,4.5,254");
            sw.WriteLine("20.3,4.5,236");
            sw.WriteLine("20.3,4.5,242");
            sw.WriteLine("42.02739,-13.12,106.52");
            sw.WriteLine("45.11282,-13.12,112.74");
            sw.WriteLine("43.89561,-13.12,129.78");
            sw.Close();
        }

        if(!File.Exists(Application.dataPath + "/Scores.txt"))
        {
            sw = new StreamWriter(Application.dataPath + "/Scores.txt");
            sw.WriteLine("ADB,7000");
            sw.WriteLine("JOE,5000");
            sw.WriteLine("KAT,3000");
            sw.WriteLine("BEN,2000");
            sw.WriteLine("ZOE,1000");
            sw.Close();
        }
    }
}
