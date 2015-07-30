using UnityEngine;
using System.Collections;

public class GetLeftKey : MonoBehaviour 
{
	/// <summary>
	/// Very small script that plays a sound and sets a boolean
	/// within the player when he has acquired the key.
	/// </summary>

	bool keyGotten = false;
	public AudioSource successSound;
	private Renderer rend;

	void Start()
	{
		successSound = GetComponent<AudioSource> ();
		rend = GetComponent<Renderer> ();
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		 if (!keyGotten)
		{
			coll.GetComponent<playerController>().goldKey = true;
			successSound.Play ();
			rend.enabled = false;
			keyGotten = true;

		}
	}
}
