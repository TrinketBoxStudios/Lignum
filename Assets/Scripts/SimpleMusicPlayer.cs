using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class SimpleMusicPlayer : MonoBehaviour {

	public AudioClip[] clips;

	public static string CHILD_TRACK_NAME = "ChildTheme";
	public static string ADULT_TRACK_NAME = "AdultTheme";
	public static string ELDER_TRACK_NAME = "ElderTheme";
	public static string CREDITS_TRACK_NAME = "End_Credits";

	private AudioSource _audSrc;
	// Use this for initialization
	void Start () 
	{
		_audSrc = GetComponent<AudioSource>();
		PlaySoundByName(CHILD_TRACK_NAME);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("a"))
		{
			PlaySoundByName(CHILD_TRACK_NAME, true);
		}
		else if(Input.GetKeyDown("b"))
		{
			PlaySoundByName(ADULT_TRACK_NAME, true);
		}
	}

	public void StopSounds()
	{
		_audSrc.Stop();
	}

	public void PlaySoundByName( string name, bool fadeIn = false )
	{
		foreach(AudioClip clip in clips)
		{
			if(clip.name == name)
			{
				if(fadeIn == false)
				{
					PlaySound(clip);
				}
				else
				{
					FadeInClip(clip);
				}
			}
		}
	}

	void SwitchSounds( TweenEvent tEvent )
	{
		PlaySound((AudioClip)tEvent.parms[0]);
	}

	void PlaySound( AudioClip c )
	{
		_audSrc.clip = c;
		_audSrc.Play();
	}

	void FadeInClip( AudioClip c )
	{
		if(_audSrc.isPlaying == false)
		{
			PlaySound(c);
			return;
		}

		Sequence fadeInSeq = new Sequence();

		//Pass the desired clip as a parameter
		object[] objParms = new object[1];
		objParms[0] = c;

		//Fade out current sound, switch clips and fade back in
		fadeInSeq.Append(HOTween.To(_audSrc, 1.0f, new TweenParms().Prop("volume", 0.0f).OnComplete(SwitchSounds, objParms)));
		fadeInSeq.Append(HOTween.To(_audSrc, 1.0f, new TweenParms().Prop("volume", 1.0f)));

		fadeInSeq.Play();
	}
	

		               
}
