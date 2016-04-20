using UnityEngine;
using System.Collections;

public class SnakeSwipe : MonoBehaviour, ISnakeController
{
    public int _direction = 0;

    public float minSwipeLength = 10.0f;

    Vector2 firstTouch;
    Vector2 secondTouch;
    Vector2 swipeDirection;

    void Start()
    {

    }

    void Update()
    {
        Swipe();
    }

    public void SetDirection(int i)
    {
        _direction = i;
    }

    public int GetDirection()
    {
        return _direction;
    }

    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstTouch = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                secondTouch = new Vector2(t.position.x, t.position.y);
                swipeDirection = new Vector2(secondTouch.x - firstTouch.x, secondTouch.y - firstTouch.y);

                if (swipeDirection.magnitude < minSwipeLength)
                {
                    SetDirection(0);
                    return;
                }

                swipeDirection.Normalize();

                //Swipe Up
                if (swipeDirection.y > 0 && swipeDirection.x > -0.5f && swipeDirection.x < 0.5f)
                {
                    _direction = 2;
                }
                //Swipe Down
                else if (swipeDirection.y < 0 && swipeDirection.x > -0.5f && swipeDirection.x < 0.5f)
                {
                    _direction = 8;
                }
                //Swipe Left
                else if (swipeDirection.x < 0 && swipeDirection.y > -0.5f && swipeDirection.y < 0.5f)
                {
                    _direction = 4;
                }
                //Swipe Right
                else if (swipeDirection.x > 0 && swipeDirection.y > -0.5f && swipeDirection.y < 0.5f)
                {
                    _direction = 6;
                }
                else
                {
                    _direction = 0;
                }
            }
        }
    }
}
