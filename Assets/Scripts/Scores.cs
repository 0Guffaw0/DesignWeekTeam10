using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    [SerializeField]
    public TMP_Text[] scores = new TMP_Text[5];

    public void DisplayHighScore(int position, string name, int time)
    {
        scores[position].text = name + " " + string.Format("{0:000000}", time);
    }

    public void OnBackButton()
    {
        //scores[0].text = "Test text";
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        string name;
        int time;
        /*
        for (int i = 0; i < scores.Length; i++)
        {
            DisplayHighScore(i, name, time);
        }
        */
        DisplayHighScore(0, "test", );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
