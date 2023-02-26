using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour
{

    LayerMask character;

    public AudioSource metalSlide;
    private bool open = false;

    private void Start()
    {
        character = 9;
    }

    public void Open()
    {
        //TODO: Door animation trigger
        this.gameObject.layer = 0;
        if (!open) { 
            metalSlide.Play();
            open = true;
        }
    }

    public void Close()
    {
        //TODO: Door animation trigger
        this.gameObject.layer = 6;
        if (Physics2D.OverlapCircle(transform.position, 0.1f, character))
        {
            FindObjectOfType<CharacterMovement>().Die();
            Debug.Log("Hey");
        }

        if (open)
        {
            metalSlide.Play();
            open = false;
        }
    }
}
