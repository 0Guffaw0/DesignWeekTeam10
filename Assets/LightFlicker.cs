using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class LightFlicker : MonoBehaviour
{
    public Light2D light2D;            
    public float minIntensity = 0.5f;  
    public float maxIntensity = 1.5f;  
    public float flickerSpeed = 0.1f; 

    private void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<Light2D>(); 
        }

        
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            
            float randomIntensity = Random.Range(minIntensity, maxIntensity);

            
            light2D.intensity = randomIntensity;

            
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}