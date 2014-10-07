using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class LocalizedText : MonoBehaviour {
    public string key;

    private Lang lang;
    Text text;

	// Use this for initialization
	void Start () {
        lang = GameObject.Find ("Lang").GetComponent<Lang> ();
        lang.addOnChangeListener (OnChangeLanguage); 

        text = gameObject.GetComponent<Text> ();
        text.text = lang.get (key);
    }
	
    public void OnChangeLanguage(LanguageManager languageManager)
    {
        text.text = lang.get (key);
    }

    void OnDestroy()
    {
        lang.removeChangeListener (OnChangeLanguage);
    }
}
