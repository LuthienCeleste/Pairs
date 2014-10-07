using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsAltController : MonoBehaviour {
    private GameObject text;
    private string creditsTxt;

	// Use this for initialization
	void Start () {
        TextAsset txt = (TextAsset)Resources.Load("credits", typeof(TextAsset));
        creditsTxt = txt.text;  
        text = GameObject.Find("Text");
        text.  GetComponent<Text> ().text = creditsTxt;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
