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
        difficulty = Difficulty.Normal;
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
}
