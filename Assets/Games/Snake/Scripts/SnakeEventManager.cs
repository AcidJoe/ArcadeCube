using UnityEngine;
using System.Collections;

public class SnakeEventManager : MonoBehaviour
{
    public delegate void OnGamePaused();

    public static event OnGamePaused Pause;
    public static event OnGamePaused Resume;

    void Start()
    {

    }

    void Update()
    {

    }

    public static void StartEvent(int i)
    {
        switch (i)
        {
            case 0:
                if (Pause != null)
                    Pause();
                break;
            case 1:
                if (Resume != null)
                    Resume();
                break;
        }
    }
}
