using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class LanguageController : MonoBehaviour
{

    // Use this for initialization
    private Hashtable allStrings;
    public Text reloadText;
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
        XmlElement element = xml.GetElementById("dan");
        IEnumerator ele = element.GetEnumerator();
        XmlNode item;
        while (ele.MoveNext())
        {
            item = (XmlNode)ele.Current;
            string value = item.InnerText;
            string name = item.Attributes["name"].Value;
            allStrings.Add(name, value);
        }

        reloadText.GetComponent<Text>().text = getString("reload");
    }

    private void setEnglish()
    {

    }

    public string getString(string name){
        if(!allStrings.ContainsKey(name))
        {
            Debug.LogError(name+ " is not exist");
            return "";
        }else{
            return (string)allStrings[name];
        }
    }

}
