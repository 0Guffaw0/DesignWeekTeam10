using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSFX : MonoBehaviour
{
    public AudioSource selectSound; 

    void Awake()
    {
  DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            selectSound.Play();
        }
    }


}
