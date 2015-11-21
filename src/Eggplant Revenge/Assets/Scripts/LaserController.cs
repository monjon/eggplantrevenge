using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	LineRenderer line;
	private KaijuHeadController head;
	private ArmyWaves waves;


	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = false;
		
		head = GameObject.Find("LaserOrientation").GetComponent<KaijuHeadController>();
		waves = GameObject.Find("Main Camera").GetComponent<ArmyWaves>();
		//  Cursor.visible = false;	//hide the cursor after placing it in the middle of the screen		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
			GameObject cible = CheckCollision();
			if(cible != null){
				//  cible.SetActive(false);
				
				if (cible.GetComponent<uniteIA>().resistance <= 0) {
					GameController.score++;
				}
			}
		}
	}
	
	IEnumerator FireLaser(){
		line.enabled = true;
		while(Input.GetButton("Fire1")){
			//  line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
			GetComponent<ParticleSystem>().Play();
			
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			
			line.SetPosition(0, ray.origin);
			
			//  if(Physics.Raycast(ray, out hit, 100)){
			//  	line.SetPosition(1, hit.point);
			//  	if(hit.rigidbody){
			//  		hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);	// force that hit the target to push it
			//  	}
			//  }else{
			//  	line.SetPosition(1, ray.GetPoint(100));
			//  }
			line.SetPosition(1, ray.GetPoint(100));
			
			
			yield return null;
		}
		
		line.enabled = false;
		GetComponent<ParticleSystem>().Stop();
	}
	
	private GameObject CheckCollision(){
		
		GameObject cible = null;
		
		foreach (GameObject tank in waves.tanks) {
			if(tank != null) {
				for (int i = 0; i < 3; i++) {
					if (tank.GetComponent<Collider>().bounds.Contains(head.points[i])){
						cible = tank;
						break;
					}
				}
			}
		}
		
		if (cible != null) {
			uniteIA unit = cible.GetComponent<uniteIA>();
			unit.resistance--;
			if (unit.resistance <= 0) {
				waves.tanks.Remove(cible);
			}
			return cible;
		}
		
		foreach (GameObject copter in waves.copters) {
			if(copter != null){
				for (int i = 0; i < 3; i++) {
					if (copter.GetComponent<Collider>().bounds.Contains(head.points[i])){
						cible = copter;
						break;
					}
				}
			}
		}
		
		if (cible != null) {
			uniteIA unit = cible.GetComponent<uniteIA>();
			unit.resistance--;
			if (unit.resistance <= 0) {
				waves.copters.Remove(cible);
			}			
			return cible;
		}
		
		foreach (GameObject jeep in waves.jeeps) {
			if(jeep != null){
				for (int i = 0; i < 3; i++) {
					if (jeep.GetComponent<Collider>().bounds.Contains(head.points[i])){
						cible = jeep;
						break;
					}
				}
			}
		}
		
		if (cible != null) {
			waves.jeeps.Remove(cible);
		}
		
		return cible;
	}
}
