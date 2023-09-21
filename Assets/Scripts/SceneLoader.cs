using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
