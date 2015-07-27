using UnityEngine;
using System.Collections;

public class LayerOrder : MonoBehaviour {

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
