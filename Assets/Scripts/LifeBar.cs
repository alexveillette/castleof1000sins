using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour 
{

	public float health;

	void Start () {
		health = 1.0f;
	}

	void Update () {
		this.transform.localScale = new Vector3 (transform.localScale.x, health, transform.localScale.z);
	}

	public void AdjustHealth(float change)
	{
		if (change < -1f) 
		{
			change = -1f;
		}
		else if (change > 1f) 
		{
			change = 1f;
		}

		health += change;

		if (health < 0) {
			health = 0;
		}
		else if (health > 1) 
		{
			health = 1;
		}
	}
}
