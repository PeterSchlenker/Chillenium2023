using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSystem : MonoBehaviour
{
    Door[] doors;
    Spikes[] spikes;

    public GameObject on;
    public GameObject off;

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

        on.SetActive(true);
        off.SetActive(false);
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

        on.SetActive(false);
        off.SetActive(true);
    }
}
