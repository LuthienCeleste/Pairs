using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelReached : MonoBehaviour {

    // Use this for initialization
	void Start () {
        G g = GameObject.Find ("G").GetComponent<G> ();
        Text text = GameObject.Find ("TextLevelX").GetComponent<Text> ();
        Lang lang = GameObject.Find ("Lang").GetComponent<Lang> ();

        text.text = lang.get ("LEVEL") + " " + (g.getLevel () - 1);	
	}
	
}
