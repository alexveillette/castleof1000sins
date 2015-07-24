using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	protected float speed;
	protected int damage;
	public float health;
	protected Transform target;
	protected bool knockedBack;
	private float knockbackForce;

	public Transform player;
	protected Animator animator;
	protected Rigidbody2D rb;
	protected Renderer rend;
	
	Vector2 movement;
	
	protected bool isWalkingUp;
	protected bool isWalkingDown;
	protected bool isWalkingRight;
	protected bool isWalkingLeft;
	
	public delegate void SwordHitDelegate(Enemy enemy);
	public event SwordHitDelegate IsDying;

	//START
	protected void SetVariables()
	{
		player = GameObject.Find ("Player(Clone)").transform;
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer>();
		knockedBack = false;
		knockbackForce = 100f;
	}


	protected void AggressiveMove() 
	{
		if (!knockedBack)
		{
			//Calculating angle to face player
			float direction = Mathf.Atan2 ((player.transform.position.y - transform.position.y),
			                               (player.transform.position.x - transform.position.x)) 
				* Mathf.Rad2Deg - 90;
			
			//Calculating which direction the animation is facing depending on the Euler angles.
			//Funky calculations because the Unity angle numbers are weird.
			
			//Monster faces UP
			if (direction >= -45 && direction < 45 && isWalkingUp == false) 
			{
				animator.SetTrigger("walkingUp");
				isWalkingUp = true;
				isWalkingDown = false;
				isWalkingLeft = false;
				isWalkingRight = false;
			}
			//Monster faces RIGHT
			else if (direction >= -135 && direction < -45 && isWalkingRight == false) 
			{
				animator.SetTrigger("walkingRight");
				isWalkingUp = false;
				isWalkingDown = false;
				isWalkingLeft = false;
				isWalkingRight = true;
			}
			//Monster faces DOWN
			else if (direction >= -225 && direction < -135 && isWalkingDown == false) 
			{
				animator.SetTrigger("walkingDown");
				isWalkingUp = false;
				isWalkingDown = true;
				isWalkingLeft = false;
				isWalkingRight = false;
			}
			//Monster faces LEFT
			else if (direction <= -225 && direction < 45 && isWalkingLeft == false) 
			{
				animator.SetTrigger("walkingLeft");
				isWalkingUp = false;
				isWalkingDown = false;
				isWalkingLeft = true;
				isWalkingRight = false;
			}
			
			//Enemy moves by a normalized vector in the specified direction.
			movement = new Vector2 ((player.transform.position.x - transform.position.x), 
			                        (player.transform.position.y - transform.position.y)).normalized;
			rb.velocity = movement * speed;
		}

	}
	//Enemy is hit by sword.
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Sword" && !knockedBack) 
		{
			if (IsDying != null) 
			{

				//Reduces health and sets knockedback boolean to true to prevent multiple hits.
				health--;
				knockedBack = true;

				//Starts knockback Coroutine for enemy.
				StartCoroutine(EnemyKnockback());

				//Sends delegate to spawner that enemy has died if health reaches 0.
				if (health <= 0){
					StartCoroutine(EnemyDeath());
					animator.SetTrigger("deathTrigger");
				}
			}
		}
	}

	IEnumerator EnemyKnockback()
	{
		//Sets transparent color and adds force to rigidbody.
		rend.material.color = new Color32 (255, 255, 255, 100);
		rb.AddForce (-movement * knockbackForce);

		//Knockback lasts 0.2 seconds.
		yield return new WaitForSeconds (0.2f);

		//When timer is up, set knockedBack boolean back to false and reset enemy color.
		knockedBack = false;
		rend.material.color = new Color32 (255, 255, 255, 255);
	}

	IEnumerator EnemyDeath()
	{
		yield return new WaitForSeconds(0.4f);
		IsDying(this);
	}
}
