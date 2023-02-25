using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos;
    private Vector3 targetPos;
    [SerializeField] private float timeToMove = 0.1f;
    [SerializeField] private int throwRadius = 3;

    public LayerMask StopMovement;
    public LayerMask Breakable;
    public LayerMask Jumpable;
    public LayerMask Death;

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
        if (Input.GetAxis("Fire1") > 0)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

            foreach (RaycastHit2D hit in hits)
            {
                Transform objectHit = hit.transform;

                if (!isMoving && objectHit != activeCharacter && (objectHit == redCharacter || objectHit == yellowCharacter || objectHit == greenCharacter))
                {
                    Vector2 distance = objectHit.position - activeCharacter.position;
                    if (Math.Abs(distance.x) <= throwRadius && Math.Abs(distance.y) <= throwRadius)
                    {
                        activeCharacter = objectHit;
                        break;
                    }
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

        float timeLeft = timeToMove;

        originalPos = activeCharacter.transform.position;
        targetPos = originalPos + dir;

        if (Physics2D.OverlapCircle(targetPos, .2f, StopMovement))
        {
            targetPos = originalPos;
        }
        else if (Physics2D.OverlapCircle(targetPos, .2f, Breakable))
        {
            if (activeCharacter == redCharacter)
            {
                Destroy(Physics2D.CircleCast(targetPos, .2f, dir).transform.gameObject);
            }
            else
            {
                targetPos = originalPos;
            }
        }
        else if (Physics2D.OverlapCircle(targetPos, .2f, Jumpable))
        {
            if (activeCharacter == greenCharacter)
            {
                targetPos += dir;
                timeLeft *= 3;
            }
            else
            {
                targetPos = originalPos;
            }
        }
        else if (Physics2D.OverlapCircle(targetPos, .2f, Death))
        {
            //TODO: Reset Level properly
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        while (timeLeft > 0 && targetPos != originalPos)
        {
            activeCharacter.transform.position = Vector3.Lerp(activeCharacter.transform.position, targetPos, 0.1f);
            timeLeft -= Time.deltaTime;
            yield return null; 
        }

        activeCharacter.transform.position = targetPos;

        isMoving = false;
    }

    public bool isActiveRed() { return activeCharacter == redCharacter; }
    public bool isActiveGreen() { return activeCharacter == greenCharacter; }
    public bool isActiveYellow() { return activeCharacter == yellowCharacter; }
}
