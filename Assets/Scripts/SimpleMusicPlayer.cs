using UnityEngine;
using System.Collections;

public class SimpleMusicPlayer : MonoBehaviour {

	public AudioClip[] clips;

	private AudioSource _audSrc;
	// Use this for initialization
	void Start () 
	{
		_audSrc = GetComponent<AudioSource>();
		PlaySound("SoundtrackRough");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void PlaySound( string name )
	{
		foreach(AudioClip clip in clips)
		{
			if(clip.name == name)
			{
				_audSrc.clip = clip;
				_audSrc.Play();
			}
		}
	}
}
