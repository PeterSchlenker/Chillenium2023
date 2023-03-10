using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] bool isYellow = false;
    [SerializeField] WireSystem wireSystem;
    BoxCollider2D boxCollider;

    bool played = false;

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
            else if (isYellow && (this.transform.position - chara.getYellowCharPos()).magnitude < .05)
            {
                wireSystem.TurnOn();
                chara.SetYellowAnimation(true);
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
            else if (isYellow && (this.transform.position - chara.getYellowCharPos()).magnitude < .05)
            {
                wireSystem.TurnOn();
                chara.SetYellowAnimation(true);
                if (!played)
                {
                    chara.electricity.Play();
                    played = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharacterMovement chara = collision.gameObject.GetComponentInParent<CharacterMovement>();
        if (chara)
        {
            if (isYellow && wireSystem.on.activeInHierarchy)
            {
                chara.SetYellowAnimation(false);
                played = false;
            }

            wireSystem.TurnOff();
        }
    }

}
