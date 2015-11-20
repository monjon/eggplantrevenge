using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmyWaves : MonoBehaviour {

	public int enemyIncrease;

	// Position de depart gauche
	public float startLeft;
	// Position de depart droite
	public float startRight;
	// Ecart entre 2 unites
	public float startDistance;


	public GameObject kaiju;

	public GameObject prefabTank;
	public GameObject prefabCopter;
	public GameObject prefabJeep;

	public List<GameObject> tanks = new List<GameObject>();
	public List<GameObject> copters = new List<GameObject>();
	public List<GameObject> jeeps = new List<GameObject>(); 

	int waves;
	
	int nbTanks;
	int nbCopters;
	int nbJeeps;
	
	public bool isWaveFinished;
	
	private float[] lines;

	private float[] height;

	// Use this for initialization
	void Start () {
		nbTanks = 2;
		nbCopters = 0;
		nbJeeps = -2;
		
		lines = new float[3];
		lines[0] = kaiju.transform.position.z;
		lines[1] = kaiju.transform.position.z - 2f;
		lines[2] = kaiju.transform.position.z + 2f;
		
		height = new float[3];
		height[0] = 2.5f;
		height[1] = 4f;
		height[2] = 5.5f;
	}
	
	// Update is called once per frame
	void Update () {
		int armyCount = 0;

		armyCount += countAlive(tanks);
		armyCount += countAlive(copters);
		armyCount += countAlive(jeeps);		
		
		isWaveFinished = armyCount == 0;
	}
	
	int countAlive(List<GameObject> enemies) {
		int armyCount = 0;
		
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies[i] != null) armyCount++;
		}
		
		return armyCount;
	}
	
	public void newWave() {
		//  tanks = new List<GameObject>();
		//  copters = new List<GameObject>();
		//  jeeps = new List<GameObject>();
		
		waves++;
		nbTanks += enemyIncrease;
		nbCopters += enemyIncrease;
		//nbJeeps += enemyIncrease;
		
		GameObject instance;
		for (int i = 0; i < nbTanks; i++) {
			instance = Instantiate(prefabTank);
			instance.transform.Translate(startLeft - startDistance * i, -4, lines[Random.Range(0, lines.Length)]);
			tanks.Add(instance);
		}

		for (int i = 0; i < nbCopters; i++) {
			instance = Instantiate(prefabCopter);
			instance.transform.Translate(startLeft - startDistance * i, height[Random.Range(0, height.Length)], lines[Random.Range(0, lines.Length)]);
			copters.Add(instance);
		}

		for (int i = 0; i < nbJeeps; i++) {
			instance = Instantiate(prefabJeep);
			instance.transform.Translate(startRight + startDistance * i, -4, lines[Random.Range(0, lines.Length)]);
			jeeps.Add(instance);
		}
		
		
		isWaveFinished = false;
	}
	
}
