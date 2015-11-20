using UnityEngine;
//  using UnityEditor;
using System.Collections;

public class KaijuHeadController : MonoBehaviour {

	public Vector3[] points;

	private Vector3 rotationVector;

	private Plane[] planes;

	// Use this for initialization
	void Start () {
		//  rotationVector = transform.rotation.eulerAngles;
		//  rotationVector.z = 102.5f;
		//  transform.rotation = Quaternion.Euler(rotationVector);
		
		GameObject kaiju = GameObject.Find("Kaiju");

		planes = new Plane[3];
		planes[0] = new Plane(new Vector3(0f, 0f, 1f), new Vector3(0, 0, kaiju.transform.position.z));
		planes[1] = new Plane(new Vector3(0f, 0f, 1f), new Vector3(0, 0, kaiju.transform.position.z - 2f));
		planes[2] = new Plane(new Vector3(0f, 0f, 1f), new Vector3(0, 0, kaiju.transform.position.z + 2f));

		points = new Vector3[3];
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		for (int i = 0; i < 3; i++) {			
			float enter; 
			planes[i].Raycast(ray, out enter);
			points[i] = ray.GetPoint(enter);
		}
		
		//float dx = point.x - transform.position.x;
		//float dy = point.y - transform.position.y;
				
		Vector3 direction = points[0] - transform.position;
		Vector3 reference = new Vector3(0, 1, 0);
		
		//float length = Mathf.Sqrt(dx * dx + dy * dy); // laser beam length
		float angle = Vector3.Angle(direction, reference);
				
		rotationVector.z = angle;//180f / angle;
		transform.rotation = Quaternion.Euler(rotationVector);

	}
	
}
