using UnityEngine;
using System.Collections;

public class Zombie : Enemy 
{

	void Start () 
	{
		SetVariables ();

		damage = 1;
		health = 3.0f;
		speed = 0.2f;
	}

	void FixedUpdate() 
	{

		if (Vector2.Distance(player.transform.position, transform.position) < 2f)
		{
			AggressiveMove ();
		}
	}


}