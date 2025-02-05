using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public void AddScore(int LinesCleared)
    {
        switch (LinesCleared)
        {
            case 1: score += 100; break;
            case 2: score += 300; break;
            case 3: score += 500; break;
            case 4: score += 800; break;

        }
        Debug.Log($"Score: {score}");
    }
}
