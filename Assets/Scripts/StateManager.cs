using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameStates{
	RUNNING,
	PAUSED,
	CUTSCENE
}

public class StateManager : MonoBehaviourSingleton<StateManager>{

	public GameStates CurrentState { get; private set; }

	public float GameTime { get; private set; }

	bool holding = false;
	void Update(){

		if (!IsPaused())
			GameTime += Time.deltaTime;

		if (Input.GetAxis("Cancel") != 0 && !holding){
			TogglePause();
			holding = true;
		}

		if (Input.GetAxis("Cancel") == 0)
			holding = false;


	}

	public void SetState(GameStates stateToChange){
		CurrentState = stateToChange;
	}

	public void SetState(string stateToChange){
		SetState((GameStates)System.Enum.Parse(typeof(GameStates), stateToChange));
	}

	public void TogglePause(){
		if (CurrentState == GameStates.PAUSED)
			SetState(GameStates.RUNNING);
		else if (CurrentState == GameStates.RUNNING)
			SetState(GameStates.PAUSED);
	}

	public bool IsRunning(){
		return CurrentState == GameStates.RUNNING ? true : false;
	}

	public bool IsPaused(){
		return CurrentState != GameStates.RUNNING ? true : false;
	}

	public void ResumeButton(){
		SetState(GameStates.RUNNING);
	}
}
