using UnityEngine;
using System.Collections;

public class LeftAltarScript : MonoBehaviour 
{
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
