﻿using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour 
{
	/// <summary>
	/// This script handles the HUD display of the energy bar.
	/// </summary>
	public float energy = 1.0f;

	public float GetEnergy 
	{
		get { return energy; }

	}

	void Update () 
	{
		this.transform.localScale = new Vector3 (transform.localScale.x, energy, transform.localScale.z);
	}
	
	public void AdjustEnergy(float change)
	{
		if (change < -1) 
		{
			change = -1;
		}
		else if (change > 1) 
		{
			change = 1;
		}
		
		energy += change;
		
		if (energy < 0) 
		{
			energy = 0;
		}
		else if (energy > 1) 
		{
			energy = 1;
		}
	}
}