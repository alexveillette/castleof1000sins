using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	public MusicController musicController;

	void OnTriggerEnter2D(Collider2D coll)
	{
		musicController = GameObject.Find ("MusicController").GetComponent<MusicController> ();
		musicController.Transition (3);
		Application.LoadLevel ("winScreen");
	}
}
