using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	public float energy = 1.0f;
	
	void Start () {
		
	}
	
	void Update () {
		this.transform.localScale = new Vector3 (transform.localScale.x, energy, transform.localScale.z);
	}
	
	void AdjustEnergy(float change){
		if (change < 0) {
			change = 0;
		}
		else if (change > 1) {
			change = 1;
		}
		
		energy += change;
		
		if (energy < 0) {
			energy = 0;
		}
		else if (energy > 1) {
			energy = 1;
		}
	}
}