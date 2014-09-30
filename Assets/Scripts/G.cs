using UnityEngine;
using System.Collections;

public class G : MonoBehaviour {
	private int level;
	private Sprite[] icons;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		ResetLevel();
		icons = Resources.LoadAll<Sprite> ("Icons");
		Debug.Log ("Loaded " + icons.Length + " icons");
	}

	public Sprite[] getIcons()
	{
		return icons;
	}

	public void ResetLevel()
	{
		level = 2;
	}

	public int getNextLevel() {
		return ++level;
	}

	public int getLevel()
	{
			return level;
	}


	
}
