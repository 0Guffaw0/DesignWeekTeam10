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
    public string[] prevScores = new string[5];

    void DisplayHighScore(int position, string text)
    {
        scores[position].text = text;
    }

    public void OnBackButton()
    {
        //scores[0].text = "Test text";
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //WriteToFile(10f);
        ReadFromFile();
    }
    void WriteToFile(float time)
    {
        string path = "Assets/textfiles/scores.txt";
        StreamReader reader = new StreamReader(path);
        float newTime = time;
        float savedTime = newTime;
        float[] prevScores = new float[5];

        // Get old scores
        for (int i = 0; i < 5; i++)
        {
            prevScores[i] = float.Parse(reader.ReadLine());
        }

        reader.Close();

        StreamWriter writer = new StreamWriter(path, false); // False to overwrite

        // Check if new time is lower than previous times
        for (int i = 0; i < 5; i++)
        {
            // Replace each higher time with lower
            if (savedTime < prevScores[i])
            {
                // Take old time, put in new time
                savedTime = prevScores[i];
                prevScores[i] = newTime;
            }
            // Write the new score
            writer.WriteLine(prevScores[i]);
        }

        writer.Close();
    }

    void ReadFromFile()
    {
        string path = "Assets/textfiles/scores.txt";
        StreamReader reader2 = new StreamReader(path);

        for (int i = 0; i < 5; i++)
        {
            DisplayHighScore(i, reader2.ReadLine());
        }

        reader2.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
