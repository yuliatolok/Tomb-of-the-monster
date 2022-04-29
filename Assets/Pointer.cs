using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false, isTaping = false;
    private Vector2 startTouch, swipeDelta, swipeLeight;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        tap = true;
        isDraging = true;
        startTouch = eventData.position;
        swipeDelta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        swipeDelta = eventData.position - startTouch;
        swipeLeight = swipeDelta;
        Debug.Log("swipeLeight is " + swipeLeight.magnitude);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
       
        if (swipeLeight.magnitude < 350)
        {
            IsTaping = true;
        }        
        Reset();
    }

    void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        if (swipeDelta.magnitude > 350)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 500) swipeLeft = true;
                else swipeRight = true;
            }
            else
            {
                if (y < 500) swipeDown = true;
                else swipeUp = true;
            }
            Debug.Log(swipeLeft + " "+ swipeDown+ " "+ swipeRight + " " + swipeUp);
            Reset();

        }
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
        IsTaping = false;
        isTaping = false;
    }



    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool IsTaping;
}
