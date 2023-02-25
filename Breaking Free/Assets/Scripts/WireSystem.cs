using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSystem : MonoBehaviour
{
    Door[] doors;
    Spikes[] spikes;

    private void Start()
    {
        doors = GetComponentsInChildren<Door>();
        spikes = GetComponentsInChildren<Spikes>();
    }

    public void TurnOn()
    {
       foreach(Door door in doors)
        {
            door.Open();
        }

       foreach(Spikes spikes in spikes)
        {
            spikes.On();
        }
    }

    public void TurnOff()
    {
        foreach (Door door in doors)
        {
            door.Close();
        }

        foreach (Spikes spikes in spikes)
        {
            spikes.Off();
        }
    }
}
