using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour
{

    public float moveSpeed = 1f; //Base move speed
    public float voiceThreshold = 0.1f; //Threshold for voice
    public float speedMultiplier = 5f; //How fast to go when speaking/yelling

    private Rigidbody2D rb; //Store rigidbody2d

    // Start is called before the first frame update
    void Start()
    {
        //Get character rigidbody2d
        rb = GetComponent<Rigidbody2D>();

        StartMic();
    }

    void StartMic()
    {

    }

    float GetLoudness()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
