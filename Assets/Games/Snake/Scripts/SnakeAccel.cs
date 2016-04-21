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

        if (Mathf.Abs(accel.y) > Mathf.Abs(accel.z) && accel.y > 0.2f)
        {
            SetDirection(2);
        }

        else if (Mathf.Abs(accel.y) > Mathf.Abs(accel.z) && accel.y < -0.2f)
        {
            SetDirection(8);
        }

        else if (Mathf.Abs(accel.y) < Mathf.Abs(accel.z) && accel.y > 0.2f)
        {
            SetDirection(6);
        }

        else if (Mathf.Abs(accel.y) < Mathf.Abs(accel.z) && accel.y < -0.2f)
        {
            SetDirection(4);
        }

        else if(Mathf.Abs(accel.y) < 0.2f && Mathf.Abs(accel.z)< 0.2f)
        {
            SetDirection(0);
        }
    }
}
