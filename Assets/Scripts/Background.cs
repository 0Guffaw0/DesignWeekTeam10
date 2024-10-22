using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bgRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

        if (Input.GetKeyUp(KeyCode.A))
        {
            speed += 0.1f;
        }
        else if (Input.GetKeyUp(KeyCode.S) && !(speed <= 0))
        {
            speed -= 0.1f;
        }
    }

}
