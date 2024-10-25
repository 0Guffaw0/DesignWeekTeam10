using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayAgainButton()
    {
        //WriteToFile();
        SceneManager.LoadScene(1);
    }
    public void OnMenuButton()
    {
        //WriteToFile();
        SceneManager.LoadScene(0);
    }

    void WriteToFile()
    {

    }
}
