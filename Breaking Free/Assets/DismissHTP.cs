using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismissHTP : MonoBehaviour
{
    [SerializeField] GameObject HowToPlay;
    [SerializeField] GameObject dismissHowToPlay;

    public void press()
    {
        HowToPlay.SetActive(false);
        dismissHowToPlay.SetActive(false);
    }
}
