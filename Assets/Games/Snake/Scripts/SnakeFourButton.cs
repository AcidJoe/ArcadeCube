using UnityEngine;
using System.Collections;

public class SnakeFourButton : MonoBehaviour, ISnakeController
{
    int _direction;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void SetDirection(int i)
    {
        _direction = i;
    }

    public int GetDirection()
    {
        return _direction;
    }
}
