using UnityEngine;

public class HeartMove : MonoBehaviour
{
    public float speed = 1.0f;

    private void Start(){
        Destroy(gameObject, 7f);
    }

    void FixedUpdate(){
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "strok"){
            Destroy(gameObject);
        }
    }
}