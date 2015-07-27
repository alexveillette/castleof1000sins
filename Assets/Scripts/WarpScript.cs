using UnityEngine;
using System.Collections;

public class WarpScript : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D coll)
	{
		coll.gameObject.transform.position = transform.parent.position;
	}
}
