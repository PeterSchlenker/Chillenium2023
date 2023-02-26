using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSoundScript : MonoBehaviour
{
    public AudioSource pop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        pop.Play();
    }
}
