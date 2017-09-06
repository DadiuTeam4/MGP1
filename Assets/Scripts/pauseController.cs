using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseController : MonoBehaviour
{

    public Button pauseBtn;
    public Text text;
    private bool isPaused;
    // Use this for initializati<on
    void Start()
    {
        pauseBtn.GetComponent<Button>().onClick.AddListener(tasksOnClick);
    }

    void tasksOnClick()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            text.GetComponent<Text>().text = "Resume";
			isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            text.GetComponent<Text>().text = "Pause";
			isPaused = false;
        }
    }


}
