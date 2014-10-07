using UnityEngine;
using System.Collections;
using System;

public class G : MonoBehaviour {
	private int level;
	private Sprite[] icons;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		ResetLevel();
		icons = Resources.LoadAll<Sprite> ("Icons");
		Debug.Log ("Loaded " + icons.Length + " icons");
        LoadDifficulty ();
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

    private Difficulty difficulty;
    public void SetDifficulty( Difficulty difficulty )
    {
        this.difficulty = difficulty;
    }

    public Difficulty getDifficulty()
    {
        return difficulty;
    }

    private void LoadDifficulty()
    {
        if (PlayerPrefs.HasKey ("Difficulty")) {
            difficulty = (Difficulty) Enum.Parse(typeof(Difficulty),
                                    PlayerPrefs.GetString("Difficulty") );
        }
        else
            difficulty = Difficulty.Normal;
    }

    public void SaveDifficulty()
    {
        PlayerPrefs.SetString ("Difficulty", difficulty.ToString ());
        PlayerPrefs.Save ();
    }
}
