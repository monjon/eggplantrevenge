using UnityEngine;
using System.Collections;

public class KaijuHeadController : MonoBehaviour {

	private Vector3 rotationVector;

	// Use this for initialization
	void Start () {
		//  rotationVector = transform.rotation.eulerAngles;
		//  rotationVector.z = 102.5f;
		//  transform.rotation = Quaternion.Euler(rotationVector);
	}
	
	// Update is called once per frame
	void Update () {
		//  if(transform.localEulerAngles.z < 103f){
			rotationVector.z = -Input.mousePosition.y;
			transform.rotation = Quaternion.Euler(rotationVector);
		//  }else{
		//  	rotationVector.z = -102.5f;
		//  }

	}
}
