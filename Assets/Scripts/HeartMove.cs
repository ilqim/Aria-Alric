using UnityEngine;

public class HeartMove : MonoBehaviour
{
    public float speed = 1.0f;
    private bool scored = false;
    [SerializeField] private GameManager gameManager;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void Start()
    {
        Destroy(gameObject, 7f);
    }

    void FixedUpdate(){
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (!scored && other.gameObject.name == "stork")
        {
            gameManager.UpdateScore5();
            Destroy(gameObject);
            
        }
    }
}