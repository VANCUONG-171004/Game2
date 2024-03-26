using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulllet : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,5f);
    } 

    private void Update() {
        rb.velocity = new Vector2(-3f,rb.velocity.y);
        // rb.AddForce(new Vector2(-3f,rb.velocity.y));
    }
    
}
