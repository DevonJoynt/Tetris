using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int score = 0; //Set the initial score to 0

    public void AddScore(int linesCleared)
    {
        //Switch case for each line clear amount
        // in the form of a score value
        switch (linesCleared)
        {
            case 1: score += 100; break;
            case 2: score += 300; break;
            case 3: score += 500; break;
            case 4: score += 800; break;
            default: break;
        }

        Debug.Log($"Score: {score}");
        scoreText.text = ($"Score: {score}");
    }
}