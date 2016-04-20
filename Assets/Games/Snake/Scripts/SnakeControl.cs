using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{
    public Snake snake;
    public ISnakeController sConroller;

	void Start ()
    {
        sConroller = GetComponent<SnakeSwipe>();

        snake.controller = sConroller;
	}

	void Update ()
    {
	
	}
}
