using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            title.text = "Hello Wrold";
        }
        if(Input.GetKeyUp(KeyCode.T))
        {
            title.text = "Fantrsy forest";
        }
    }

    // private void OnGUI() {
    //     GUI.Box(new Rect(10,50,300,100),"Main menu");

    //     if(GUI.Button(new Rect(70,70,100,50),"Button"))
    //     {
    //         print("hhe");
    //     }


    // }

    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }
}
