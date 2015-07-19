using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public GameObject player;
	public GameObject hud;

	// Use this for initialization
	void Start () {
		player = Instantiate(Resources.Load("Player")) as GameObject;
		player.transform.position = new Vector2 (0, 0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
