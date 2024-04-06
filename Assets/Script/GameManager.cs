using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hightscore = 0;

    public GameObject bangtrai;
    public GameObject banggiua;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI socreDeathText;
    public TextMeshProUGUI hightsocreDeathText;
    private void Start() {
        LoadGame();
        SetTextScore();
    }

    public void SaveGame()
    {
        string mahoa = Extension.Encrypt(hightscore.ToString(), "GAME2");
        PlayerPrefs.SetString("Diem",mahoa);
    }
    public void LoadGame()
    {
        string getDiem = PlayerPrefs.GetString("Diem");
        string giaima = Extension.Decrypt(getDiem,"GAME2");
        hightscore = int .Parse(giaima);
        
    }

    public void SetTextScore()
    {
        scoretext.text = "Score:" +" "+ score.ToString("n0");
    }

    public void Checkscore()
    {
        if (score >hightscore )
        {
            hightscore = score;
            SaveGame();
        }

        bangtrai.SetActive(false);
        banggiua.SetActive(true);

        socreDeathText.text = "Score:" +" "+ score.ToString("n0");
        hightsocreDeathText.text = "HightScore:" +" "+ hightscore.ToString("n0");
    }
    
    public void Trudiem()
    {
        score--;
        scoretext.text = "Score:" +" "+ score.ToString("n0");
    }
    public void PlayerAgin()
    {
        SceneManager.LoadScene(0);
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
}
