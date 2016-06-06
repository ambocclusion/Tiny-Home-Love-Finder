using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateWatcher : MonoBehaviour {

	private Text _myText;

	void Awake(){
		_myText = GetComponent<Text>();
	}

	void LateUpdate(){
		_myText.text = StateManager.Instance.CurrentState.ToString();
	}

}
