using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Replace "YourSceneName" with the name of the scene you want to switch to
    public string sceneToLoad;

    void Update()
    {
        // Check if the left mouse button (Mouse0) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
