using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

	public AudioMixerSnapshot snapshotTitle;
	public AudioMixerSnapshot snapshotCastle;
	public AudioMixerSnapshot snapshotWin;
	public AudioMixerSnapshot snapshotDeath;

	public AudioMixerSnapshot snapshot;

	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);
	}
	

	public void Transition(int music)
	{
		if (music == 1)
		{
			snapshot = snapshotTitle;
			snapshot.TransitionTo (1.5f);
		}

		else if (music == 2)
		{
			snapshot = snapshotCastle;
			snapshot.TransitionTo (1.5f);
		}
		else if (music == 3)
		{
			snapshot = snapshotWin;
			snapshot.TransitionTo (1.5f);
		}
		else if (music == 4)
		{
			snapshot = snapshotDeath;
			snapshot.TransitionTo (1.5f);
		}
	}
}
