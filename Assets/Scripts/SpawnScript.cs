using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour 
{

	public GameObject zombiePrefab;
	public GameObject essencePrefab;

	public Enemy enemy;

	void Start () 
	{
		GameObject zombieInstance = GameObject.Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;
		enemy = zombieInstance.GetComponent<Enemy>();
		enemy.IsDying += EnemyDeath;
	}

	private void EnemyDeath(Enemy enemy) 
	{
		enemy.gameObject.SetActive(false);
		essencePrefab = Instantiate(essencePrefab, enemy.transform.position, Quaternion.identity) as GameObject;
		essencePrefab.transform.position = enemy.transform.position;
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
