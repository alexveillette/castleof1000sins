using UnityEngine;
using System.Collections;

public class LayerOrder : MonoBehaviour {
	/// <summary>
	/// This script is only used for esthetic purposes, but it is rather important.
	/// It keeps looking at the player's position relative to the other game objects
	/// in the scene. If its Y position is lower, it sets the player's Z order to a lower
	/// value so it will be overlapped by enemies and objects, and vice versa.
	/// </summary>

	private Renderer rend;


	void Start () {
		rend = GetComponent<Renderer>();

	}
	

	void FixedUpdate () {
		if (transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
		{
			rend.sortingOrder = 3;
		}
		else
		{
			rend.sortingOrder = 1;
		}
	}
}
