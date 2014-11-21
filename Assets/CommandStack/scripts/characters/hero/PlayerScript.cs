using UnityEngine;
using System.Collections;

/* PlayerScript - Handles Input from Player */
public class PlayerScript : MonoBehaviour {
	
	private MoveScript moveScript;

	// Iniitalize our function (like a constructor)
	void Start () {
		moveScript = GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {		
		/* Player Input */
		// Retrieve axis information from keyboard
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// Calculate movement per-direction and move the player when a key is pressed
		if(moveScript != null) {
			moveScript.Move(inputX, inputY);
		}

	}
}
