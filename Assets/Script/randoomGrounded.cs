using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class randoomGrounded : MonoBehaviour
{
    public Transform player;
    

    public List<GameObject> listGround; //Danh sách miếng đất đã vẽ
    public List<GameObject> listGroundOld; //Danh sách các miếng đất đã sinh ra
    private Vector2 endPos;

    private Vector2 nextPos;

    private float rd;
    private int id;
    int groundLen; //độ dài của miếng đất
    // Start is called before the first frame update


    public GameObject plant;
    public GameObject boar;
    public GameObject bossleft;
    void Start()
    {
        endPos = new Vector2(20f, 0f); //Vị trí cuối cùng của map hiện tại của ô đất là 20

        for (int i = 0; i < 5; i++)
        {
            rd = Random.Range(2f, 5f); //Random khoảng cách giữa miếng đất ban đầu và miếng tiếp theo
            nextPos = new Vector2(endPos.x + rd, 0f);//Vị trí đặt miếng đất tiếp theo = vị trí cuối + khoảng cách
            id = Random.Range(0, listGround.Count); //Random miếng đất sẽ sinh ra
            GameObject newGound = Instantiate(listGround[id], nextPos, Quaternion.identity, transform); //Sinh ra miếng đất với ID vừa random 
            listGroundOld.Add(newGound);

            //Tiếp theo, kiểm tra xem miếng đất vừa sinh ra có độ dài bao nhiêu
            switch (id)
            {
                case 0: groundLen = 5; break;
                case 1: groundLen = 8; break;
                case 2: groundLen = 10; break;
                case 3: groundLen = 20; break;

            }

            endPos = new Vector2(nextPos.x + groundLen, 0f);

            if (groundLen == 20)
            {
                SpamBoar();
            }
            else
            {
                int getEnemy = Random.Range(0, 2);
                if (getEnemy != 0)
                {
                    SpamPlant();
                }
                else
                {
                    SpamBossLeft();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Xem vị trí của người chơi so với điểm endPos cách nhau bao xa
        //Nếu khoảng cách nhỏ hơn 100f thì chúng ta tiếp tục tạo ra các miếng đất tiếp theo
        if (Vector2.Distance(player.position, endPos) < 100f)
        {
            for (int i = 0; i < 5; i++)
            {
                rd = Random.Range(2f, 5f); //Random khoảng cách giữa miếng đất ban đầu và miếng tiếp theo
                nextPos = new Vector2(endPos.x + rd, 0f);//Vị trí đặt miếng đất tiếp theo = vị trí cuối + khoảng cách
                id = Random.Range(0, listGround.Count); //Random miếng đất sẽ sinh ra
                GameObject newGround = Instantiate(listGround[id], nextPos, Quaternion.identity, transform); //Sinh ra miếng đất với ID vừa random 
                listGroundOld.Add(newGround);

                //Tiếp theo, kiểm tra xem miếng đất vừa sinh ra có độ dài bao nhiêu
                switch (id)
                {
                    case 0: groundLen = 5; break;
                    case 1: groundLen = 8; break;
                    case 2: groundLen = 10; break;
                    case 3: groundLen = 20; break;

                }

                endPos = new Vector2(nextPos.x + groundLen, 0f);

                if (groundLen == 20)
                {
                    SpamBoar();
                }
                else
                {
                    int getEnemy = Random.Range(0, 2);
                    if (getEnemy != 0)
                    {
                        SpamPlant();
                    }
                    else
                    {
                        SpamBossLeft();
                    }
                }
            }
        }

        //Lấy ra miếng đất đầu tiên trong danh sách
        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > 100f)
        {
            //Nếu khoảng cách giữa người chơi và miếng đất vừa lấy ra lớn hơn 100
            listGroundOld.Remove(getOneGround); //Xóa khỏi danh sách
            Destroy(getOneGround); //Hủy gameoject
        }

        
    }

    public void SpamPlant()
    {
        Vector3 pos = new Vector3(Random.Range(nextPos.x + 2f, endPos.x - 2f), 0, 0);
        Instantiate(plant, pos, Quaternion.identity);
    }

    public void SpamBoar()
    {
        Vector3 pos = new Vector3(Random.Range(nextPos.x + 7f, endPos.x -7f), 0, 0);
        Instantiate(boar, pos, Quaternion.identity);
    }
    public void SpamBossLeft()
    {
        Vector3 pos = new Vector3(Random.Range(endPos.x - 5, endPos.x - 2f), 0, 0);
        Instantiate(bossleft, pos, Quaternion.identity);
    }
}
