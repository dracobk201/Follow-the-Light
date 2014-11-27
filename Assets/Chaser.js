#pragma strict

public var victim : Transform;
private var navComponent : NavMeshAgent;

function Start () {
	
	navComponent = this.transform.GetComponent(NavMeshAgent);
}

function Update () {

	if(victim) {
		navComponent.SetDestination(victim.position);
		navComponent.updateRotation = false; 
	}
}