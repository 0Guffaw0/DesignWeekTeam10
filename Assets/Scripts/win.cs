using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWinButton()
    {
        SceneManager.LoadScene(2);
    }

    public void WriteToFile(float time)
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
}
