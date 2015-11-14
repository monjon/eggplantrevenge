using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject KaijuObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			//  Debug.Log("toto");
			
			Vector3 position = KaijuObject.transform.position;
			position.x--;
			KaijuObject.transform.position = position;
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
				Vector3 position = KaijuObject.transform.position;
				position.x++;
				KaijuObject.transform.position = position;
		}
	}
}
