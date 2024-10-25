using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 


public class MicInput : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float voiceThreshold = 0.01f;
    public float speedMultiplier = 10f;
    public float yellRange = 10f;
    public GameObject[] Hearts = new GameObject[3];
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private string mic;
    private int sampleWindow = 128;
    private Animator screamAnim;

    public int playerLives = 3;
    //private List<Image> = new List <Images>
    private List<GameObject> ghosts = new List<GameObject>();

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        screamAnim = GetComponent<Animator>();


        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }


        mic = Microphone.devices[0];
        StartMic();


        ghosts.AddRange(GameObject.FindGameObjectsWithTag("Ghost"));
    }

    public void StartMic()
    {
        audioSource.clip = Microphone.Start(mic, true, 10, 44100);
        audioSource.loop = true;


        while (!(Microphone.GetPosition(mic) > 0)) { }

        audioSource.Play();
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f); // Optional: small delay before loading GameOver scene
        SceneManager.LoadScene("GameOver");
    }

    void Update()
    {
        if (audioSource.loop)
        {
            float micLoudness = MicLoudness(); // Detect microphone loudness
            Debug.Log("Mic Loudness: " + micLoudness); // Log mic loudness

            // Calculate movement speed based on mic loudness
            float currentSpeed = micLoudness > voiceThreshold ? moveSpeed * speedMultiplier : moveSpeed;
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y); // Move character

            // Set the scream animation when the voice threshold is crossed
            bool isSpeaking = micLoudness > voiceThreshold;
            screamAnim.SetBool("IsSpeaking", isSpeaking); // Set to true if you're speaking
            Debug.Log("IsSpeaking set to: " + isSpeaking); // Log the state of IsSpeaking

            // Handle ghost fading only if you're speaking and near a ghost
            foreach (var ghost in ghosts)
            {
                if (ghost != null && IsGhostCloseEnough(ghost))
                {
                    if (isSpeaking)
                    {
                        Debug.Log("Speaking, and ghost is close enough!");
                        StartCoroutine(FadeGhost(ghost)); // Start fading the ghost
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // Debug to ensure collision is detected

        if (other.gameObject.CompareTag("Ghost"))
        {
            playerLives--;
            Hearts[playerLives].SetActive(false);
            Debug.Log("Player hit a ghost! Lives remaining: " + playerLives);

            // If the player has no lives left, trigger game over
            if (playerLives <= 0)
            {
                Debug.Log("Game Over Triggered!");
                StartCoroutine(LoadGameOverScene());
            }
        }
    }

    bool IsGhostCloseEnough(GameObject ghost)
    {
        float distanceToGhost = Vector2.Distance(transform.position, ghost.transform.position);
        return distanceToGhost <= yellRange;
    }

    IEnumerator FadeGhost(GameObject ghost)
    {
        SpriteRenderer ghostRenderer = ghost.GetComponent<SpriteRenderer>();

        // Check if the ghostRenderer is null before proceeding
        if (ghostRenderer == null)
        {
            yield break; // Exit if the SpriteRenderer doesn't exist
        }

        // Set the fade speed by adjusting alpha decrement and delay
        float fadeStep = 0.2f; // How much alpha decreases per step (smaller = slower fade)
        float fadeDelay = 0.03f; // Delay between each step (larger = slower fade)

        // Gradually reduce the alpha to fade out
        for (float alpha = 1f; alpha >= 0; alpha -= fadeStep)
        {
            if (ghostRenderer != null) // Ensure the ghostRenderer is still valid
            {
                Color newColor = ghostRenderer.color;
                newColor.a = alpha;
                ghostRenderer.color = newColor;
            }

            // Wait between steps
            yield return new WaitForSeconds(fadeDelay);
        }

        // Destroy the ghost once fully faded
        Destroy(ghost);
    }


    float MicLoudness()
    {

        float[] samples = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(mic) - sampleWindow + 1;
        if (micPosition < 0) return 0;

        audioSource.clip.GetData(samples, micPosition);


        float sum = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        return sum / sampleWindow;
    }
}
