using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void GameReset()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}