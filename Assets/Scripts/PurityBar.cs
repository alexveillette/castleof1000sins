using UnityEngine;
using System.Collections;

public class PurityBar : MonoBehaviour 
{

	/// <summary>
	/// Small script which handles the HUD display of the purity bar.
	/// </summary>
	public float purity = 1.0f;
	public bool isMad;
	void Start () 
	{
		isMad = false;
	}
	
	void Update () 
	{
		this.transform.localScale = new Vector3 (purity, transform.localScale.y, transform.localScale.z);
	}
	
	public void AdjustPurity(float change)
	{
		if (change < -1) 
		{
			change = -1;
		}
		else if (change > 1) 
		{
			change = 1;
		}
		
		purity += change;
		
		if (purity <= 0) 
		{
			purity = 0;
			isMad = true;
		} else
		{
			isMad = false;
		}

		if (purity >= 1) 
		{
			purity = 1;
		}
	}
}