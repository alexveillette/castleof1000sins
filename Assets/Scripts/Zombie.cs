using UnityEngine;
using System.Collections;

public class Zombie : Enemy 
{
	/// <summary>
	/// This script is a child of the enemy class, so it doesn't contain
	/// a lot of code. Even though its parent is useless because there is only
	/// one enemy, it still serves as a solid basis if more enemies were to be
	/// implemented in the future.
	/// </summary>
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