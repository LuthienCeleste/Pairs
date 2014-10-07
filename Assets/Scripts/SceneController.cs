using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    private G g;

	// Use this for initialization
	void Start () {
        g = GameObject.Find ("G").GetComponent<G> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetButtonUp ("Fire1")) {
  //          g.ResetLevel();
    //        Application.LoadLevel ("GameScene");
      //  }
	}

    void OnGUI()
    {
/*        int buttonHeight = (int) (Screen.height * .1f);
        int buttonWidth = (int)(Screen.width * .5f);
        int buttonX = (int)(Screen.width * .25f);
        int buttonY = (int)(Screen.height * .8f);
        if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), "Credits"))
            Application.LoadLevel ("CreditsScene");    

        buttonHeight = (int) (Screen.height * .1f);
        buttonWidth = (int)(Screen.width * .5f);
        buttonX = (int)(Screen.width * .25f);
        buttonY = (int)(Screen.height * .65f);
        if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), "PLAY")) {
            g.ResetLevel();
            Application.LoadLevel ("GameScene");    
        }
*/    }

    public void Credits()
    {
        Application.LoadLevel ("CreditsScene");
    }

    public void Play()
    {
        g.ResetLevel();
        Application.LoadLevel ("GameScene");    
    }

}
