using UnityEngine;
using System.Collections;

public class cutGrassScript : MonoBehaviour {

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
