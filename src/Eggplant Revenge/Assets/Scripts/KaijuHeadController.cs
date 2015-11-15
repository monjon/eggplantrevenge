using UnityEngine;
//  using UnityEditor;
using System.Collections;

public class KaijuHeadController : MonoBehaviour {

	private Vector3 rotationVector;
	public Vector3 point;

	// Use this for initialization
	void Start () {
		//  rotationVector = transform.rotation.eulerAngles;
		//  rotationVector.z = 102.5f;
		//  transform.rotation = Quaternion.Euler(rotationVector);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);		
		Plane xy = new Plane(new Vector3(0f, 0f, 1f), transform.position);
		
		float enter; 
		xy.Raycast(ray, out enter);
		point = ray.GetPoint(enter);
		
		float dx = point.x - transform.position.x;
		float dy = point.y - transform.position.y;
				
		Vector3 direction = point - transform.position;
		Vector3 reference = new Vector3(0, 1, 0);
		
		float length = Mathf.Sqrt(dx * dx + dy * dy); // laser beam length
		float angle = Vector3.Angle(direction, reference);
				
		rotationVector.z = angle;//180f / angle;
		transform.rotation = Quaternion.Euler(rotationVector);

	}
	
}
