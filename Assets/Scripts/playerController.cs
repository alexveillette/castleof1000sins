using UnityEngine; 
using System.Collections;

public class playerController : MonoBehaviour { 
	
	private Animator anim;
	private Rigidbody2D rb;
	private float speed;
	private bool attacks;
	private bool playerDisabled;
	private bool playerInvincible;
	private Renderer rend;
	private float knockbackForce;
	private Vector2 movement;
	private Vector2 knockback;
	
	public LifeBar lifeBar;
	public EnergyBar energyBar;
	public PurityBar purityBar;

	private bool purityEnabled;
	private bool isWhirlwind;

	private void Start () 
	{ 
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();

		speed = 1f;
		playerDisabled = false;
		playerInvincible = false;
		knockbackForce = 100f;

		purityEnabled = true;
		isWhirlwind = false;

	} 

	void FixedUpdate () 
	{ 
		PlayerInput ();
		PurityManagement ();
		EnergyManagement ();
	} 

	void OnCollisionEnter2D(Collision2D coll)
	{
		//ENEMY COLLISION
		if (!playerInvincible && !playerDisabled && coll.gameObject.tag == "Enemy") {
			playerDisabled = true;
			playerInvincible = true;
			AdjustHealth (-0.08f);
			StartCoroutine (PlayerKnockback (coll));
		} 
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Essence") 
		{
			purityBar.AdjustPurity (0.1f);
			ScoreManager.score += 1;
			coll.gameObject.SetActive(false);
		}
	}

	private IEnumerator PlayerKnockback(Collision2D coll)
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

	private void PlayerInput()
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

			if (Input.GetKeyDown("z") && !isWhirlwind)
			{
				isWhirlwind = true;
				anim.SetTrigger ("whirlwind");
				anim.SetBool ("whirlwindAnim", true);
			}

			if (Input.GetKeyUp("z") && isWhirlwind)
			{
				isWhirlwind = false;
				anim.SetBool ("whirlwindAnim", false);
			}
		}
	}

	private void PurityManagement()
	{
		if (purityEnabled) 
		{
			purityBar.AdjustPurity(-0.03f * Time.deltaTime);
		}
	}

	private void AdjustHealth(float change)
	{

		lifeBar.AdjustHealth(change);

	}

	private void EnergyManagement()
	{
		if (isWhirlwind) 
		{
			energyBar.AdjustEnergy (-0.25f * Time.deltaTime);
		} 
		else 
		{
			energyBar.AdjustEnergy (0.05f * Time.deltaTime);
		}

		if (energyBar.GetEnergy <= 0) 
		{
			isWhirlwind = false;
			anim.SetBool ("whirlwindAnim", false);
		}
	}
}