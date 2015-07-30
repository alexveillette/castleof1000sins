using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour 
{
	/// <summary>
	/// This script is used to transition from
	/// one song to another in smooth fashion by referring
	/// to snapshots that were created in the editor.
	/// </summary>


	public AudioMixerSnapshot snapshotTitle;
	public AudioMixerSnapshot snapshotCastle;
	public AudioMixerSnapshot snapshotWin;
	public AudioMixerSnapshot snapshotDeath;

	public AudioMixerSnapshot snapshot;

	void Start () 
	{
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
