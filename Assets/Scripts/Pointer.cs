using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsTaping;
    public Vector2 GetSwipe => swipe;
    private Vector2 startTouch, swipeDelta, swipeLeight;
    private Vector2 swipe;

    public event Action<Vector2> OnSwipe;
    public event Action OnClick;
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        swipeDelta = eventData.position - startTouch;
        swipeLeight = swipeDelta;
        if (swipeLeight.magnitude < 50)
        {
            IsTaping = true;
        }

        if (swipeDelta.magnitude > 70)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0) swipe = Vector2.left;
                else swipe = Vector2.right;
            }
            else
            {
                if (y < 0) swipe = Vector2.down;
                else swipe = Vector2.up;
            }
            OnSwipe?.Invoke(swipe);
            Reset();

        }
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        IsTaping = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startTouch = eventData.position;
        swipeDelta = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        swipeDelta = eventData.position - startTouch;
        swipeLeight = swipeDelta;
        if (swipeLeight.magnitude < 50)
        {
            IsTaping = true;
        }

        if (swipeDelta.magnitude > 70)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0) swipe = Vector2.left;
                else swipe = Vector2.right;
            }
            else
            {
                if (y < 0) swipe = Vector2.down;
                else swipe = Vector2.up;
            }
            OnSwipe?.Invoke(swipe);

        }
        else
        {
            OnClick?.Invoke();
        }
        Reset();
    }
}
