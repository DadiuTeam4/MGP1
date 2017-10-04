using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Dropdown dropdown = gameObject.GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate
        {
            languageChangeHandler(dropdown);
        }
        );
    }

    private void languageChangeHandler(Dropdown dropdown)
    {
        Debug.Log(dropdown.value);
        if (dropdown.value == 0)
        {
            setEnglish();
        }
        else if (dropdown.value == 1)
        {
            setDanish();
        }

    }

    private void setDanish()
    {
		AkSoundEngine.SetState ("Speak_language", "DK"); 
		print ("DAAANSK"); 
    }

    private void setEnglish()
    {
		AkSoundEngine.SetState ("Speak_language", "UK"); 
		print ("ENGEEEELSK"); 
    }

}
