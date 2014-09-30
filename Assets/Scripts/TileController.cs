using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {
	private int type;
	private int boardX;
	private int boardY;
	private GameController controller;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        renderer.enabled = !controller.IsQuitScreenShowing ();
        collider2D.enabled = !controller.IsQuitScreenShowing ();
	}

	void OnMouseUpAsButton()
	{
		controller.TileClicked (this);
	}

	public void setData( int type, int boardX, int boardY, GameController controller )
	{
		this.type = type;
		this.boardX = boardX;
		this.boardY = boardY;
		this.controller = controller;
	}

	public int GetIconType()
	{
		return type;
	}

	public int GetBoardX()
	{
		return boardX;
	}

	public int GetBoardY()
	{
		return boardY;
	}
}
