using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MicInput : MonoBehaviour
{

    public float moveSpeed = 1f; //Base move speed
    public float voiceThreshold = 0.01f; //Threshold for voice
    public float speedMultiplier = 10f; //How fast to go when speaking/yelling

    private Rigidbody2D rb; //Store rigidbody2d
    private AudioSource audioSource; //Allows for audio data
    private string mic;
    private int sampleWindow = 128;//Size for data
    private Animator screamAnim; // Animator for handling animations


    void Start()
    {

        //Get character rigidbody2d
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        screamAnim = GetComponent<Animator>();

        //Detects microphones
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        //Starts microphone recording
        mic = Microphone.devices[0]; // Choose the first available mic
        StartMic();

    }

    public void StartMic()
    {
        audioSource.clip = Microphone.Start(mic, true, 10, 44100);
        audioSource.loop = true;

        //Wait to start recording after above 0
        while (!(Microphone.GetPosition(mic) > 0)) { }

        audioSource.Play(); //Plays audio
    }




    void Update()
    {
        if (audioSource.loop)
        {
            float micLoudness = MicLoudness(); //Detect microphone loudness

            //If it is above the threshold, increase movement speed
            float currentSpeed = micLoudness > voiceThreshold ? moveSpeed * speedMultiplier : moveSpeed;

            //Move character to the right
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

            // Handle animation based on microphone loudness
            if (micLoudness > voiceThreshold)
            {
                Debug.Log("Speaking");
                screamAnim.SetBool("IsSpeaking", true); // Set IsSpeaking to true while speaking
            }
            else
            {
                Debug.Log("Not Speaking");
                screamAnim.SetBool("IsSpeaking", false); // Set IsSpeaking to false when not speaking
            }
        }



    }

    float MicLoudness()
    {
        // Create a buffer to read the samples
        float[] samples = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(mic) - sampleWindow + 1;
        if (micPosition < 0) return 0; // Ensure position is valid

        audioSource.clip.GetData(samples, micPosition);

        // Calculate the average amplitude of the samples
        float sum = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        return sum / sampleWindow; // Return average loudness

    }
}
