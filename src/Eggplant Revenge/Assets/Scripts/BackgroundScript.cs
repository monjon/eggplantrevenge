﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundScript : MonoBehaviour {

	public int rangeMin;
	public int rangeMax;

	// Position background
	private static float backPos;

	public GameObject[] buildingModel;

	private List<GameObject> buildings = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
		GameObject parent = null;
		GameObject instance = null;
		
		float sizeX, sizeY;
		
		for (int rank = 0; rank < 3; rank++) {
			int index = rangeMin;
			
			while (index < rangeMax) {			
				parent = new GameObject();
				instance = Instantiate(buildingModel[Random.Range(0, buildingModel.Length)]);
				instance.transform.parent = parent.transform;
				
				sizeX = Random.Range(.5f, 3f);
				sizeY = Random.Range(3f, 10f);
				
				instance.transform.localScale = new Vector3 (sizeX, sizeY, 1f);
				instance.transform.Rotate(0, 0, Random.Range(-10f, 10f));

				//parent.transform.Translate(index, -2, 4 + rank + Random.Range(0, 0.1f));
				parent.transform.Translate(index, -2, 4 + rank + (index % 3) * .1f);
				index += 2;
				
				buildings.Add(parent);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		Move(2f * Time.deltaTime);
		
		if (backPos != 0) {
			
			for (int i = 0; i < buildings.Count; i++) {
				buildings[i].transform.Translate(backPos, 0, 0);
				if (buildings[i].transform.position.x > rangeMax) {
					buildings[i].transform.Translate(rangeMin - rangeMax, 0, 0);
				}
			}
			
			backPos = 0;
		}
	}
	
	public static void Move(float delta) {
		backPos += delta;
	}
}
