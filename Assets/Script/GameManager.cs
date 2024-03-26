using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoretext;
    private void Start() {
        LoadGame();
        SetTextScore();
    }

    public void SaveGame()
    {
        string mahoa = Extension.Encrypt(score.ToString(), "GAME2");
        PlayerPrefs.SetString("Diem",mahoa);
    }
    public void LoadGame()
    {
        string getDiem = PlayerPrefs.GetString("Diem");
        string giaima = Extension.Decrypt(getDiem,"GAME2");
        score = int .Parse(giaima);
        
    }

    public void SetTextScore()
    {
        scoretext.text = "Score:" +" "+ score.ToString("n0");
    }
    
}
