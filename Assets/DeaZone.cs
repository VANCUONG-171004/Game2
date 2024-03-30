using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeaZone : MonoBehaviour
{
    public Transform playercheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playercheck.position.x,0,0);
    }
}
