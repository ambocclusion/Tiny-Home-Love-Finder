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

	protected override void FixedGameUpdate(){

		CurrentDayTime += Time.fixedDeltaTime;

		if(CurrentDayTime >= DayLength){
			CurrentDayTime = 0.0f;
			CurrentDay++;
		}

	}

}
