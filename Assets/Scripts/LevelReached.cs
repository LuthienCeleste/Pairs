using UnityEngine;
using System.Collections;

public class LevelReached : MonoBehaviour {
	// Use this for initialization
	void Start () {
        G g = GameObject.Find ("G").GetComponent<G> ();
        GameObject text = GameObject.Find ("GUI Text Level XX");
        text.guiText.text = "LEVEL " + (g.getLevel () - 1);	
	}
	
}
