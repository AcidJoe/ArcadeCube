using UnityEngine;
using System.Collections;

public class SnakeManager : MonoBehaviour
{
    public SnakeControl conrol;
    public SnakeUI _UI;

    public enum State { Pause,Game}

    public State current;

	void Start ()
    {
        SnakeEventManager.StartEvent(0);
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && current == State.Game)
        {
            SnakeEventManager.StartEvent(0);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && current == State.Pause)
        {
            SnakeEventManager.StartEvent(1);
        }
	}

    void OnEnable()
    {
        SnakeEventManager.Pause += OnPause;
        SnakeEventManager.Resume += OnResume;
    }

    public void OnPause()
    {
        SetState(State.Pause);
        Time.timeScale *= 0;
    }

    public void OnResume()
    {
        SetState(State.Game);
        Time.timeScale = 1;
    }

    public void SetState(State s)
    {
        current = s;
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
