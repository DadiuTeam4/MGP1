using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseController : MonoBehaviour
{

    public Button pauseBtn;
    public Text text;
    private bool isPaused = false;

    public GameObject languageOption;
    // Use this for initializati<on
    void Start()
    {
        pauseBtn.GetComponent<Button>().onClick.AddListener(tasksOnClick);
    }

    void tasksOnClick()
    {
        if (!isPaused)
        {
            if (languageOption != null)
            {
                languageOption.SetActive(true);
            }
            Time.timeScale = 0;
            text.GetComponent<Text>().text = "Resume";
            isPaused = true;
        }
        else
        {
            if (languageOption != null)
            {
                languageOption.SetActive(false);
            }
            Time.timeScale = 1;
            text.GetComponent<Text>().text = "Pause";
            isPaused = false;
        }
    }


}
