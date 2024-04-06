using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    public AdsManager ads;
    [Header("heath info")]
    public Slider health;

    public Color fullHealthColor = Color.green; // Màu sắc khi máu đầy
    public Color lowHealthColor = Color.red; // Màu sắc khi máu dưới 30%
    public Color mediumHealthColor = Color.yellow; // Màu sắc khi máu dưới 70%

    [Header("Movement info")]
    public float Speed;
    public float jump;

    public float thoigian = 0;
    public float timer;
    private bool canDoubleJump;
    

    [Header("Audio info")]
    public List<AudioClip> audioClips;
    AudioSource audioSource;
    public GameManager GameManager;
    public GameObject DeathZone;
    public GameObject gidGround;
    public GameObject spamcoin;
    public GameObject player;
    public GameObject heathhoi;

    public GameObject coinsinh;

    [Header("Collison Info")]
    public bool isGrounded;
    // public Transform groundcheck;
    // public float GroundDistance;
    public Transform checkground;
    public Transform enemycheck;
    public LayerMask whatisGround;
    public LayerMask enemyLayer;

    private Rigidbody2D rb;
    private Animator anim;


    void Start()
    {
        health.maxValue = 100;
        health.value = health.maxValue;
        health.fillRect.GetComponent<Image>().color = fullHealthColor; // Màu sắc ban đầu

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            health.value -= 10;
            UpdateHealthColor();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded )
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                audioSource.PlayOneShot(audioClips[2]);
                canDoubleJump = true;
                
            }
            else if(canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                audioSource.PlayOneShot(audioClips[2]);
                canDoubleJump = false;
            }



        }

        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            RaycastEnemy();
        }


        timer += Time.deltaTime;
        if (timer > 30)
        {
            Speed += 1;
            timer = 0;
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yvelocity", rb.velocity.y);

        // Collisonhcheck();
        if(health.value == 0)
        {
            player.SetActive(false);
            GameManager.Checkscore();
            DeathZone.SetActive(false);
            gidGround.SetActive(false);
            spamcoin.SetActive(false);
            heathhoi.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameManager.score >0)
            {
                Instantiate(coinsinh,enemycheck.position,Quaternion.identity);
                GameManager.Trudiem();
            }
        }
        // if (Input.GetKey(KeyCode.H))
        // {
        //     rb.velocity = new Vector2(Speed, rb.velocity.y);
        // }
        // else
        // {
        //     rb.velocity = new Vector2(0, rb.velocity.y);
        // }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Speed, rb.velocity.y);
        // OverlapCheckGround();
        RaycastCheckground();

    }

    //update color heath
    #region 
    void UpdateHealthColor()
    {
        float healthPercentage = health.value / health.maxValue;

        if (healthPercentage <= 0.3f) // Dưới 30%
        {
            health.fillRect.GetComponent<Image>().color = lowHealthColor;
        }
        else if (healthPercentage <= 0.7f) // Dưới 70%
        {
            health.fillRect.GetComponent<Image>().color = mediumHealthColor;
        }
        else // Trên 70%
        {
            health.fillRect.GetComponent<Image>().color = fullHealthColor;
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            GameManager.score++;
            Destroy(other.gameObject);
            GameManager.SetTextScore();
            GameManager.SaveGame();
        }

        if (other.CompareTag("Zone"))
        {
            ads.ShowInterstitialAd();
            Debug.Log("da cham zone");
            GameManager.Checkscore();
            Destroy(gameObject);
            DeathZone.SetActive(false);
            gidGround.SetActive(false);
            spamcoin.SetActive(false);
            heathhoi.SetActive(false);
        }

        if(other.CompareTag("Bullet"))
        {
            health.value -=20;
            Destroy(other.gameObject);
            UpdateHealthColor();
        }

        if (other.CompareTag("hoimau"))
        {
            health.value +=10;
            Debug.Log("da cham hoi mau");
            Destroy(other.gameObject);
        }
        
    }

    public void PlayerDead()
    {
        GameManager.Checkscore();
            Destroy(gameObject);
            DeathZone.SetActive(false);
            gidGround.SetActive(false);
            spamcoin.SetActive(false);
            heathhoi.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.collider.tag == "quai1")
        {
            health.value -=20;
            
            UpdateHealthColor();
        }
        if(collision2D.collider.tag == "quai")
        {
            health.value -=20;
            
            UpdateHealthColor();
        }
    }

    // public void Collisonhcheck()
    // {
    //     isGrounded = Physics2D.Raycast(groundcheck.position, Vector2.down, GroundDistance, whatisGround);
    // }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawLine(groundcheck.position, new Vector3(groundcheck.position.x, groundcheck.position.y - GroundDistance));
    // }

    public void OverlapCheckGround()
    {
        Collider2D[] getCollider = Physics2D.OverlapCircleAll(checkground.position, 0.2f, whatisGround);
        if (getCollider.Length > 0)
        {
            isGrounded = true;
            canDoubleJump = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void RaycastCheckground()
{
    RaycastHit2D hitGround = Physics2D.Raycast(checkground.position, Vector2.down, 0.5f, whatisGround);
    RaycastHit2D hitEnemy = Physics2D.Raycast(checkground.position, Vector2.down, 0.5f, enemyLayer);

    if (hitGround || hitEnemy)
    {
        isGrounded = true;
    }
    else
    {
        isGrounded = false;
    }
}

    public void RaycastEnemy()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(enemycheck.position + Vector3.up, Vector2.right, 10f, enemyLayer);

        if (hit2D)
        {
            Debug.DrawRay(enemycheck.position + Vector3.up, Vector3.right * hit2D.distance, Color.red);
            Destroy(hit2D.collider.gameObject);

        }
        else
        {
            Debug.DrawRay(enemycheck.position + Vector3.up, Vector2.right * 10f, Color.green);
        }
    }
}