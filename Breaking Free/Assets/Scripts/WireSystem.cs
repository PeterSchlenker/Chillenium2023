using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    List<GameObject> connectedObjs;

    public void TurnOn()
    {
        foreach(GameObject obj in connectedObjs)
        {
            if (obj.GetComponent<Door>())
            {
                obj.GetComponent<Door>().Open();
            } else if (obj.GetComponent<Spikes>())
            {
                obj.GetComponent<Spikes>().Open();
            }
        }
    }
}
