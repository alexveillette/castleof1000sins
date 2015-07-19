using UnityEngine; 
using System.Collections;

public class playerController : MonoBehaviour { 
	
	private Animator anim;
	private Rigidbody2D rb;
	private float speed;
	private float playerHealth;
	private bool attacks;
	private bool playerDisabled;
	private bool playerInvincible;
	private Renderer rend;
	private float knockbackForce;
	private Vector2 movement;
	private Vector2 knockback;


	void Start () 
	{ 


		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();
		playerHealth = 10f;
		speed = 1f;
		playerDisabled = false;
		playerInvincible = false;
		knockbackForce = 100f;
	} 

	void FixedUpdate () 
	{ 
		if (!playerDisabled)
		{
			float inputX = Input.GetAxisRaw ("Horizontal");
			float inputY = Input.GetAxisRaw ("Vertical");
			bool moving = (Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0;
			
			anim.SetBool ("moving", moving);
			
			if (moving) 
			{
				anim.SetFloat("x", inputX);
				anim.SetFloat("y", inputY);
			}
			
			movement = new Vector2 (inputX * speed, inputY * speed);
			
			if (Input.GetKeyDown ("space")) 
			{
				anim.SetTrigger("isAttacking");
			}
			
			rb.velocity = movement;
		}
	} 

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (!playerInvincible && !playerDisabled && coll.gameObject.tag == "Enemy")
		{
			AdjustHealth(1);
			playerDisabled = true;
			playerInvincible = true;
			StartCoroutine(PlayerKnockback(coll));
		}
	}

	IEnumerator PlayerKnockback(Collision2D coll)
	{
		knockback = new Vector2 ((coll.transform.position.x - transform.position.x), 
		                        (coll.transform.position.y - transform.position.y)).normalized;
		rend.material.color = new Color32 (255, 255, 255, 100);
		rb.AddForce (-knockback * knockbackForce);

		yield return new WaitForSeconds (0.2f);
		playerDisabled = false;
		yield return new WaitForSeconds (1.0f);
		playerInvincible = false;
		rend.material.color = new Color32 (255, 255, 255, 255);
	
	}

	public void AdjustHealth(int change)
	{
		print ("OMG" + change);
	}
}