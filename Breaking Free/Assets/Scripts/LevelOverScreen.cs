using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverScreen : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Sprite StarOutline;
    [SerializeField] Image AmberImage;
    [SerializeField] Image JadeImage;
    [SerializeField] Image JasperImage;
    [SerializeField] Image Star1;
    [SerializeField] Image Star2;
    [SerializeField] Image Star3;
    [SerializeField] TextMeshProUGUI evilText;
    [SerializeField] TextMeshProUGUI lessEvilText;
    [SerializeField] TextMeshProUGUI friendText;
    [SerializeField] bool isFinalLevelScreen = false;
    [SerializeField] Image finalImage;



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
        if (isFinalLevelScreen)
        {
            finalImage.gameObject.SetActive(true);
            redHere = !redHere;
            greenHere = !greenHere;
            yellowHere = !yellowHere;
        }

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
        Star1.gameObject.SetActive(true);
        if (!StarOne)
            Star1.sprite = StarOutline;
        Star2.gameObject.SetActive(true);
        if (!StarTwo)
            Star2.sprite = StarOutline;
        Star3.gameObject.SetActive(true);
        if (!StarThree)
            Star3.sprite = StarOutline;

        if (MusicController.instance != null)
        {
            if (friend)
            {
                MusicController.instance.winTheme.Play();
            }
            else
            {
                MusicController.instance.loseTheme.Play();
            }
        }

        evilText.gameObject.SetActive(evil || lessEvil || friend);
        if(Red && evil)
        {
            evilText.text = "Jasper abandoned his friends to rot in their depressed state... He did not share their heart...";
        } else if(Green && evil)
        {
            evilText.text = "Jade abandoned her friends to rot in their depressed state... She did not share their heart...";
        } else if(Yellow && evil)
        {
            evilText.text = "Amber abandoned her friends to rot in their depressed state... She did not share their heart...";
        } else if(Red && Green && lessEvil)
        {
            evilText.text = "Jasper and Jade abandoned Amber... They justify it to themselves by saying they were tired of her airheadedness, but deep down... they know they will miss her";
        } else if (Red && Yellow && lessEvil)
        {
            evilText.text = "Jasper and Amber abandoned Jade... She was their rock and guide... What will they do without her...";
        }
        else if (Green && Yellow && lessEvil)
        {
            evilText.text = "Amber and Jade got tired of Jasper's shit and dropped his @$$. You go girls. Slay.";
        } else if (friend)
        {
            evilText.text = "Jasper, Amber, and Jade left the dungeon, striding out together. Where once they had entered split and angry, they now exited as empathetic friends... for they shared one heart.";
        }
    }

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
