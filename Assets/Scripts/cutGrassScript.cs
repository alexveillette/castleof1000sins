using UnityEngine;
using System.Collections;

public class cutGrassScript : MonoBehaviour {

	/// <summary>
	/// This very small script handles the grass room puzzle.
	/// It simply plays a sound and changes the sprite of the
	/// game object when the player slashes it with his sword.
	/// If enough grass is cut, the key appears.
	/// </summary>

	bool isCut = false;
	private Animator animator;
	public AudioSource grassCutAudio;
	public AudioSource successAudio;
	public Transform leftKey;

	void Start()
	{
		var aSources = GetComponents<AudioSource> ();
		successAudio = aSources [0];
		grassCutAudio = aSources [1];

		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Sword" && !isCut)
		{
			isCut = true;
			grassCutAudio.Play ();
			animator.SetBool("cutGrass", true);
			coll.GetComponentInParent<playerController>().grassCut++;

			if (coll.GetComponentInParent<playerController>().grassCut >= 12)
			{
				successAudio.Play ();
				leftKey.gameObject.SetActive (true);
			}
		}
	}
}
