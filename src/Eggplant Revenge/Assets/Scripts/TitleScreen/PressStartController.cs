using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressStartController : MonoBehaviour {

	Text flashingText;

	// Use this for initialization
	void Start () {
		//get the Text component
		flashingText = GetComponent<Text>();
		//Call coroutine BlinkText on Start
		StartCoroutine(BlinkText());
	}
	
	//function to blink the text
	public IEnumerator BlinkText(){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
		//set the Text's text to blank
		flashingText.text= "";
		//display blank text for 0.5 seconds
		yield return new WaitForSeconds(.5f);
		//display “I AM FLASHING TEXT” for the next 0.5 seconds
		flashingText.text= "CLICK TO START";
		yield return new WaitForSeconds(.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartGame(){
		//  Debug.Log("Start");
		Application.LoadLevel ("Main"); 
	}

}
