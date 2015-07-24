using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour 
{

	public GameObject zombiePrefab;
	public GameObject essencePrefab;

	public Enemy enemy;
	public GameObject essence;

	void Start () 
	{
		//Spawning enemy
		GameObject zombieInstance = GameObject.Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;
		enemy = zombieInstance.GetComponent<Enemy>();

		//Spawning collectable and making it inactive
		essence = GameObject.Instantiate(essencePrefab, enemy.transform.position, Quaternion.identity) as GameObject;
		essence.SetActive (false);
		enemy.IsDying += EnemyDeath;
	}

	private void EnemyDeath(Enemy enemy) 
	{
		essence.transform.position = enemy.transform.position;
		enemy.gameObject.SetActive(false);
		essence.SetActive (true);
		StartCoroutine (Respawn ());

	}

	private IEnumerator Respawn()
	{
		yield return new WaitForSeconds(30f);

		enemy.transform.position = transform.position;
		enemy.health = 3f;
		enemy.gameObject.SetActive(true);
	}

}
