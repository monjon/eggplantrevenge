using UnityEngine;
using System.Collections;

public class uniteIA : MonoBehaviour {
	
	public float speed;
	public float fireRate;
	public float rangeMin;
	public float rangeMax;
	public Transform kaiju;
	public Transform frontCheck;
	public Transform backCheck;
	public bool fireInTheHole;

	private float nextFire;
	private float positionKaiju;
	private int agressivity;
	private int state;
	private float distance;
	private bool allyFront;
	private bool allyBack;
	private bool ready;

	// Use this for initialization
	void Start () {
		state = 0;
		speed = 2f;
		agressivity = Random.Range (0, 2);
		rangeMax = 5;
		nextFire = 0;
		fireRate = 5f;
		distance = ((rangeMax - rangeMin) * (1 - agressivity) + rangeMin); 
		switch (agressivity) {
		case 0:
			rangeMin = 3;
			break;
		case 1:
			rangeMin = 5;
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log(((rangeMax-rangeMin)*(1-agressivity)+rangeMin));
		Debug.Log (rangeMax + "/" + rangeMin);
		switch (state) {

		case 0: /*etat move*/

			Debug.Log("move");
			if(transform.position.x == kaiju.position.x-distance){
				state = 1;

			}
			else if (allyFront){
				state = 2;

			}Debug.Log("aaa = "+ state);
			gameObject.transform.position += Vector3.right * speed *Time.deltaTime;
			break;
		case 1: /*etat ready*/
			Debug.Log("ready");

			ready = true;

			 if(transform.position.x >= kaiju.position.x-rangeMin){
				state = 4;
			}
			else if (transform.position.x <= kaiju.position.x - rangeMax){
				if(allyFront){
					state = 2;
				}
				else {
					state = 0;
				}
			}Debug.Log("xxx = "+state);
			break;
		case 2: /* etat locked */
			Debug.Log("locked");
			if(transform.position.x <= rangeMin && transform.position.x >= kaiju.position.x - rangeMax){
				state = 1;
			}
			else if (!allyFront){
				state = 0;
			}
			else if (!allyBack){
				state = 4;
			}
			break;
		case 3: /* etat fire */
			Debug.Log("fire");
			fireInTheHole = true;
			state = 1;
			ready = false;
			nextFire = fireRate + Time.time;
			break;
		case 4: /* etat back */
			gameObject.transform.position += Vector3.left * speed *Time.deltaTime;
			if(transform.position.x == kaiju.position.x - distance){
				state = 1;
			}
			else if (allyBack){
				state = 2;
			}
			break;
		}



	}
	void FixedUpdate(){

		allyFront = Physics.Raycast (transform.position, frontCheck.transform.position, 1 << LayerMask.NameToLayer ("Allie"));
		allyBack = Physics.Raycast (transform.position, backCheck.transform.position, 1 << LayerMask.NameToLayer ("Allie"));

		if (ready == true) {
			/*if(Time.time > nextFire){*/
				state = 3;

				
			//}
		}

	}
}
