using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{
    public Snake snake;
    public ISnakeController sConroller;

    public SnakeFourButton buttons;
    public SnakeSwipe swipe;
    public SnakeAccel accel;

	void Start ()
    {

	}

	void Update ()
    {
	
	}

    public void SetController(string s)
    {
        switch (s)
        {
            case "Buttons":
                sConroller = buttons;
                break;
            case "Swipe":
                sConroller = swipe;
                break;
            case "Acc":
                sConroller = accel;
                break;
        }

        snake.controller = sConroller;
    }
}
