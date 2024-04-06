using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant_Enemy : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    public float TimerAttack;
    public float timer;
    private Animator anim;

    public Transform checkplayer;
    public LayerMask LayerPlayer;


    // Start is called before the first frame update
    void Start()
    {
        timer = TimerAttack;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;

        RaycatDeltextPlayer();
    }
    public void PlantShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        
    }
    

    public void RaycatDeltextPlayer()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(checkplayer.position, Vector2.left, 10f, LayerPlayer);
        if (hit2D)
        {
            Debug.DrawRay(checkplayer.position, Vector2.left * hit2D.distance, Color.red);
            if (timer <= 0)
            {
                anim.SetTrigger("Attack");
                timer = TimerAttack;
            }
            Debug.Log("da cham player");
        }
        else
        {
            Debug.DrawRay(checkplayer.position, Vector2.left * hit2D.distance, Color.green);
        }

    }
}
