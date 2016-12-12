using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TimeManager : SingletonMainBehaviour<TimeManager> {

	public float CurrentDayTime = 0.0f;
	public int CurrentDay = 0;
	public float DayLength = 80f;

	public float CurrentTime{
		get{
			return (CurrentDayTime / DayLength) * 24f;
		}
	}

	public Transform Light;
	public GameObject Sun;
	public GameObject Moon;

	public float RelativeStartTime = 12f;

	public bool UseRealTime = false;

	public bool PauseOnDialogue = false;

	private DialogueRunner _dialogue;

	void Start(){

		if(!UseRealTime)
			CurrentDayTime = (RelativeStartTime / 24f) * DayLength;
		else{
			CurrentDayTime = (((System.DateTime.Now.Hour * 60) * 60) + (System.DateTime.Now.Minute * 60) + System.DateTime.Now.Second);
			DayLength = (24 * 60) * 60;
		}
		_dialogue = FindObjectOfType<DialogueRunner>();

	}

	protected override void FixedGameUpdate(){

		if(PauseOnDialogue && _dialogue.isDialogueRunning)
			return;

		CurrentDayTime += Time.fixedDeltaTime;

		if(CurrentDayTime >= DayLength){
			CurrentDayTime = 0.0f;
			CurrentDay++;
		}

		Light.transform.eulerAngles = new Vector3(0,0,(CurrentDayTime / DayLength) * 360f);

		if(CurrentTime <= 6f){
			Sun.SetActive(false);
			Moon.SetActive(true);
		}
		else if(CurrentTime > 8f && CurrentTime <= 18f){
			Sun.SetActive(true);
			Moon.SetActive(false);
		}
		else if(CurrentTime > 20f){
			Sun.SetActive(false);
			Moon.SetActive(true);
		}
		else{
			Sun.SetActive(true);
			Moon.SetActive(true);	
		}


	}

}
