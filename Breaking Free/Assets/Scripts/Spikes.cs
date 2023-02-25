using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
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
