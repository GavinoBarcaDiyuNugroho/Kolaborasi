using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isWalk;
    public Vector3 originalPos, targetPos;
    public float timeToMove = 0.2f;
    bool canMove;
    public bool hasMoved;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && !isWalk)
        {
            StartCoroutine(gridMovement(Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.A) && !isWalk)
        {
            StartCoroutine(gridMovement(Vector3.left));
        }
        if(Input.GetKeyDown(KeyCode.Q) && !isWalk)
        {
            StartCoroutine(gridMovement(new Vector3(-0.5f, 0.75f, 0)));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(gridMovement(new Vector3(0.5f, 0.75f, 0)));
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(gridMovement(new Vector3(0.5f, -0.75f, 0)));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(gridMovement(new Vector3(-0.5f, -0.75f, 0)));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canMove = true;
            Debug.Log("Can move = " +canMove);
        }
        else
        {
            canMove = false;
        }
    }
    
    IEnumerator gridMovement(Vector3 direction)
    {
        isWalk = true;

        float elapsedTime = 0;
        originalPos = transform.position;
        targetPos = originalPos+direction;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime/timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isWalk = false;
        hasMoved = true;
    }
}
