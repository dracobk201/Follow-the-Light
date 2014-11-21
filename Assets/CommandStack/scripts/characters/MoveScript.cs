using UnityEngine;
using System.Collections;

/* MoveScript - Moves the current game object */
public class MoveScript : MonoBehaviour {

	[Tooltip("Controls the character's run speed")]
	[Range(1.0f, 500.0f)]
	public float speed = 400f;

	// Direction of object
	internal Vector2 direction = new Vector2(0, 0);
	internal Vector2 facing = new Vector2(0, 0);

	// Actual movement
	internal Vector2 movement = new Vector2(0, 0);
	private bool isMoving = false;

	// Animate our character
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	
	}

	void Update() {
		movement = direction * speed;	// Calculate movement amount
	
		/* Handle animation */
		if(animator){
			/* Check if character is moving */
			if(rigidbody2D.velocity.normalized.x != 0 || rigidbody2D.velocity.normalized.y != 0) {
				// Store the direction the player is facing in case they stop moving
				facing = rigidbody2D.velocity.normalized;
				isMoving = true;
			}
			else {
				isMoving = false;
			}

			/* Set direction character is facing */
			animator.SetFloat ("facing_x", facing.x);
			animator.SetFloat ("facing_y", facing.y);

			/* Play walking animation */
			animator.SetBool("isMoving", isMoving);
		}
		
		
	}


	void FixedUpdate() {
		// Apply the movement to the rigidbody
		rigidbody2D.AddForce (movement);
	}

	/* Moves the object in a direction by a small amount (used for player input)
		 	float input_X: Input for X-axis movement (b/t -1 and 1)
		 	float input_Y: Input for Y-axis movement (b/t -1 and 1)
		 */
	internal void Move(float input_X, float input_Y) {
		direction = new Vector2(input_X, input_Y);
	}

	/* Moves the object towards a destination by a small amount (used for enemy input)
		 * Vector2 _direction: Direction to the destination
		 */
	internal void Move(Vector2 _direction) {
		direction = _direction;
	}

	/* Push - pushes a character in a direction by an amount
		 * Vector2 direction - The direction to push
		 * float amount - The amount the character should be pushed
		 */
	internal void Push(Vector2 direction, float amount) {
		rigidbody2D.AddForce(direction * amount);
	}
}
