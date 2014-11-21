using UnityEngine;
using System.Collections;

/* CommandScript - Base Class to represent commands in the game. Usually added to a CommandStack */
public class CommandScript {
	internal GameObject character;		// The Character this stack is attached to (usually an enemy)

	internal GameObject target;			// The Character targeted (usually a player)

	public CommandScript(GameObject _character) {
		this.character = _character;
	}
	
	public virtual void Execute() {
	}		
}
