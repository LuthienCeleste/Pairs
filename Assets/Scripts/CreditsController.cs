using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {
    public Vector2 scrollPosition;

    string creditsTxt;
    string cc_by_3_part1_txt;
    string cc_by_3_part2_txt;
    string apache;
    string gpl_part1;
    string gpl_part2;
    string gpl_part3;

    string display;
	// Use this for initialization
	void Start () {
        TextAsset txt = (TextAsset)Resources.Load("Licenses/credits", typeof(TextAsset));
        creditsTxt = txt.text;  
        txt = (TextAsset)Resources.Load("Licenses/cc-by-3_0-PART1-legalcode", typeof(TextAsset));
        cc_by_3_part1_txt = txt.text;  
        txt = (TextAsset)Resources.Load("Licenses/cc-by-3_0-PART2-legalcode", typeof(TextAsset));
        cc_by_3_part2_txt = txt.text;  
        txt = (TextAsset)Resources.Load("Licenses/Apache-LICENSE-2.0", typeof(TextAsset));
        apache = txt.text;  
        txt = (TextAsset)Resources.Load("Licenses/gpl-3.0-part1", typeof(TextAsset));
        gpl_part1 = txt.text;  
        txt = (TextAsset)Resources.Load("Licenses/gpl-3.0-part2", typeof(TextAsset));
        gpl_part2 = txt.text;  
        txt = (TextAsset)Resources.Load("Licenses/gpl-3.0-part3", typeof(TextAsset));
        gpl_part3 = txt.text;  

        display = creditsTxt;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        int buttonHeight = (int) ( (Screen.height-10) * .05f);

        GUILayout.BeginArea (new Rect (5, 5, Screen.width - 10, Screen.height - 10 - buttonHeight*4));
        scrollPosition = GUILayout.BeginScrollView (scrollPosition, 
                                                    GUILayout.Width (Screen.width - 10), 
                                                    GUILayout.Height (Screen.height - 10 - buttonHeight*4));
        /*changes made in the below 2 lines */
        GUI.skin.box.alignment = TextAnchor.MiddleLeft;
        GUI.skin.box.wordWrap = true;     // set the wordwrap on for box only.
        GUILayout.Box (display);        // just your message as parameter.
        
        GUILayout.EndScrollView ();
        
        GUILayout.EndArea ();       
        if (GUI.Button (new Rect (5, Screen.height - buttonHeight * 4 - 5, (Screen.width - 10)/2, buttonHeight), "GPL 3.0 Part 1 License"))
            display = gpl_part1;
        if (GUI.Button (new Rect (5, Screen.height - buttonHeight * 3 - 5, (Screen.width - 10)/2, buttonHeight), "GPL 3.0 Part 2 License"))
            display = gpl_part2;
        if (GUI.Button (new Rect (5, Screen.height - buttonHeight * 2 - 5, (Screen.width - 10)/2, buttonHeight), "GPL 3.0 Part 3 License"))
            display = gpl_part3;
        if (GUI.Button (new Rect (Screen.width/2, Screen.height - buttonHeight * 3 - 5, (Screen.width - 10)/2, buttonHeight), "CC-BY-3.0 License Part 1"))
            display = cc_by_3_part1_txt;
        if (GUI.Button (new Rect (Screen.width/2, Screen.height - buttonHeight * 2 - 5, (Screen.width - 10)/2, buttonHeight), "CC-BY-3.0 License Part 2"))
            display = cc_by_3_part2_txt;
        if (GUI.Button (new Rect (5, Screen.height - buttonHeight * 1 - 5, (Screen.width - 10)/2, buttonHeight), "Apache 2.0 License"))
            display = apache;
        if (GUI.Button (new Rect (Screen.width/2, Screen.height - buttonHeight - 5, (Screen.width - 10)/2, buttonHeight), "Exit"))
            Application.LoadLevel ("MainScene");
    }
}
