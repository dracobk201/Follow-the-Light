using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {
	
	public Transform target;
	public float searchDistance = 100.0f;
	public float interestDistance = 100.0f;
	public float chaseRange = 100.0f;
	public float damping = 5.0f;
	//public bool paralize = false;

	private Vector3 startPosition;  //Give it a startPosition so it knows where it's 'home' location is.
	public bool wandering = false;  //Set a bool or state so it knows if it's wandering or chasing a player
	public bool chasing = false;
	public bool paralized = false;
	private float wanderSpeed = 0.5f;
	
	private NavMeshAgent _navMeshComponent;
	private float distance;
	void Start(){
		_navMeshComponent = GetComponent<NavMeshAgent>();
		_navMeshComponent.updateRotation = false;
		startPosition = this.transform.position;
		//InvokeRepeating("Wander", 1f, 5f);
		//Wander();
	}
	
	void Update(){
		distance = Vector3.Distance( target.position, transform.position);
		// El personaje esta fuera de rango
		if (distance > searchDistance && !paralized){
			if (!wandering){
				wandering = true;
				chasing = false;
				//Wander();
				InvokeRepeating("Wander", 1f, 5f);
			}
		}

		if (distance < interestDistance &&  distance > chaseRange) {

		}
		// Esta en el rango
		if (distance < chaseRange && !paralized){
				chasing = true;
				wandering = false;
				CancelInvoke();
				chase();
		}
	}

	private void search(){
		
		Debug.Log( "search()" );
		
		//animation.CrossFade("LookAround01");
		_navMeshComponent.Stop(true);
	}
	
	private void investigate(){
		
		//Debug.Log( "investigate()" );
		
		_navMeshComponent.Resume();
		_navMeshComponent.SetDestination(target.position);
		//_navMeshComponent.destination = target.position;
		_navMeshComponent.updateRotation = false;
		_navMeshComponent.speed = 3.0f;
		//animation.CrossFade("AngryWalk_AngryWalk");
	}
	
	private void chase(){
		//Debug.Log( "chase()" );
		_navMeshComponent.SetDestination(target.position);
		//_navMeshComponent.updateRotation = false;
		//_navMeshComponent.destination = target.position;
		_navMeshComponent.speed = 80.0f;
	}
	
	//When the enemy is spawned via script or if it's pre-placed in the world we want it to first
	//Get it's location and store it so it knows where it's 'home' is
	//We also want to set it's speed and then start wandering
	
	void Wander(){
		//Pick a random location within wander-range of the start position and send the agent there
		//Debug.Log( "wander()" );
		_navMeshComponent.speed = 50.0f;
		Vector3 destination = startPosition + new Vector3(Random.Range (-100, 100), 
		                                                  0, 
		                                                  Random.Range (-100, 100));
		NewDestination(destination);
	}

	public void NewDestination(Vector3 targetPoint){
		//Sets the agents new target destination to the position passed in
		_navMeshComponent.SetDestination(targetPoint);
	}
	
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "Luz"){
			//elScript = col.GetComponent(nomScript); 
			//Debug.Log(elScript);
			Debug.Log("Hit the lights!");
			StartCoroutine(paralize());
			//elScript.enabled = false;
			//Este es el mas funcional//col.gameObject.GetComponent<nomScript>().enabled = false;
			//activado = false;
		}
		else if (col.gameObject.tag == "Player")
		{
			//Debug.Log("Game Over");
			Application.LoadLevel("GameOver");
		}
	}
	
	//Funcion dada por Issac
	IEnumerator paralize() {
		if(!paralized){
			paralized = true;
			wandering = false;
			chasing = false;
			_navMeshComponent.Stop(true);
			//yield break; 
			yield return new WaitForSeconds(2);
			paralized = false;
		}
	}

}