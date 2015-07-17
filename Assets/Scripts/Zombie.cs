using UnityEngine;
using System.Collections;

public class Zombie : Enemy {

	public float speed;
	public float health = 3.0f;

	public Transform player;
	private Animator animator;
	private Rigidbody2D rb;
	private Renderer renderer;
	
	Vector2 movement;

	private bool isWalkingUp;
	private bool isWalkingDown;
	private bool isWalkingRight;
	private bool isWalkingLeft;

	public delegate void SwordHitDelegate(Zombie zombie);
	public event SwordHitDelegate IsDying;

	void Start () {
	
		damage = 1;
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		renderer = GetComponent<Renderer>();
		player = GameObject.Find ("Player").transform;
	}

	void FixedUpdate() {

		//Calculating angle to face player
		float direction = Mathf.Atan2 ((player.transform.position.y - transform.position.y),
		              (player.transform.position.x - transform.position.x)) 
					  * Mathf.Rad2Deg - 90;

		//Calculating which direction the animation is facing depending on the Euler angles.
		//Funky calculations because the Unity angle numbers are weird.

		//Monster faces UP
		if (direction >= -45 && direction < 45 && isWalkingUp == false) {
			animator.SetTrigger("walkingUp");
			isWalkingUp = true;
			isWalkingDown = false;
			isWalkingLeft = false;
			isWalkingRight = false;
		}
		//Monster faces RIGHT
		else if (direction >= -135 && direction < -45 && isWalkingRight == false) {
			animator.SetTrigger("walkingRight");
			isWalkingUp = false;
			isWalkingDown = false;
			isWalkingLeft = false;
			isWalkingRight = true;
		}
		//Monster faces DOWN
		else if (direction >= -225 && direction < -135 && isWalkingDown == false) {
			animator.SetTrigger("walkingDown");
			isWalkingUp = false;
			isWalkingDown = true;
			isWalkingLeft = false;
			isWalkingRight = false;
		}
		//Monster faces LEFT
		else if (direction <= -225 && direction < 45 && isWalkingLeft == false) {
			animator.SetTrigger("walkingLeft");
			isWalkingUp = false;
			isWalkingDown = false;
			isWalkingLeft = true;
			isWalkingRight = false;
		}


		movement = new Vector2 ((player.transform.position.x - transform.position.x), 
		                                (player.transform.position.y - transform.position.y)).normalized;
		rb.velocity = movement * speed;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Sword") {
			if (IsDying != null) {
				health--;
				Vector2 zombieDir = new Vector2((player.transform.position.x - transform.position.x),
				                               (player.transform.position.y - transform.position.y) );
				float force = -500;
				rb.AddForce(zombieDir.normalized * force);

				if (health <= 0){
					IsDying(this);
				}
			}
		}
	}
}