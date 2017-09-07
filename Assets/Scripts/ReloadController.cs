using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadController : MonoBehaviour
{
    public Button reloadBtn;
    // Use this for initialization
    void Start()
    {
        reloadBtn.GetComponent<Button>().onClick.AddListener(tasksOnClick);
    }
    void tasksOnClick()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
