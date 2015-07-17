using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject zombiePrefab;

	// Use this for initialization
	void Start () {
		GameObject zombieInstance = GameObject.Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;
		Zombie zombie = zombieInstance.GetComponent<Zombie>();
		zombie.IsDying += Outch1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void Outch1(Zombie zombie) {
		DestroyObject (zombie.gameObject);
		Debug.Log ("DESTROYED");
	}

}
