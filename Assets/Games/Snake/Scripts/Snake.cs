﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public GameObject snakeBit;

    public enum State { left, right, up, down}

    public State currentState;

    public Vector2 dir;

    bool isChoosen;
    Vector2 prevPos, nextPos;
    Quaternion prevRot;

    public float spawnTime;

    Queue<GameObject> bits;

    public int lenght;

    void Start ()
    {
        spawnTime = 0.2f;
        bits = new Queue<GameObject>();
        lenght = 3;
        setState(State.up);
        Invoke("MoveSnake", spawnTime);
	}
	
	void Update ()
    {
	
	}

    void MoveSnake()
    {
        isChoosen = false;
        prevPos = transform.position;
        prevRot = transform.rotation;
        nextPos = prevPos + dir;
        if (nextPos.x > 15.0f)
        {
            nextPos.x = -15.0f;
        }
        if (nextPos.x < -15.0f)
        {
            nextPos.x = 15.0f;
        }
        if (nextPos.y > 10.0f)
        {
            nextPos.y = -10.0f;
        }
        if (nextPos.y < -10.0f)
        {
            nextPos.y = 10.0f;
        }

        transform.position = nextPos;

        createBit();
        Invoke("MoveSnake", spawnTime);
    }

    void createBit()
    {
        var newBit = Instantiate(snakeBit, prevPos, prevRot);
        GameObject bit = newBit as GameObject;
        bits.Enqueue(bit);

        if (bits.Count > lenght)
        {
            Destroy(bits.Dequeue());
        }
    }

    void setState(State state)
    {
        switch (state)
        {
            case State.up:
                dir = Vector2.up;
                break;
            case State.down:
                dir = -Vector2.up;
                break;
            case State.left:
                dir = -Vector2.right;
                break;
            case State.right:
                dir = Vector2.right;
                break;
        }
        currentState = state;
    }
}
