using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Berry

public class BackButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
