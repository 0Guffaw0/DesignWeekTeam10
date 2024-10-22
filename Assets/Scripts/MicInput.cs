using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MicInput : MonoBehaviour
{

    public float moveSpeed = 1f; //Base move speed
    public float voiceThreshold = 0.1f; //Threshold for voice
    public float speedMultiplier = 5f; //How fast to go when speaking/yelling

    private Rigidbody2D rb; //Store rigidbody2d
    private AudioSource audioSource;
    private Microphone mic;

    // Start is called before the first frame update
    void Start()
    {
        //Get character rigidbody2d
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        StartMic();
    }

    void StartMic()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            audioSource.clip = Microphone.Start("Microphone (Intel® Smart Sound Technology for Digital Microphones)", true, 10, 44100);
        }

        if (Microphone.IsRecording("Microphone (Intel® Smart Sound Technology for Digital Microphones)"))
        {
            Debug.Log("AHHHH");
        }
    }
}
