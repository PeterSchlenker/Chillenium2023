using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos;
    private Vector3 targetPos;
    [SerializeField] private float timeToMove = 0.1f;

    public LayerMask StopMovement;



    // Update is called once per frame
    void Update()
    {
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

        originalPos = transform.position;
        targetPos = originalPos + dir;

        if (Physics2D.OverlapCircle(targetPos, .2f, StopMovement))
        {
            targetPos = originalPos;
        }

            while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, elapsedTime/timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
