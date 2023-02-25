using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class GameManager : MonoBehaviour
{

    // VARIABLES
    public static GameManager instance;

    [SerializeField] Transform Characters;

    //public GameObject audioManager;

    public GameObject GameOverScreen;

    [SerializeField] public Flag flag;

    [SerializeField] Button Retry;
    [SerializeField] Button Play;
    [SerializeField] Button Quit;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            flag = FindObjectOfType<Flag>();
            Characters = FindObjectOfType<CharacterMovement>().transform;
            Retry.gameObject.SetActive(true);
            Play.gameObject.SetActive(false);
            Quit.gameObject.SetActive(false);
        } else
        {
            
        }
    }

        // Update is called once per frame
        private void Update()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        GameOverScreen.SetActive(true);
    }

    public void RetryLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void LoadEndScreen()
    {
        Debug.Log("Go to level select screen -- doesn't exist yet");
        //SceneManager.LoadScene("LevelSelectScreen");
    }

    public void GiveUp()
    {
        Debug.Log("Go to level select screen -- doesn't exist yet");
        SceneManager.LoadScene(0);
    }
}
