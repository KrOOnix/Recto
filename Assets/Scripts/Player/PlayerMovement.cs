using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3f;
    private bool isMoving;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if (isMoving) { return; }

        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector3.right);
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector3.back);

        if (FindObjectOfType<SwipeManager>().IsSwipeLeft)
        {
            FindObjectOfType<SwipeManager>().IsSwipeLeft = false;
            Move(Vector3.left);
        }
        if (FindObjectOfType<SwipeManager>().IsSwipeRight)
        {
            FindObjectOfType<SwipeManager>().IsSwipeRight = false;
            Move(Vector3.right);
        }
        if (FindObjectOfType<SwipeManager>().IsSwipeUp)
        {
            FindObjectOfType<SwipeManager>().IsSwipeUp = false;
            Move(Vector3.forward);
        }
        if (FindObjectOfType<SwipeManager>().IsSwipeDown)
        {
            FindObjectOfType<SwipeManager>().IsSwipeDown = false;
            Move(Vector3.back);
        }
    }

    void Move(Vector3 dir)
    {
        Vector3 origin = new Vector3(transform.position.x,transform.position.y-4.5f,transform.position.z);  

        if (!Physics.Raycast(origin, dir,7f)) { return; }

        var anchor = transform.position + (Vector3.down + dir) * 5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }

    IEnumerator Roll(Vector3 anchor,Vector3 axis)
    {
        if (FindObjectOfType<GameManager>().IsRuning == false)
        {
            FindObjectOfType<GameManager>().StartGame();    
        }


        isMoving = true;
        audioSource.PlayOneShot(walkSound);

        for(int i= 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new  WaitForSeconds(0.02f);
        }

        isMoving = false;

    }

}
