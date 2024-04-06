using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ca : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         // Tạo một vectơ hướng di chuyển ngẫu nhiên
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // Áp dụng lực di chuyển lên quái vật
        rb.AddForce(randomDirection * moveSpeed);
    }
}
