using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Difficulty
{
    NoTime,
    Easy,
    Normal,
    Hard
}

public class OptionsController : MonoBehaviour {
    private G g;
    private Text textNoTime;
    private Text textEasy;
    private Text textNormal;
    private Text textHard;

	// Use this for initialization
	void Start () {
        g = GameObject.Find ("G").GetComponent<G> ();
        textNoTime = GameObject.Find ("TextNoTime").GetComponent<Text> ();
        textEasy   = GameObject.Find ("TextEasy")  .GetComponent<Text> ();
        textNormal = GameObject.Find ("TextNormal").GetComponent<Text> ();
        textHard   = GameObject.Find ("TextHard")  .GetComponent<Text> ();
    }
	
	// Update is called once per frame
	void Update () {
        textNoTime.color = Color.white;
        textEasy.color = Color.white;
        textNormal.color = Color.white;
        textHard.color = Color.white;
	    switch (g.getDifficulty ()) {
        case Difficulty.NoTime :
            textNoTime.color = Color.green;
            break;
        case Difficulty.Easy :
            textEasy.color = Color.green;
            break;
        case Difficulty.Normal :
            textNormal.color = Color.green;
            break;
        case Difficulty.Hard :
            textHard.color = Color.green;
            break;
        }
	}

    public void NoTime()
    {
        g.SetDifficulty ( Difficulty.NoTime);
    }

    public void Easy()
    {
        g.SetDifficulty (Difficulty.Easy);
    }

    public void Normal()
    {
        g.SetDifficulty (Difficulty.Normal);
    }

    public void Hard()
    {
        g.SetDifficulty (Difficulty.Hard);
    }

    public void Back()
    {
        g.SaveDifficulty ();
        Application.LoadLevel ("TittleScene");
    }
}
