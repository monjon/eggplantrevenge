using UnityEngine;
using System.Collections;

public class KaijuExplosionController : MonoBehaviour {

	private ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(uniteIA.showDamage){
			//  Debug.Log("show");
			ps.Play();
		}else{
			ps.Stop();
		}
	}
	
	public void PlayExplosion(){
		
	}
}
