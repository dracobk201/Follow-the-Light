using UnityEngine;
using System.Collections;

public class ControladorColisiones : MonoBehaviour {

	private string nomScript = "Chaser";
	private Component elScript;
	private bool activado = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(activado == false) {
			//Chaser.enabled
		}
	}
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "Luz"){
			//elScript = col.GetComponent(nomScript); 
			//Debug.Log(elScript);
			//elScript.enabled = false;
			//Este es el mas funcional//col.gameObject.GetComponent<nomScript>().enabled = false;
			activado = false;
		}
		else
		{
			activado = true;
		}
	}

}
