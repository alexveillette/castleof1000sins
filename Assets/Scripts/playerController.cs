using UnityEngine; 
using System.Collections;

public class playerController : MonoBehaviour { 
	/// <summary>
	/// The playerController class handles all the game elements
	/// that have to do with the player. It handles input, manages 
	/// variables such as health, energy and purity, and also handles
	/// attacks as well as collisions with the enemy. It has a lot of
	/// responsibilities but is far from being a God class.
	/// </summary>

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
	private AudioSource aus1;
	private AudioSource aus2;
	private AudioSource aus3;
	private AudioSource aus4;
	
	public LifeBar lifeBar;
	public EnergyBar energyBar;
	public PurityBar purityBar;

	public bool purityEnabled;
	private bool isWhirlwind;

	private int nextLevel;
	public int strength;

	public bool silverKey;
	public bool goldKey;

	public int grassCut;
	public int completedPuzzles;

	public ChangeScene changeScene;
	public Localizater localizater;

	private void Start () 
	{ 
		//Initialize components.
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();
		localizater = GameObject.Find ("LanguageManager").GetComponent<Localizater>();

		//Initialize audio.
		var aSources = GetComponents<AudioSource> ();
		aus1 = aSources [0];
		aus2 = aSources [1];
		aus3 = aSources [2];
		aus4 = aSources [3];

		//Setting player variables.
		speed = 1f;
		playerDisabled = false;
		playerInvincible = false;
		knockbackForce = 100f;

		purityEnabled = true;
		isWhirlwind = false;

		nextLevel = 20;
		strength = 1;

		silverKey = false;
		goldKey = false;
		grassCut = 0;
		completedPuzzles = 0;

		//First dialogue of the game.
		DialogueScript.dialogue = localizater.IDToWord ("FIRST");


		//***Preprocessors if using debug mode. Allows to one-shot enemies and skip both puzzles.

		#if DEBUG
		silverKey = true;
		goldKey = true;
		strength = 10;
		#endif
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

			//Calls for game over if player health reaches 0.
			if (lifeBar.health <= 0)
			{
				GameOver();
			}
			//Calls Coroutine for knockback.
			StartCoroutine (PlayerKnockback (coll));
			aus2.Play ();
		} 
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//This function manages the powerup pickup.
		if (coll.gameObject.tag == "Essence") 
		{
			purityBar.AdjustPurity (0.1f);
			ScoreManager.score++;

			if (ScoreManager.score >= nextLevel)
			{
				LevelUp();
			}
			coll.gameObject.SetActive(false);
			aus1.Play ();
		}
	}

	private IEnumerator PlayerKnockback(Collision2D coll)
	{
		//Player knockback Coroutine.
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
		//Player movement.
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

			//Handling special attack.
			if (Input.GetKeyDown("c") && !isWhirlwind)
			{
				isWhirlwind = true;
				anim.SetTrigger ("whirlwind");
				anim.SetBool ("whirlwindAnim", true);
				aus3.Play ();
			}

			if (Input.GetKeyUp("c") && isWhirlwind)
			{
				isWhirlwind = false;
				anim.SetBool ("whirlwindAnim", false);
			}
		}
	}

	private void PurityManagement()
	{
		//Handles the purity mechanic. Player turns purple when mad.
		//Player CANNOT die from madness.
		if (purityEnabled) 
		{
			purityBar.AdjustPurity(-0.02f * Time.deltaTime);
			if (purityBar.isMad)
			{
				AdjustHealth(-0.01f * Time.deltaTime);
				rend.material.color = new Color32(214, 164, 255, 255);
			}
			else if (!purityBar.isMad && !playerDisabled)
			{
				rend.material.color = new Color32(255, 255, 255, 255);
			}
		}
	}

	private void AdjustHealth(float change)
	{
		lifeBar.AdjustHealth(change);
	}

	private void EnergyManagement()
	{
		//Manages energy for special attack purposes.
		//Whirlwind is stopped when player reaches 0 energy.
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

	private void LevelUp()
	{
		//Level up mechanic.
		ScoreManager.levelNumber += 40;
		nextLevel += 40;
		strength++;
		AdjustHealth (1.0f);
		energyBar.AdjustEnergy (1.0f);
		purityBar.AdjustPurity (1.0f);
		anim.SetTrigger ("levelUp");
		aus4.Play ();
	}

	private void GameOver()
	{
		changeScene = GameObject.Find ("SceneManager").GetComponent<ChangeScene> ();
		changeScene.SwitchScene ("gameOverScreen");
	}
}