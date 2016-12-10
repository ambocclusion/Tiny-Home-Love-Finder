using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

public class LoveManager : SingletonMainBehaviour<LoveManager> {

	public LoveTarget currentTalkingTo;
	public List<LoveTarget> AllLovers = new List<LoveTarget>();

	private DialogueRunner _dialogue;

	void Start(){

		AllLovers = Object.FindObjectsOfType<LoveTarget>().ToList();
		_dialogue = FindObjectOfType<DialogueRunner>();

	}

	void Update(){

		if(!_dialogue.isDialogueRunning)
			currentTalkingTo = null;

	}

	public void SetTalkingTo(LoveTarget target){

		currentTalkingTo = target;

	}

}
