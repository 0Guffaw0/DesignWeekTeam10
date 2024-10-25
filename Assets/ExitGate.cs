using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGate : MonoBehaviour
{
    // Name of the scene to load when the player reaches the exit
    public string winSceneName = "WinScene";
    win Win;

    //private TMP_Text timerText;

    void Start()
    {
        //timerText = textobj.GetComponent<TMP_Text>();
    }

    // Detect if the player enters the trigger on the exit gate
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player entering the gate
        {
           
            Debug.Log("Player has entered the exit gate! Loading Win Scene...");
            Win.WriteToFile(10f);
            //
            // Load the win screen or scene
            SceneManager.LoadScene(winSceneName);
        }
    }
}
