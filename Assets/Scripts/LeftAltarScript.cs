using UnityEngine;
using System.Collections;

public class LeftAltarScript : MonoBehaviour 
{
	/// <summary>
	/// A small script that allows the player to put a key on one of the altars
	/// when he has acquired it by enabling the sprite that is there all along.
	/// </summary>

	public Transform armorTop;
	private bool isEnabled;
	private bool leftKeyDropped;
	private Renderer rend;


	void Start()
	{
		rend = GetComponent<Renderer> ();
	}

	void Update()
	{
		if (isEnabled)
		{
			if (Input.GetKeyDown ("space") && !leftKeyDropped && 
			    GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().goldKey == true)
			{
				leftKeyDropped = true;
				rend.enabled = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().completedPuzzles++;
				if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().completedPuzzles >= 2)
				{
					WinGame();
				}
			}
		}

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		isEnabled = true;
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		isEnabled = false;
	}

	void WinGame()
	{
		armorTop.gameObject.SetActive (false);
	}

}
