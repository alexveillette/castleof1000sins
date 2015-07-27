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
	private AudioSource aus1;
	private AudioSource aus2;
	private AudioSource aus3;
	private AudioSource aus4;
	
	public LifeBar lifeBar;
	public EnergyBar energyBar;
	public PurityBar purityBar;

	private bool purityEnabled;
	private bool isWhirlwind;

	private int nextLevel;
	public int strength;

	public bool silverKey;
	public bool goldKey;

	public int grassCut;
	public int completedPuzzles;

	public ChangeScene changeScene;

	private void Start () 
	{ 
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();

		var aSources = GetComponents<AudioSource> ();
		aus1 = aSources [0];
		aus2 = aSources [1];
		aus3 = aSources [2];
		aus4 = aSources [3];

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

		DialogueScript.dialogue = "What has happened here? And what is this horrendous fog? No matter, I must look for the king.";
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
			if (lifeBar.health <= 0)
			{
				GameOver();
			}
			StartCoroutine (PlayerKnockback (coll));
			aus2.Play ();
		} 
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
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
		if (purityEnabled) 
		{
			purityBar.AdjustPurity(-0.025f * Time.deltaTime);
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

	private void LevelUp()
	{
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