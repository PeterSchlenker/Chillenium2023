using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    [SerializeField] GameObject HowToPlay;
    [SerializeField] GameObject dismissHowToPlay;

    public void press()
    {
        HowToPlay.SetActive(true);
        dismissHowToPlay.SetActive(true);
    }
}
