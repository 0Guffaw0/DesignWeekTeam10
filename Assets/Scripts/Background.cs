
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public bool isActive;

    [SerializeField]
    private Renderer bgRenderer;

    public SpriteRenderer backgroundSpriteRenderer;
    public Sprite[] backgroundSprites;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

        // Speed adjustment with stopping
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed += 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !(speed <= 0))
        {
            speed -= 0.1f;
        }

        // Material changer for the background
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isActive = !isActive;
        }

        bgRenderer.enabled = isActive;
    }

}
