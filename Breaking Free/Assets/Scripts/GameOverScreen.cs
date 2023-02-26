using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Retry()
    {
        UnityEngine.SceneManagement.Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
