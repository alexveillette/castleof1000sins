using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour 
{
	/// <summary>
	/// This script handles each spawner on the map. When the map is loaded,
	/// it spawns an enemy. When the enemy dies, it receives the death delegate
	/// and uses a Coroutine to spawn a new enemy after 30 seconds, allowing 
	/// the player to kill enemies infinitely.
	/// </summary>
	public GameObject zombiePrefab;
	public GameObject essencePrefab;

	private Enemy enemy;
	private GameObject essence;
	

	void Start () 
	{
		//Spawning enemy
		GameObject zombieInstance = GameObject.Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;
		enemy = zombieInstance.GetComponent<Enemy>();

		//Spawning collectable and making it inactive
		essence = GameObject.Instantiate(essencePrefab, enemy.transform.position, Quaternion.identity) as GameObject;
		essence.SetActive (false);

		//SET DELEGATE
		enemy.IsDying += EnemyDeath;
	}

	private void EnemyDeath(Enemy enemy) 
	{
		//Receives delegate.
		//Spawns essence and starts respawn timer.
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
		enemy.knockedBack = false;
		enemy.GetComponent<Renderer>().material.color = new Color32 (255, 255, 255, 255);
	}

}
