using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] bool isYellow = false;
    [SerializeField] WireSystem wireSystem;
    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        wireSystem = GetComponentInParent<WireSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide");
        CharacterMovement chara = collision.gameObject.GetComponentInParent<CharacterMovement>();
        if (chara)
        {
            Debug.Log("Chara");
            if (!isYellow)
            {
                wireSystem.TurnOn();
            }
            else if (isYellow && (this.transform.position - chara.transform.position).magnitude < .05)
            {
                wireSystem.TurnOn();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collide");
        CharacterMovement chara = collision.gameObject.GetComponentInParent<CharacterMovement>();
        if (chara)
        {
            Debug.Log("Chara");
            if (!isYellow)
            {
                wireSystem.TurnOn();
            }
            else if (isYellow && (this.transform.position - chara.transform.position).magnitude < .05)
            {
                wireSystem.TurnOn();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        wireSystem.TurnOff();
    }

}
