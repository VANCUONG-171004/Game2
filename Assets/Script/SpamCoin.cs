using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamCoin : MonoBehaviour
{
    //từ 5- 8s thì sinh ra coin
    //số lượng từ 5-10 coin
    //vị trí sinh ra trước mặt
    //Nhân vật chạy qua k ăn được thì xóa đi
    private bool choPhepsinhcoin;

    public Transform player;
    public GameObject coin;



    private void Start()
    {
        choPhepsinhcoin = true;
    }

    private void Update()
    {

        if (choPhepsinhcoin)
        {
            choPhepsinhcoin = false;
            //sinh ra coin
            int soluong = Random.Range(5, 10);
            float coinPusX = player.position.x + Random.Range(15f, 30f);
            float coinPusY = 2 * Mathf.Abs(Mathf.Sin(coinPusX /3));
            
            for (int i = 0; i < soluong; i++)
            {
                
                Instantiate(coin,new Vector3(coinPusX,coinPusY,0),Quaternion.identity);
                coinPusX++;
                coinPusY = 2 * Mathf.Abs(Mathf.Sin(coinPusX /3));
            }
            StartCoroutine(ChoSinhCoin());

        }
    }
    IEnumerator ChoSinhCoin()
    {
        float timer = Random.Range(5f, 8f);
        yield return new WaitForSeconds(timer);
        choPhepsinhcoin = true;
    }
}
