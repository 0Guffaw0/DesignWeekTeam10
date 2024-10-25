using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Replace "YourSceneName" with the name of the scene you want to switch to
    public string sceneToLoad;
    public string sceneToLoad2;

    void Update()
    {
        // Check if the left mouse button (Mouse0) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            if(mousePos.y > 60)
            {
                SceneManager.LoadScene(sceneToLoad); // Load the specified scene
            }
            else
            {
                SceneManager.LoadScene(sceneToLoad2); // Load the specified scene
            }
            
            
        }
    }
}
