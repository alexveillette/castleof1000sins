using UnityEngine;
using System.Collections;

public class GrassPuzzleScript : MonoBehaviour {

	/// <summary>
	/// Once again, a very questionable script, which only sets the
	/// left room key as inactive when the scene is created.
	/// I could have probably done without it.
	/// </summary>
	public Transform leftKey;

	void Start () 
	{
		leftKey = GameObject.Find ("leftkey").transform;
		leftKey.gameObject.SetActive (false);
	}
}
