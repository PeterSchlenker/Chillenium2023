using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos;
    private Vector3 targetPos;
    [SerializeField] private float timeToMove = 0.1f;
    [SerializeField] private int throwRadius = 3;

    public LayerMask StopMovement;

    public Transform redCharacter;
    public Transform yellowCharacter;
    public Transform greenCharacter;

    private Transform activeCharacter;

    public Camera camera;


    void Start()
    {
        activeCharacter = greenCharacter;
    }



    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (!hit.Equals(null))
        {
            Transform objectHit = hit.transform;

            if (!isMoving && objectHit != activeCharacter && (objectHit == redCharacter || objectHit == yellowCharacter || objectHit == greenCharacter))
            {
                Vector2 distance = objectHit.position - activeCharacter.position;
                if (Math.Abs(distance.x) <= throwRadius && Math.Abs(distance.y) <= throwRadius)
                {
                    activeCharacter = objectHit;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }

        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
    }

    private IEnumerator MovePlayer(Vector3 dir)
    {
        isMoving = true;

        float elapsedTime = 0;

        originalPos = activeCharacter.transform.position;
        targetPos = originalPos + dir;

        if (Physics2D.OverlapCircle(targetPos, .2f, StopMovement))
        {
            targetPos = originalPos;
        }

            while (elapsedTime < timeToMove)
        {
            activeCharacter.transform.position = Vector3.Lerp(activeCharacter.transform.position, targetPos, elapsedTime/timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        activeCharacter.transform.position = targetPos;

        isMoving = false;
    }
}
