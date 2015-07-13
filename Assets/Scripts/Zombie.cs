using UnityEngine;
using System.Collections;

public class Zombie : Enemy {

	private Animator animator;

	void Start () {
	
		damage = 1;
		animator = GetComponent<Animator>();
	}

	void Update () {
		
	}

	void Move(int xDir, int yDir) {


	}


}
