using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSystem : MonoBehaviour
{
    Door[] doors;
    Spikes[] spikes;

    public GameObject on;
    public GameObject off;

    bool isOn = false;

    private float waitTime = 0.1f;

    private void Start()
    {
        doors = GetComponentsInChildren<Door>();
        spikes = GetComponentsInChildren<Spikes>();
    }

    public void TurnOn()
    {
       isOn = true;
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
        isOn = false;
        StartCoroutine(checkPlate());
    }

    private void TurnOffActual()
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

    private IEnumerator checkPlate()
    {
        float timeLeft = waitTime;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        if (!isOn)
        {
            TurnOffActual();
        }
    }
}
