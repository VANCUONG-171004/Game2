using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BoarControl : MonoBehaviour
{
    //Di chuyển đến điểm A
    //sau đó nghỉ 2s
    //Quay đầu và đi đến điểm B
    //Đứng nghỉ 2s
    //Tốc độ di chuyển của nó là 5f 

    //Thấy người chơi(mặt nó nhìn về người chơi) ; tăng tốc lên 8f và di chuyển về phía người chơi
    //nâng cao : nó húc trượt . nó đứng đơ 2s -> quay lại 
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform boar;
    public Transform posA;
    public Transform posB;

    public Transform boarcheck;
    private Vector3 dirition;
    public LayerMask playerLayer;
    private RaycastHit2D hitPlayer;

    public bool atk;

    float speedMove = 3f;
    bool isFacingRight;
    float timer;
    private Rigidbody2D rb;
    public float healthboarcontrol = 3;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Destroy(gameObject);
        }

        if (isFacingRight) //Phải di chuyển qu B
        {
            dirition = Vector3.right;
            if (Vector2.Distance(boar.position, posB.position) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, posB.position, speedMove * Time.deltaTime);
                animator.Play("Enemy_BoarWallk");
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    spriteRenderer.flipX = false;
                    isFacingRight = false;
                    timer = 0;
                }else if(timer <=2f)
                {
                    animator.Play("Enemy_Boar");
                }

            }
        }
        else //măt quay về trái di chuyển qua A
        {
            dirition = Vector3.left;
            if (Vector2.Distance(boar.position, posA.position) > 0.1f)
            {
                boar.position = Vector3.MoveTowards(boar.position, posA.position, speedMove * Time.deltaTime);
                animator.Play("Enemy_BoarWallk");
            }
            else
            {

                timer += Time.deltaTime;
                if(timer >2f)
                {
                    spriteRenderer.flipX = true;
                    isFacingRight = true;
                    timer = 0;
                }else
                {
                    animator.Play("Enemy_Boar");
                }
                
            }
        }

        if(healthboarcontrol == 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        RayDetect();
    }

    public void RayDetect()
    {
        hitPlayer = Physics2D.Raycast(boarcheck.position,dirition,10f,playerLayer);

        if(hitPlayer)
        {
            // Debug.DrawRay(boarcheck.position,dirition * hitPlayer.distance, Color.red);
            
            
        }else
        {
            // Debug.DrawRay(boarcheck.position,dirition * 10f, Color.green);
            
        }
    }
}
