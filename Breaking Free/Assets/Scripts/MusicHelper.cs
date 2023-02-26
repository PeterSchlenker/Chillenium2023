using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHelper : MonoBehaviour
{
    public int currentTheme;

    // Start is called before the first frame update
    void Start()
    {
        if (MusicController.instance != null)
        {
            MusicController.instance.themeCode = currentTheme;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
