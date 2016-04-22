using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SnakeUI : MonoBehaviour
{
    public SnakeControl Sc;
    //Panels and Buttons
    public GameObject pausePanel;
    public GameObject pauseButton;

    //Controls
    public GameObject FourButton;
    public GameObject FourHiddenButtons;
    public GameObject Cross;

    public Text CurrentControl;

    string _controlName = " None";

    public GameObject exeptionMessage;

    public enum Control
    {
        Swipe,
        Accelerometer,
        FourButton,
        FourHiddenButton,
        Cross,
        None
    }

    public Control current;

	void Start ()
    {
        current = Control.None;
	}
	
	void Update ()
    {
        CurrentControl.text = _controlName;

        if (exeptionMessage.activeInHierarchy && current != Control.None)
        {
            exeptionMessage.SetActive(false);
        } 
	}

    public void SetControl(int c)
    {
        switch (c)
        {
            case 1:
                Sc.SetController("Swipe");
                _controlName = " Swipe";
                current = Control.Swipe;
                break;
            case 2:
                Sc.SetController("Acc");
                _controlName = " Accelerometer";
                current = Control.Accelerometer;
                break;
            case 3:
                Sc.SetController("Buttons");
                _controlName = " 4 Buttons";
                current = Control.FourButton;
                break;
            case 4:
                Sc.SetController("Buttons");
                _controlName = " 4 Hidden Buttons";
                current = Control.FourHiddenButton;
                break;
            case 5:
                Sc.SetController("Buttons");
                _controlName = " Cross";
                current = Control.Cross;
                break;
        }
    }

    public void OnPause()
    {
        exeptionMessage.SetActive(false);
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        FourButton.SetActive(false);
        FourHiddenButtons.SetActive(false);
        Cross.SetActive(false);
    }

    public void OnResume()
    {
        exeptionMessage.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);

        switch (current)
        {
            case Control.FourButton:
                FourButton.SetActive(true);
                break;
            case Control.FourHiddenButton:
                FourHiddenButtons.SetActive(true);
                break;
            case Control.Cross:
                Cross.SetActive(true);
                break;
        }

    }

    void OnEnable()
    {
        SnakeEventManager.Pause += OnPause;
        SnakeEventManager.Resume += OnResume;
    }

    public void PauseEvent()
    {
        SnakeEventManager.StartEvent(0);
    }

    public void ResumeEvent()
    {
        if (current != Control.None)
        {
            SnakeEventManager.StartEvent(1);
        }
        else
        {
            exeptionMessage.SetActive(true);
        }
    }
}
