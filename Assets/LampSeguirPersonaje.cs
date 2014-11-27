using UnityEngine;
using System.Collections;

public class LampSeguirPersonaje : MonoBehaviour {
	
	public Transform personaje;
	public float separacionx = 0f;
	public float separaciony = -16.84f;
	public float separacionz = 0f;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(personaje.position.x+separacionx, personaje.position.y-separaciony, personaje.position.z+separacionz);
	}
}
