using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MainBehaviour {

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

	void Start(){

		CurrentDayTime = (RelativeStartTime / 24f) * DayLength;

	}

	protected override void FixedGameUpdate(){

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
		else if(CurrentTime > 6f && CurrentTime <= 18f){
			Sun.SetActive(true);
			Moon.SetActive(false);
		}
		else if(CurrentTime > 18f){
			Sun.SetActive(false);
			Moon.SetActive(true);
		}


	}

}
