using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {
	
	public float speed = 1f;
	private float valor0 = 0f;
	private float valorIzquierda = -90f;
	private bool bajando = false;
	private bool subiendo = false;
	private bool izquierda = false;
	private bool derecha = false;
	public Animator animator;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		animator.SetBool("bajando", bajando);
		animator.SetBool("subiendo", subiendo);
		animator.SetBool("izquierda", izquierda);
		animator.SetBool("derecha", derecha);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)) {
			transform.Translate(-Vector2.right  * speed * Time.deltaTime);
			izquierda = true;
			//Debug.Log (izquierda);
			LimpiandoVariables("izquierda");
		}
		
		if(Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			derecha = true;
			LimpiandoVariables("derecha");
		}

		if(Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
			subiendo = true;
			LimpiandoVariables("subiendo");
		}

		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(-Vector2.up * speed * Time.deltaTime);
			bajando = true;
			LimpiandoVariables("bajando");
		}

		if(Input.GetKey(KeyCode.LeftShift)) {
			transform.Rotate(transform.rotation.x, transform.rotation.y, -90);
		}
	}

	void LimpiandoVariables (string var) {
		if(var == "bajando"){
			subiendo = false;
			izquierda = false;
			derecha = false;
		}
		else if (var == "subiendo"){
			bajando = false;
			izquierda = false;
			derecha = false;
		}
		else if (var == "izquierda"){
			bajando = false;
			subiendo = false;
			derecha = false;
		}
		else if (var == "derecha"){
			bajando = false;
			subiendo = false;
			izquierda = false;
		}
	}
}
