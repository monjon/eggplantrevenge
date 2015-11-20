using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
	
	public static int score;
	
	public GameObject kaiju;
	
	private ArmyWaves waves;
	
	public float reloadWave;
	private bool previous;
	private float nextWave;
	
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		score = 0;
		
		waves = GetComponent<ArmyWaves>();
		previous = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (waves.isWaveFinished && !previous) {
			nextWave = Time.time + reloadWave;
		}
		previous = waves.isWaveFinished;
		
		if (waves.isWaveFinished && Time.time > nextWave) {
			waves.newWave();
		}
	}
}
