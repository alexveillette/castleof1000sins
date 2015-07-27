using UnityEngine;
using System.Collections;

public class GrassPuzzleScript : MonoBehaviour {

	public Transform leftKey;

	void Start () 
	{
		leftKey = GameObject.Find ("leftkey").transform;
		leftKey.gameObject.SetActive (false);
	}
	

}
