﻿using UnityEngine;
using System.Collections;

public class soundController : MonoBehaviour {
	public AudioClip monsterExplosion;
	public AudioClip monsterWalk1;
	public AudioClip monsterWalk2;
	public AudioClip laser;
	public AudioClip monsterCry1;
	public AudioClip monsterCry2;
	public AudioClip monsterCry3;
	public AudioClip helicoMove;
	public AudioClip helicoExplosion;
	public AudioClip helicoFall;
	public AudioClip helicoFire;
	public AudioClip tankMove;
	public AudioClip tankExplosion;
	public AudioClip tankStop;
	public AudioClip tankReady;
	public AudioClip tankFire;

	private AudioSource sound ;
	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(uniteIA.showDamage){
			sound.volume = 0.8f;
//			Debug.Log("show");
			sound.Play();
			sound.clip = monsterExplosion;


		}else{
//			sound.Stop();
		}
	}
}
