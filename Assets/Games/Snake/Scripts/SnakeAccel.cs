using UnityEngine;
using System.Collections;

public class SnakeAccel : MonoBehaviour, ISnakeController
 {
    public int _direction = 0;

    Vector3 accel;

    void Start ()
    {
	
	}
	
	void Update ()
    {
        AccelInput();
	}

    public void SetDirection(int i)
    {
        _direction = i;
    }

    public int GetDirection()
    {
        return _direction;
    }

    public void AccelInput()
    {
        accel = Input.acceleration;

        if (Mathf.Abs(accel.y) > Mathf.Abs(accel.x) && accel.y > 0.1f)
        {
            SetDirection(2);
        }

        else if (Mathf.Abs(accel.y) > Mathf.Abs(accel.x) && accel.y < -0.1f)
        {
            SetDirection(8);
        }

        else if (Mathf.Abs(accel.y) < Mathf.Abs(accel.x) && accel.x > 0.1f)
        {
            SetDirection(6);
        }

        else if (Mathf.Abs(accel.y) < Mathf.Abs(accel.x) && accel.x < -0.1f)
        {
            SetDirection(4);
        }
    }
}
