using UnityEngine;
using System.Collections;

public class PurityBar : MonoBehaviour {
	
	public float purity = 1.0f;
	
	void Start () {
		
	}
	
	void Update () {
		this.transform.localScale = new Vector3 (purity, transform.localScale.y, transform.localScale.z);
	}
	
	void AdjustEnergy(float change){
		if (change < 0) {
			change = 0;
		}
		else if (change > 1) {
			change = 1;
		}
		
		purity += change;
		
		if (purity < 0) {
			purity = 0;
		}
		else if (purity > 1) {
			purity = 1;
		}
	}
}