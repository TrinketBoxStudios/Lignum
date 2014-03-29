using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class SoundOnClick : MonoBehaviour {

	public AudioClip _soundToPlay;

	private AudioSource _audSrc;
	// Use this for initialization
	void Start () 
	{
		_audSrc = GetComponent<AudioSource>();
	}

	void OnMouseDown()
	{
		_audSrc.PlayOneShot(_soundToPlay);
	}
}
