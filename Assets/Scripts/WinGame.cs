using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour 
{
	/// <summary>
	/// This script is called when the player walks through
	/// the top door to win the game.
	/// </summary>

	public MusicController musicController;

	void OnTriggerEnter2D(Collider2D coll)
	{
		musicController = GameObject.Find ("MusicController").GetComponent<MusicController> ();
		musicController.Transition (3);
		Application.LoadLevel ("winScreen");
	}
}
