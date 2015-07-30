using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	/// <summary>
	/// The game class was supposed to be able to manage all
	/// the game's major elements, but I now wonder about its 
	/// real purpose. It creates the player and the HUD, but 
	/// never really does anything with them besides making the player
	/// recognize the HUD's components. It could probably be removed.
	/// </summary>

	public GameObject player;	
	public GameObject hud;
	
	void Awake () 
	{
		player = Instantiate(Resources.Load("Player")) as GameObject;
		hud = Instantiate(Resources.Load("HUD")) as GameObject;

		player.transform.position = new Vector2 (0, 0);
		player.GetComponent<playerController>().lifeBar = hud.transform.FindChild ("BARS").FindChild ("LifeBar").GetComponent<LifeBar> ();
		player.GetComponent<playerController>().energyBar = hud.transform.FindChild ("BARS").FindChild ("EnergyBar").GetComponent<EnergyBar> ();
		player.GetComponent<playerController>().purityBar = hud.transform.FindChild ("BARS").FindChild ("PurityBar").GetComponent<PurityBar> ();
	}
}
