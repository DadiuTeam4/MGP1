using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class LanguageController : MonoBehaviour
{

    // Use this for initialization
    public Hashtable allStrings;
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
        XmlDocument xml = new XmlDocument();
        xml.Load("Assets/lang.xml");
        allStrings = new Hashtable();
        var element = xml.GetElementById("dan");
        if (element != null) 
        { 
           IEnumerator ele =  element.GetEnumerator();
           while(ele.MoveNext())
           {
               string name = (ele.Current as XmlElement).GetAttribute("name");
               string value = (ele.Current as XmlElement).InnerText;
               allStrings.Add(name, value);
               Debug.Log(name + ", " + value);
           }
        } else {
            Debug.LogError("The specified language does not exist: " + element);
        }
    }

    private void setEnglish()
    {

    }

}
