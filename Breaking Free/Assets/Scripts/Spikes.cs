using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
  
    public void Off()
    {
        //TODO: Spike animation trigger
        this.gameObject.layer = 0;
    }

    public void On()
    {
        //TODO: Spike animation trigger
        this.gameObject.layer = 8;
    }
}
