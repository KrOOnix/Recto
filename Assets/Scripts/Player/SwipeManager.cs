using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector2 startPos;
    public int minSwipeRange = 20;
    private bool touchDown = false;
    bool isSwipeLeft = false;
    public bool IsSwipeLeft
    {
        get { return isSwipeLeft; }
        set { isSwipeLeft = value; }
    }

    bool isSwipeRight = false;
    public bool IsSwipeRight
    {
        get { return isSwipeRight; }
        set { isSwipeRight = value; }
    }

    bool isSwipeUp = false;
    public bool IsSwipeUp
    {
        get { return isSwipeUp; }
        set { isSwipeUp = value; }
    }

    bool isSwipeDown = false;
    public bool IsSwipeDown
    {
        get { return isSwipeDown; }
        set { isSwipeDown = value; }
    } 
      

    private void Update()
    {


        if (touchDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            touchDown = true;
        }

        if (touchDown)
        {
            if (Input.touches[0].position.y >= startPos.y + minSwipeRange)
            {
                touchDown = false;
                isSwipeUp = true;
            }
            else if (Input.touches[0].position.x <= startPos.x - minSwipeRange)
            {
                touchDown = false;
                isSwipeLeft = true;
            }
            else if (Input.touches[0].position.x >= startPos.x + minSwipeRange)
            {
                touchDown = false;
                isSwipeRight = true;
            }
            else if (Input.touches[0].position.y <= startPos.y - minSwipeRange)
            {
                touchDown = false;
                isSwipeDown = true;
            }
        }

        if (touchDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            touchDown = false;
        }

    }
}
