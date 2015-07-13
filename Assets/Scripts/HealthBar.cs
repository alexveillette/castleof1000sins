using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float health = 0f;
	public RectTransform rectTransform;

	void Start () {
		rectTransform = GetComponent<RectTransform> ();

	}

	void Update () {
		rectTransform.localScale = new Vector3 (rectTransform.localScale.x, health, rectTransform.localScale.z);
	}

	void AdjustHealth(float change){
		if (change < 0) {
			change = 0;
		}
		else if (change > 1) {
			change = 1;
		}

		health += change;
	}
}
