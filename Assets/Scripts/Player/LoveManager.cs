using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

public class LoveManager : SingletonMainBehaviour<LoveManager> {

	public LoveTarget currentTalkingTo;
	public List<LoveTarget> AllLovers = new List<LoveTarget>();

	public List<LoveTarget> MovedIn = new List<LoveTarget>();

	public int LikabilityToMoveIn = 3;

	private DialogueRunner _dialogue;

	void Start(){

		AllLovers = Object.FindObjectsOfType<LoveTarget>().ToList();
		_dialogue = FindObjectOfType<DialogueRunner>();

	}

	protected override void GameUpdate(){ 

		if(!_dialogue.isDialogueRunning){
			if(currentTalkingTo != null)
				currentTalkingTo.Me.LastTalkedToDay = TimeManager.Instance.CurrentDay;
			currentTalkingTo = null;
		}

	}

	public void SetTalkingTo(LoveTarget target){

		currentTalkingTo = target;

	}

	public void MoveIn(LoveTarget target){

		if(!MovedIn.Contains(target)){
			MovedIn.Add(target);
			target.gameObject.SetActive(false);
			GetComponent<MoveInCutsceneStarter>().StartCutscene(target);
		}

	}

}
