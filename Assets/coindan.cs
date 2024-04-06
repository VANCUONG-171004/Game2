using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coindan : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(20f, rb.velocity.y);
        // rb.AddForce(new Vector2(-3f,rb.velocity.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("quai1"))
        {
            Destroy(other.gameObject);

        }
        BossLeft bossLeft = other.GetComponent<BossLeft>();
        if (bossLeft != null && other.CompareTag("quai"))
        {
            bossLeft.healthboar--;
        }

        mau_pant mau_Pant = other.GetComponent<mau_pant>();
        if (mau_Pant != null && other.CompareTag("quai"))
        {
            mau_Pant.heathboarcontol--;
        }

    }
}
