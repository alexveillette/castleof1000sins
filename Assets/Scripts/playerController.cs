using UnityEngine; 
using System.Collections;

public class playerController : MonoBehaviour { 
	
	private Animator anim;
	private Rigidbody2D rb;
	private float speed = 1.0f;
	private bool attacks;

	void Start () { 

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	} 

	void Update() {

	}
	void FixedUpdate () { 

		float inputX = Input.GetAxisRaw ("Horizontal");
		float inputY = Input.GetAxisRaw ("Vertical");
		bool moving = (Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0;

		anim.SetBool ("moving", moving);

		if (moving) {
			anim.SetFloat("x", inputX);
			anim.SetFloat("y", inputY);
		}

		Vector3 movement = new Vector3 (inputX * speed, inputY * speed, 0);

		if (Input.GetKeyDown ("space")) {
			anim.SetTrigger("isAttacking");
			movement = new Vector3 (0, 0, 0);
		}


		rb.velocity = movement;
	} 
}