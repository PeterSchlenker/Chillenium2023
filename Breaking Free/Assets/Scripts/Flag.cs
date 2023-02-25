using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flag : MonoBehaviour
{
    CompositeCollider2D CompositeCollider2D;
    int numCharas = 0;
    bool greenHere = false;
    bool yellowHere = false;
    bool redHere = false;
    [SerializeField] Button evilButton;
    [SerializeField] Button lessEvilButton;
    [SerializeField] Button friendButton;

    [SerializeField] LayerMask characters;

    public int nextSceneLoad;

    private void Start()
    {
        CompositeCollider2D = GetComponent<CompositeCollider2D>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        //text = GetComponentInChildren<Button>();
        EnableButtons(false, false, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterAndStay(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        enterAndStay(collision);
    }

    private void enterAndStay(Collider2D collision)
    {
        Debug.Log("Collide flag");
        CharacterMovement chara = collision.gameObject.GetComponentInParent<CharacterMovement>();
        if (chara)
        {
            if(collision.gameObject.transform.position == chara.getRedCharPos() && !redHere)
            {
                numCharas++;
                redHere = true;
            } else if(collision.gameObject.transform.position == chara.getGreenCharPos() && !greenHere)
            {
                numCharas++;
                greenHere = true;
            }
            else if (collision.gameObject.transform.position == chara.getYellowCharPos() && !yellowHere)
            {
                numCharas++;
                yellowHere = true;
            }

            if (numCharas <= 1)
            {
                EnableButtons(true, false, false);
            } else if(numCharas == 2)
            {
                EnableButtons(false, true, false);
            } else if(numCharas == 3)
            {
                EnableButtons(false, false, true);
            }

            if (!CheckHeartNear(chara))
                EnableButtons(false, false, false);

            /*
            Debug.Log("Chara Flag");
            if (CheckAllCharNear(chara))
            {
                evilButton.gameObject.SetActive(false);
                lessEvilButton.gameObject.SetActive(false);
                friendButton.gameObject.SetActive(true);
            }
            else if (CheckTwoCharNear(chara) && CheckHeartNear(chara))
            {
                evilButton.gameObject.SetActive(false);
                friendButton.gameObject.SetActive(false);
                lessEvilButton.gameObject.SetActive(true);
            }
            else if (CheckHeartNear(chara))
            {
                evilButton.gameObject.SetActive(true);
                lessEvilButton.gameObject.SetActive(false);
                friendButton.gameObject.SetActive(false);
            } else
            {
                evilButton.gameObject.SetActive(false);
                lessEvilButton.gameObject.SetActive(false);
                friendButton.gameObject.SetActive(false);
            }
            */
        }
    }

    void EnableButtons(bool evil, bool lessEvil, bool friend)
    {
        evilButton.gameObject.SetActive(evil);
        lessEvilButton.gameObject.SetActive(lessEvil);
        friendButton.gameObject.SetActive(friend);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Leave flag");
        CharacterMovement chara = collision.gameObject.GetComponentInParent<CharacterMovement>();
        if (collision.gameObject.transform.position == chara.getRedCharPos() && redHere)
        {
            numCharas--;
            redHere = false;
        }
        else if (collision.gameObject.transform.position == chara.getGreenCharPos() && greenHere)
        {
            numCharas--;
            greenHere = false;
        }
        else if (collision.gameObject.transform.position == chara.getYellowCharPos() && yellowHere)
        {
            numCharas--;
            yellowHere = false;
        }

        if(numCharas <= 0 || !CheckHeartNear(chara))
        {
            EnableButtons(false, false, false);
        }
    }

    public void NextLevel(int charsSaved)
    {
        Debug.Log("Next level");
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            Debug.Log("YOU WIN THE GAME");
        }
        else
        {

            Debug.Log("Next level");
            //Move to next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
    bool CheckHeartNear(CharacterMovement chara) { return (chara.getActiveCharPos() - this.transform.position).magnitude < 1.5f; }

    /*

    bool CheckHeartNear(CharacterMovement chara) { return (chara.getActiveCharPos() - this.transform.position).magnitude < 1f; }

    bool CheckAllCharNear(CharacterMovement chara)
    {
        return ((chara.getGreenCharPos() - chara.getRedCharPos()).magnitude < 3f) &&
                ((chara.getGreenCharPos() - chara.getYellowCharPos()).magnitude < 3f) &&
                ((chara.getYellowCharPos() - chara.getRedCharPos()).magnitude < 3f);
    }

    bool CheckTwoCharNear(CharacterMovement chara)
    {
        return (((chara.getGreenCharPos() - chara.getRedCharPos()).magnitude < 3f) && ((chara.getGreenCharPos() - this.transform.position).magnitude < 2f))
                || (((chara.getGreenCharPos() - chara.getYellowCharPos()).magnitude < 3f) && ((chara.getYellowCharPos() - this.transform.position).magnitude < 0.5f))
                || (((chara.getRedCharPos() - chara.getYellowCharPos()).magnitude < 3f) && ((chara.getRedCharPos() - this.transform.position).magnitude < 0.5f));
    }
    */

}
