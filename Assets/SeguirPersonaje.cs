using UnityEngine;
using System.Collections;

public class SeguirPersonaje : MonoBehaviour {

	public Transform personaje;
	public float separacion = 0f;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(personaje.position.x+separacion, transform.position.y+separacion, personaje.position.z+separacion);
	}
}
