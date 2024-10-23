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

    void DisplayHighScore(int position, string name, float time)
    {
        scores[position].text = name + " " + time;
    }

    public void OnBackButton()
    {
        //scores[0].text = "Test text";
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        ReadFromFile();
    }
    void WriteToFile()
    {
        string path = "Assets/textfiles/scores.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();
    }

    void ReadFromFile()
    {
        string path = "Assets/textfiles/scores.txt";
        StreamReader reader = new StreamReader(path);

        for (int i = 0; i < 5; i++)
        {
            string scoreLine = reader.ReadLine();

            DisplayHighScore(i, scoreLine, 10f);
        }

        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
