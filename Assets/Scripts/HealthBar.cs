using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float health = 1.0f;

	void Start () {

	}

	void Update () {
		this.transform.localScale = new Vector3 (transform.localScale.x, health, transform.localScale.z);
	}

	void AdjustHealth(float change){
		if (change < 0) {
			change = 0;
		}
		else if (change > 1) {
			change = 1;
		}

		health += change;

		if (health < 0) {
			health = 0;
		}
		else if (health > 1) {
			health = 1;
		}
	}
}
