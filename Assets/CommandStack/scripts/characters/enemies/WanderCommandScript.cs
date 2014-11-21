using UnityEngine;
using System.Collections;

/* WanderCommand - Wanders about aimlessly */
public class WanderCommandScript : CommandScript {
	
	private MoveScript moveScript;

	private Vector2 destination;
	
	/* WanderCommandScript - Constructur called when Command is first created 
	 _character - the Character that the Command Stack is attached to */
	public WanderCommandScript(GameObject _character) : base(_character) {
		moveScript = character.GetComponent<MoveScript>();
	}
	
	/* Execute is usually called once per frame */
	public override void Execute () {
		destination = GetRandomDestination();
		moveScript.Move(destination);
	}
	
	private Vector2 GetRandomDestination() {
		return(Random.insideUnitCircle*5);	// Only wander within a small circular radius
	}	
}