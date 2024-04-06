using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeft : MonoBehaviour
{
    public float SpeedMove;
    private Rigidbody2D rb;
    private Animator anim;

    bool Active;
    public float healthboar = 3;
    void Start()
    {
        SpeedMove = -3f;
        rb = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
    }

    private void OnBecameVisible() //sự kiện gọi khi mà đối tượng chứa scrip này xuất hiện trên
    {   
        Active = true;
    }
    private void OnBecameInvisible() //sự kiện này được gọi khi mà đối tượng chứa script này k xuất hiện
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Destroy(gameObject);
        }
        if (Active)
        {
            anim.Play("Enemy_BoarWallk");
            rb.velocity = new Vector2(SpeedMove,rb.velocity.y);
        }

        if (healthboar == 0)
        {
            Destroy(gameObject);
        }
    }
}
