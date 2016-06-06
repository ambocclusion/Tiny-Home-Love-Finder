using UnityEngine;
using System.Collections;

public abstract class MainBehaviour : MonoBehaviour {

	protected float GameTime = 0.0f;
	protected float DeltaTime = 0.0f;

	protected virtual void GameUpdate(){}
	protected virtual void LateGameUpdate(){}
	protected virtual void FixedGameUpdate(){}

	protected virtual void Update(){
		if(StateManager.Instance != null && StateManager.Instance.IsRunning ()){
			DeltaTime = Time.deltaTime;
			GameTime += DeltaTime;
			GameUpdate();
		}
	}

	protected virtual void LateUpdate(){
		if(StateManager.Instance != null && StateManager.Instance.IsRunning ())
			LateGameUpdate();
	}

	protected virtual void FixedUpdate(){
		if(StateManager.Instance != null && StateManager.Instance.IsRunning ())
			FixedGameUpdate();
	}

}
