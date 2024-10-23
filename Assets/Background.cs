using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] backgrounds; // Array to hold the 4 background objects
    public float scrollSpeed = 2f; // Scrolling speed
    private float backgroundWidth; // Width of one background image

    void Start()
    {
        // Get the width of the first background image
        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Scroll each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Move the background to the left
            backgrounds[i].transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // If the background moves out of view, reposition it to the end
            if (backgrounds[i].transform.position.x <= -backgroundWidth)
            {
                // Calculate the reset position to create a seamless loop
                Vector3 resetPosition = new Vector3(backgroundWidth * (backgrounds.Length - 1),
                                                    backgrounds[i].transform.position.y,
                                                    backgrounds[i].transform.position.z);
                backgrounds[i].transform.position += resetPosition;
            }
        }
    }
}

