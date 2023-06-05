using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite ironMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;
    void Start()
    {
        img = GetComponent<Image>();

        int gameScore = GameManager.gameScore;

        if (gameScore > 0 && gameScore <= 1)
            img.sprite = ironMedal;
        else if (gameScore > 1 && gameScore <= 2)
            img.sprite = bronzeMedal;
        else if (gameScore > 2 && gameScore <= 3)
            img.sprite = silverMedal;
        else
            img.sprite = goldMedal;
    }

    void Update()
    {
        
    }
}
