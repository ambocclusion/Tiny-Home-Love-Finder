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

	public UnityEngine.UI.Image fader;

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

		if(Input.GetKeyDown(KeyCode.K)){
			if(Input.GetKeyDown(KeyCode.Alpha8))
				AllLovers[0].AddLove();
			if(Input.GetKeyDown(KeyCode.Alpha9))
				AllLovers[1].AddLove();
			if(Input.GetKeyDown(KeyCode.Alpha0))
				AllLovers[2].AddLove();
			if(Input.GetKeyDown(KeyCode.Alpha7))
				EndGame();
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
			if(MovedIn.Count >= 3){
				Invoke("EndGame", 11.0f);
			}
		}

	}

	public void EndGame(){

		StateManager.Instance.SetState(GameStates.CUTSCENE);
		FindObjectOfType<DialogueRunner> ().StartDialogue ("ending.start");
		StartCoroutine("FadeOut");

	}

	public IEnumerator FadeOut(){

		while(fader.color.a != 1){

			Color a = fader.color;
			a.a = Mathf.MoveTowards(a.a, 1.0f, 1.0f * Time.deltaTime);
			fader.color = a;
			yield return null;
		}

	}

	[YarnCommand("restartgame")]
	public void RestartGame(){

		Application.LoadLevel(0);

	}

}
