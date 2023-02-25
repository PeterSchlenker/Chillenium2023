using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour
{

    public void Open()
    {
        //TODO: Door animation trigger
        this.gameObject.layer = 0;
    }

    public void Close()
    {
        //TODO: Door animation trigger
        this.gameObject.layer = 6;
    }
}
