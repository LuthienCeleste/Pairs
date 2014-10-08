using UnityEngine;
using System.Collections;
using SmartLocalization;

public class Lang : MonoBehaviour {
    private LanguageManager languageManager;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad (this);
        languageManager = LanguageManager.Instance;
        LoadLang ();
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
        SaveLang (lang);
    }

    public void addOnChangeListener( ChangeLanguageEventHandler callback )
    {
        languageManager.OnChangeLanguage += callback;
    }

    public void removeChangeListener( ChangeLanguageEventHandler callback )
    {
        languageManager.OnChangeLanguage -= callback;
    }

    private void LoadLang()
    {
        string lang;
        if (PlayerPrefs.HasKey ("Language")) {
            lang = PlayerPrefs.GetString ("Language");
            Debug.Log ("loaded lang " + lang);
        } else {
            lang = "en";
            Debug.Log ("defaulted lang " + lang);
        }
        languageManager.ChangeLanguage (lang);
    }
    
    public void SaveLang(string lang)
    {
        Debug.Log ("saving lang " + lang);
        PlayerPrefs.SetString ("Language", lang);
        PlayerPrefs.Save ();
    }

}

















