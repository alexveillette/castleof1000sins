using UnityEngine;
using System.Collections;

public class WarpScript : MonoBehaviour 
{
	/// <summary>
	/// This script is triggered each time the player walks through a door.
	/// It warps the player to the other room, makes the fog disappear and
	/// deactivates the purity boolean on the player to give the player
	/// some time to solve the puzzle without dealing with the purity mechanic.
	/// </summary>
	playerController player;
	private GameObject smoke;
	private Renderer smokeRenderer;

	void OnTriggerEnter2D(Collider2D coll)
	{

		player = GameObject.Find ("Player(Clone)").GetComponent<playerController> ();
		if (player.purityEnabled) 
		{
			LeavesFog ();
		} 
		else if (!player.purityEnabled)
		{
			EntersFog();
		}
		coll.gameObject.transform.position = transform.parent.position;
	}

	void LeavesFog()
	{
		smoke = GameObject.Find ("Smoke");
		smokeRenderer = smoke.GetComponent<Renderer> ();
		smokeRenderer.enabled = false;
		player.purityEnabled = false;

	}

	void EntersFog()
	{
		smoke = GameObject.Find ("Smoke");
		smokeRenderer = smoke.GetComponent<Renderer> ();
		smokeRenderer.enabled = true;
		player.purityEnabled = true;
		
	}
}
