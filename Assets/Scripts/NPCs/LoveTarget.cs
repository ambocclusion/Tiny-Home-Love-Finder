using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LoveTarget : MonoBehaviour {

	public Lover Me;

	private string _myName = "";

	void Start(){

		_myName = this.gameObject.name;

	}

	[YarnCommand("addlove")]
	public void AddLove(){

		Me.PlayerRating++;

		if(Me.PlayerRating >= LoveManager.Instance.LikabilityToMoveIn){
			LoveManager.Instance.MoveIn(this);
		}

	}

	[YarnCommand("removelove")]
	public void RemoveLove(){

		Me.PlayerRating--;

	}

	void Update(){

		if(LoveManager.Instance.currentTalkingTo == this)
			this.gameObject.name = "CurrentTarget";
		else
			this.gameObject.name = _myName;

	}
}
