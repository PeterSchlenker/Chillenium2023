using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverScreen : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Image AmberImage;
    [SerializeField] Image JadeImage;
    [SerializeField] Image JasperImage;
    [SerializeField] Image Star1;
    [SerializeField] Image Star2;
    [SerializeField] Image Star3;
    [SerializeField] TextMeshProUGUI evilText;
    [SerializeField] TextMeshProUGUI lessEvilText;
    [SerializeField] TextMeshProUGUI friendText;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void toMainMenu()
    {
        gameManager.MainMenu();
    }

    public void DisplaySuccess(bool redHere, bool greenHere, bool yellowHere)
    {
        if(redHere && greenHere && yellowHere)
        {
            EnableUIStuff(true, true, true, true, true, true, false, false, true);
        } else if((redHere && greenHere) ||
            (redHere && yellowHere) ||
            (greenHere && yellowHere))
        {
            EnableUIStuff(redHere, greenHere, yellowHere, true, true, false, false, true, false);
        } else
        {
            EnableUIStuff(redHere, greenHere, yellowHere, true, false, false, true, false, false);
        }
    }

    private void EnableUIStuff(bool Red, bool Green, bool Yellow, bool StarOne, bool StarTwo, bool StarThree, bool evil, bool lessEvil, bool friend)
    {
        AmberImage.gameObject.SetActive(Yellow);
        JadeImage.gameObject.SetActive(Green);
        JasperImage.gameObject.SetActive(Red);
        Star1.gameObject.SetActive(StarOne);
        Star2.gameObject.SetActive(StarTwo);
        Star3.gameObject.SetActive(StarThree);
        evilText.gameObject.SetActive(evil);
        lessEvilText.gameObject.SetActive(lessEvil);
        friendText.gameObject.SetActive(friend);
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
