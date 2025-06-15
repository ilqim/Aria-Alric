using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;
    private void Start(){
        Destroy(gameObject, 12.5f);
    }

    void FixedUpdate(){
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
