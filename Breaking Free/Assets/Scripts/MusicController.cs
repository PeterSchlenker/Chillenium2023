using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    // mainTheme = 0
    // levelTheme = 1
    // winTheme = 2
    // loseTheme = 3

    public int themeCode;
    public int previousThemeCode;

    public AudioSource mainTheme;
    public AudioSource levelTheme;
    public AudioSource winTheme;
    public AudioSource loseTheme;

    void Awake()
    {
        if (MusicController.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (themeCode != previousThemeCode)
        {
            previousThemeCode = themeCode;
            switch (themeCode) {
                case 0:
                    mainTheme.Play();
                    levelTheme.Stop();
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }

        if (themeCode == 1)
        {
            if (!mainTheme.isPlaying && !levelTheme.isPlaying)
            {
                levelTheme.Play();
            }
        }
    }
}
