using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject zombiePrefab;

	void Start () {
		GameObject zombieInstance = GameObject.Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;
		Enemy enemy = zombieInstance.GetComponent<Enemy>();
		enemy.IsDying += Outch1;

	}

	private void Outch1(Enemy enemy) {
		DestroyObject (enemy.gameObject);
		Debug.Log ("DESTROYED");
	}

}
