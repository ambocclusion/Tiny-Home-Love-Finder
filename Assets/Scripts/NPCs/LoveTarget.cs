using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LoveTarget : MonoBehaviour {

	public Lover Me;

	private string _myName = "";

	private ExampleVariableStorage _storage;
	private string _named = "";

	void Start(){

		_storage = Object.FindObjectOfType<ExampleVariableStorage>();
		_myName = this.gameObject.name;

		_named = GetComponent<Yarn.Unity.Example.NPC>().characterName;
		_storage.SetValue("$" + _named + "Love", new Yarn.Value((float)Me.PlayerRating));

	}

	[YarnCommand("addlove")]
	public void AddLove(){

		Me.PlayerRating++;
		_storage.SetValue("$" + _named + "Love", new Yarn.Value((float)Me.PlayerRating));

		if(Me.PlayerRating >= LoveManager.Instance.LikabilityToMoveIn){
			LoveManager.Instance.MoveIn(this);
		}

	}

	[YarnCommand("removelove")]
	public void RemoveLove(){

		Me.PlayerRating--;
		_storage.SetValue("$" + _named + "Love", new Yarn.Value((float)Me.PlayerRating));

	}

	void Update(){

		if(LoveManager.Instance.currentTalkingTo == this)
			this.gameObject.name = "CurrentTarget";
		else
			this.gameObject.name = _myName;

	}
}
