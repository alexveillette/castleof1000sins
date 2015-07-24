using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public GameObject player;	
	public GameObject hud;

	// Use this for initialization
	void Start () {
		player = Instantiate(Resources.Load("Player")) as GameObject;
		hud = Instantiate(Resources.Load("HUD")) as GameObject;

		player.transform.position = new Vector2 (0, 0);
		player.GetComponent<playerController>().lifeBar = hud.transform.FindChild ("BARS").FindChild ("LifeBar").GetComponent<LifeBar> ();
		player.GetComponent<playerController>().energyBar = hud.transform.FindChild ("BARS").FindChild ("EnergyBar").GetComponent<EnergyBar> ();
		player.GetComponent<playerController>().purityBar = hud.transform.FindChild ("BARS").FindChild ("PurityBar").GetComponent<PurityBar> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
