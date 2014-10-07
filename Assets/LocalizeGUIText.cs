using UnityEngine;
using System.Collections;
using SmartLocalization;

public class LocalizeGUIText : MonoBehaviour {
    public string key;

    	// Use this for initialization
	void Start () {
        Lang lang = GameObject.Find ("Lang").GetComponent<Lang> ();
        guiText.text = lang.get (key);
	}
	
}
