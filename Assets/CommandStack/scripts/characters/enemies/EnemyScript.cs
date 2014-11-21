using UnityEngine;
using UnityEditor;
using System.Collections;

/* EnemyScript - Controls an enemy character */
public class EnemyScript : MonoBehaviour {

	[Tooltip("How close does a player have to be to aggro this enemy")]
	public float aggroRadius = 1.5f;

	// Player - Search for and store the player so we can chase it
	private GameObject player;
	private float playerDistance;

	// AI Scripts - Used to execute character behavior
	private CommandStackScript commands;
	
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");	// Make sure your player has the 'Player' tag!
		// Create stack of commands for AI behavior
		commands = new CommandStackScript();
	}
	
	void Update() {
		playerDistance = GetDistance(player);	// How far away is the enemy from the player?

		if (playerDistance <= aggroRadius) {
			// When player comes close, chase him/her
			Chase();
		}
		else {
			// Otherwise just wander around
			Wander();
		}

		commands.Execute();
	}

	/* Chase - Pushes a 'Chase' command onto the stack */
	private void Chase() {
		ChaseCommandScript command = new ChaseCommandScript(this.gameObject);	// Temporary command - move to a random spot
		command.target = player;		// Grab and target player
		commands.Add(command);			// Command will be executed next frame
	}

	/* Wander - Pushes a 'Wander' command onto the stack */
	private void Wander() {
		WanderCommandScript command = new WanderCommandScript(this.gameObject);
		commands.Add(command);
	}

	private float GetDistance(GameObject target) {
		return(Vector2.Distance(this.gameObject.transform.position, target.transform.position));
	}
		
	/* OnDrawGizmos - Used to draw debugging info on the scene */
	public void OnDrawGizmos() {
		Gizmos.color = Color.red;	
		Handles.Label (transform.position, commands.currentCommand.ToString());
	}
}
