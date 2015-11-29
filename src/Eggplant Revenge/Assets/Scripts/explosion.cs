using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	private AudioSource sound ;
	private soundController soundList;
	// Use this for initialization
	void Start () {
	
		soundList = GetComponent<soundController>();
		sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	if(uniteIA.showDamage){
			//  Debug.Log("show");
			sound.Play();
			sound.clip = soundList.monsterExplosion;
			sound.volume = 0.1f;

		}
	}
}
