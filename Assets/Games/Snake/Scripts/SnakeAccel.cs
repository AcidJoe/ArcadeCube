using UnityEngine;
using System.Collections;

public class SnakeAccel : MonoBehaviour, ISnakeController
 {
    public int _direction = 0;

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
