using UnityEngine;

public class stork : MonoBehaviour
{
    public float velocity = 3.0f;
    public Rigidbody2D rb2D;
    public bool isDead;
    public GameManager managerGame;
    public GameObject DeathScreen;

    void Start(){
        Time.timeScale = 1;
        DeathScreen.SetActive(false); 
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            rb2D.linearVelocity = Vector2.up * velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "ScoreArea"){
            managerGame.UpdateScore();
        }else if(collision.gameObject.tag == "ScoreArea5"){
            managerGame.UpdateScore5();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "DeathArea"){
            isDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
        }
    }
}
