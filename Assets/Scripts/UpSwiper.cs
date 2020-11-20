using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSwiper : MonoBehaviour
{
    public float maxSwipeTime;
    public float minSwipeDist;



    float swipeStartTime;
    float swipeEndTime;
    float swipeLength;
    float swipeTime;


    Vector2 startSwipePos;
    Vector2 endSwipePos;

    private void Update()
    {
        SwipeTest();
    }

    void SwipeTest()
    { 
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                swipeStartTime = Time.deltaTime;
                startSwipePos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                swipeEndTime = Time.deltaTime;
                endSwipePos = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipeLength = (endSwipePos - startSwipePos).magnitude;

                if(swipeTime < maxSwipeTime && swipeLength > minSwipeDist)
                {
                    SwipeControl();
                }
            }
        }
    }

    private void SwipeControl()
    {
        Vector2 Distance = endSwipePos - startSwipePos;
        float xDistance = Mathf.Abs(Distance.x);
        float yDistance = Mathf.Abs(Distance.y);

        if(yDistance > xDistance)
        {
            if(Distance.y > 0)
            {
                Debug.Log("SwipedUP");
            }
        }
    }
}
