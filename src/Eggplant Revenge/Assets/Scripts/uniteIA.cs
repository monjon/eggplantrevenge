using UnityEngine;
using System.Collections;

public class uniteIA : MonoBehaviour {
	
	public float speed;
	public float fireRate;
	public float rangeMin;
	public float rangeMax;

	//public GameObject kaijuObj;
	private Transform kaiju;
	//  public Transform frontCheck;
	//  public Transform backCheck;
	public bool fireInTheHole;

	private int state;
	private float nextFire;
	private float distance;
	
	private const int STATE_MOVE = 0;
	private const int STATE_READY = 1;
	private const int STATE_LOCKED = 2;
	private const int STATE_FIRE = 3;
	private const int STATE_BACK = 4;
 
	private ArmyWaves waves;
	private float minDist;

	// Use this for initialization
	void Start () {
		
		GameObject kaijuObj = GameObject.Find("Kaiju");
		kaiju = kaijuObj.transform;
		state = STATE_MOVE;
		nextFire = -1;

		GameObject camera = GameObject.Find("Main Camera");
		waves = camera.GetComponent<ArmyWaves>();
		
		distance = ((rangeMax - rangeMin) * (1f - Random.value) + rangeMin); 
		minDist = waves.startDistance - 0.5f;		
	}
	
	// Update is called once per frame
	void Update () {

		bool allyBack = false;
		bool allyFront = false;
		
		// Comparaison
		Vector3 currentPos = transform.position;
		Vector3 pos;
		float dist;
		
		for (int i = 0; i < waves.tanks.Count; i++) {
			pos = waves.tanks[i].transform.position;
			if (pos.y == currentPos.y && pos.x != currentPos.x) {
				dist = currentPos.x - pos.x;					
				if (dist > 0 && dist < minDist) {
					allyBack = true;
				} else if (dist < 0 && (minDist + dist) > 0) {
					allyFront = true;
				}
			}
		}
		for (int i = 0; i < waves.copters.Count; i++) {
			pos = waves.copters[i].transform.position;
			if (pos.y == currentPos.y && pos.x != currentPos.x) {
				dist = currentPos.x - pos.x;					
				if (dist > 0 && dist < minDist) {
					allyBack = true;
				} else if (dist < 0 && (minDist + dist) > 0) {
					allyFront = true;
				}
			}
		}
		for (int i = 0; i < waves.jeeps.Count; i++) {
			pos = waves.jeeps[i].transform.position;
			if (pos.y == currentPos.y && pos.x != currentPos.x) {
				dist = currentPos.x - pos.x;					
				if (dist > 0 && dist < minDist) {
					allyBack = true;
				} else if (dist < 0 && (minDist + dist) > 0) {
					allyFront = true;
				}
			}
		}		
		
		
		float current = kaiju.position.x - transform.position.x;
		
		// Machine a etats
		switch (state) {

			case STATE_MOVE: 
				if (current <= distance) {
					state = STATE_READY;
				} else if (allyFront) {
					state = STATE_LOCKED;
				}		
			break;
			case STATE_READY:
				if (current < rangeMin) {
					if (allyBack) {
						state = STATE_LOCKED;
					} else {
						state = STATE_BACK;
					}
				} else if (current > rangeMax) {
					if (allyFront) {
						state = STATE_LOCKED;
					} else {
						state = STATE_MOVE;
					}
				} else {
					// TODO : Temps d'attente (son sur mouvement de canon)
					state = STATE_FIRE;
				}
			break;
			case STATE_LOCKED:
				if (current < rangeMin && !allyBack) {
					state = STATE_BACK;
				} else if (current > rangeMax && !allyFront) {
						state = STATE_MOVE;
				} else {
					state = STATE_READY;
				}			
			break;
			case STATE_FIRE:
				if (Time.time > nextFire) {
					state = STATE_READY;
					nextFire = -1;
				} 
			break;
		case STATE_BACK:
				if (current >= distance) {
					state = STATE_READY;
				} else if (allyBack) {
					state = STATE_LOCKED;
				}
			break;
		}

		// Actions
		switch (state) {
			case STATE_MOVE:
				gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
			break;
			case STATE_BACK:
				gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
			break;
			case STATE_FIRE:
				if (nextFire == -1) {
					nextFire = Time.time + fireRate;
					
					// TODO : C'est là qu'on lance le tir
					fireInTheHole = true;
					Debug.Log("aie");
					HealthBarController.barDisplay -= 0.1f;
				} 
			break;
			default:
			break;
		}		
	}
}