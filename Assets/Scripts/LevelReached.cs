using UnityEngine;
using System.Collections;

public class LevelReached : MonoBehaviour {

    // Use this for initialization
	void Start () {
        G g = GameObject.Find ("G").GetComponent<G> ();
        GameObject text = GameObject.Find ("GUI Text Level XX");
        Lang lang = GameObject.Find ("Lang").GetComponent<Lang> ();

        text.guiText.text = lang.get ("LEVEL") + " " + (g.getLevel () - 1);	
	}
	
}
