using UnityEngine;
using System.Collections;

public class LoopGameState : MonoBehaviour {

	void OnMouseDown()
	{
		GameStateManager.GetInstance().AdvanceAge();
	}
}
