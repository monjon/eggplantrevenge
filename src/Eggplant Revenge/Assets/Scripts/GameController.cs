using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
	
	public static int score;
	
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
