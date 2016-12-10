using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfDayText : MonoBehaviour {

	private Text _myText;

	void Awake(){

		_myText = GetComponent<Text>();

	}

	void Update () {

		string currentTime = TimeManager.Instance.CurrentTime < 12f ? Mathf.Floor(TimeManager.Instance.CurrentTime) == 0 ? "12 AM" : Mathf.Floor(TimeManager.Instance.CurrentTime).ToString() + " AM" : Mathf.Floor(TimeManager.Instance.CurrentTime - 12) == 0 ? "12 PM" : Mathf.Floor(TimeManager.Instance.CurrentTime - 12).ToString() + " PM";
		_myText.text = currentTime;
		
	}

}
