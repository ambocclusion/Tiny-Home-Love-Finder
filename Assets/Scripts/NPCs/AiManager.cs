using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;
using Yarn.Unity;

public class AiManager : MainBehaviour {

	public float IdleTime = 10.0f;

	public bool IsIdling = false;

	private float _endIdleTime = 0.0f;
	private DialogueRunner _dialogue;
	private Vector3 _defaultPos;

	void Start(){

		_dialogue = FindObjectOfType<DialogueRunner>();
		SetNextIdleTime();
		_defaultPos = transform.position;

	}

	protected override void GameUpdate(){

		if(_dialogue.isDialogueRunning && LoveManager.Instance.currentTalkingTo == GetComponent<LoveTarget>()){
			_endIdleTime = GameTime + IdleTime;
			GetComponent<AutonomousVehicle>().CanMove = false;
			IsIdling = true;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LoveManager.Instance.transform.position - transform.position), 2.5f * Time.deltaTime);
			return;
		}

		if(GameTime >= _endIdleTime){

			IsIdling = !IsIdling;
			SetNextIdleTime();

		}

		GetComponent<AutonomousVehicle>().CanMove = !IsIdling;

		if(transform.position.y < -10f)
			transform.position = _defaultPos + (Vector3.up * 30f);

	}

	private void SetNextIdleTime(){

		_endIdleTime = GameTime + Random.Range(3.0f, IdleTime);

	}

}
