using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    SpriteRenderer spDoor;
    private bool Open;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        spDoor = GetComponent<SpriteRenderer>();
        Open = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Open)
        {
            if(SceneManager.GetActiveScene().buildIndex == 7)
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
    }

    public void OpenDoor()
    {
        Open = true;
        spDoor.color = Color.green;
    }
}
