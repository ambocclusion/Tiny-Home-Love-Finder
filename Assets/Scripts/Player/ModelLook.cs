﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ModelLook : MainBehaviour {

	public PlayerMovement MyMovement;

	private DialogueRunner _dialogue;
	
	void Start() {

		_dialogue = FindObjectOfType<DialogueRunner>();

	}
	
	protected override void FixedGameUpdate() {

		if (_dialogue.isDialogueRunning)
			return;
		
		if(MyMovement.PlayerInput != Vector2.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(MyMovement.PlayerInput.x, 0, MyMovement.PlayerInput.y)), 5f * Time.deltaTime);

	}
}
