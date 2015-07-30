using UnityEngine;
using System.Collections;

public class SwitchPuzzleScript : MonoBehaviour 
{
	/// <summary>
	/// This script handles the right room puzzle with the switches.
	/// It checks whether both switch colliders are occupied with 
	/// either the player or the statue's head. When they both are,
	/// it enables the key game object which the player can pick up.
	/// </summary>

	public AudioSource switchAudio;
	public AudioSource successAudio;

	private int switchesPressed;
	private bool puzzleDone;
	private bool keyGotten;

	private Renderer childRend;
	private BoxCollider2D keyBox;

	void Start()
	{
		var aSources = GetComponents<AudioSource> ();
		switchAudio = aSources [0];
		successAudio = aSources [1];

		switchesPressed = 0;
		puzzleDone = false;
		keyGotten = false;

		childRend = GetComponentInChildren<Renderer> ();
		childRend.gameObject.SetActive(false);

		var triggers = GetComponents<BoxCollider2D> ();
		keyBox = triggers [2];
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!puzzleDone)
		{
			switchAudio.Play ();
			switchesPressed++;
		}

		if (switchesPressed >= 2 && !puzzleDone)
		{
			successAudio.Play ();
			puzzleDone = true;
			childRend.gameObject.SetActive(true);
			keyBox.enabled = true;
		}
		else if (puzzleDone && !keyGotten)
		{
			successAudio.Play ();
			childRend.gameObject.SetActive(false);
			keyGotten = true;
			coll.GetComponent<playerController>().silverKey = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		switchesPressed--;
	}
}
