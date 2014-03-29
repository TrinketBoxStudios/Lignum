using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins; // only if you need a plugin

public class FadeScreenQueue : MonoBehaviour {

	public SpriteRenderer[] screenList;

	public float fadeInTime = 1.0f;
	public float sustainTime = 1.5f;
	public float fadeOutTime = 1.0f;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < screenList.Length; ++i)
		{
			Color spColor = screenList[i].color;
			spColor.a = 0.0f;
			screenList[i].color = spColor;

			SetAllChildrenAlpha(screenList[i].gameObject, 0.0f);
		}

		InitTweenSequence();
	}

	void InitTweenSequence()
	{
		Sequence fadeSeq = new Sequence();

		for(int i = 0; i < screenList.Length; ++i)
		{
			object[] objParam = new object[2];
			objParam[0] = screenList[i].gameObject;

			Color tempColor = screenList[i].color;
			tempColor.a = 1.0f;
			fadeSeq.Append(HOTween.To(screenList[i], fadeInTime, new TweenParms().Prop("color", tempColor).OnUpdate(RevealChildren, objParam)));

			//Second tween to the same value to allow the screen to stall
			fadeSeq.Append(HOTween.To(screenList[i], sustainTime, new TweenParms().Prop("color", tempColor)));

			tempColor.a = 0.0f;
			fadeSeq.Append(HOTween.To(screenList[i], fadeOutTime, new TweenParms().Prop("color", tempColor).OnUpdate(FadeChildren, objParam)));
		}

		fadeSeq.Append(HOTween.To(this, 0.0f, new TweenParms().Prop("fadeInTime", 1.0f).OnComplete(Finished)));

		fadeSeq.Play();
	}

	void FadeChildren(TweenEvent tEvent)
	{
		float duration = tEvent.tween.duration;
		float elapsed = tEvent.tween.elapsed;
		GameObject screen = (GameObject)tEvent.parms[0];
		float newAlpha = 1.0f - (elapsed / duration);

		SetAllChildrenAlpha(screen, newAlpha);
	}

	void RevealChildren(TweenEvent tEvent)
	{
		float duration = tEvent.tween.duration;
		float elapsed = tEvent.tween.elapsed;
		GameObject screen = (GameObject)tEvent.parms[0];
		float newAlpha = elapsed / duration;

		SetAllChildrenAlpha(screen, newAlpha);
	}

	void SetAllChildrenAlpha(GameObject go, float alpha)
	{
		foreach(Transform tChild in go.transform)
		{
			SpriteRenderer spRender = tChild.GetComponent<SpriteRenderer>();
			Color spColor = spRender.color;
			spColor.a = alpha;
			spRender.color = spColor;
		}
	}

	void Finished()
	{
		Application.LoadLevel("MainMenu");
	}
	
}
