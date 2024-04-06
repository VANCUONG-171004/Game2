using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mau_pant : MonoBehaviour
{
    public float heathboarcontol =3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(heathboarcontol == 0)
        {
            Destroy(gameObject);
        }
    }
}
