using UnityEngine;
using System.Collections;
using SmartLocalization;

public class Lang : MonoBehaviour {
    private LanguageManager languageManager;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad (this);
        languageManager = LanguageManager.Instance;
        languageManager.ChangeLanguage ("en");
	}

    public string get( string key )
    {
        if (!languageManager.HasKey (key))
            Debug.Log ("Localization key not found : " + key);
        return languageManager.GetTextValue(key);
    }

    public void SetLanguage( string lang )
    {
        languageManager.ChangeLanguage (lang);
    }

    public void addOnChangeListener( ChangeLanguageEventHandler callback )
    {
        languageManager.OnChangeLanguage += callback;
    }

    public void removeChangeListener( ChangeLanguageEventHandler callback )
    {
        languageManager.OnChangeLanguage -= callback;
    }
}

















