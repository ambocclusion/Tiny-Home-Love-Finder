using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LoveTarget : MonoBehaviour {

	public Lover Me;

	public ParticleSystem LoveParticle;
	public ParticleSystem HateParticle;
	public AudioSource audioSource;

	private string _myName = "";

	private ExampleVariableStorage _storage;
	private string _named = "";

	void Start(){

		_storage = Object.FindObjectOfType<ExampleVariableStorage>();
		_myName = this.gameObject.name;

		_named = GetComponent<Yarn.Unity.Example.NPC>().characterName;
		_storage.SetValue("$" + _named + "Love", new Yarn.Value((float)Me.PlayerRating));
		audioSource = GetComponent<AudioSource>();
		//_storage.SetValue("$" + _named + "TalkedToToday", new Yarn.Value((float)Me.LastTalkedToDay));


	}

	void LateUpdate(){

		if(Me.LastTalkedToDay != TimeManager.Instance.CurrentDay)
			_storage.SetValue("$" + _named + "_talked_to_today", new Yarn.Value(0.0f));

	}

	public void DoneTalkingTo(){

		Me.LastTalkedToDay = TimeManager.Instance.CurrentDay;

	}

	[YarnCommand("addlove")]
	public void AddLove(){

		Me.PlayerRating++;
		_storage.SetValue("$" + _named + "Love", new Yarn.Value((float)Me.PlayerRating));
		LoveParticle.Play();

		if(Me.PlayerRating >= LoveManager.Instance.LikabilityToMoveIn){
			LoveManager.Instance.MoveIn(this);
		}

		audioSource.Play();

	}

	[YarnCommand("removelove")]
	public void RemoveLove(){

		Me.PlayerRating--;
		_storage.SetValue("$" + _named + "Love", new Yarn.Value((float)Me.PlayerRating));
		HateParticle.Play();

	}

	void Update(){

		if(LoveManager.Instance.currentTalkingTo == this){
			this.gameObject.name = "CurrentTarget";
			Me.LastTalkedToDay = TimeManager.Instance.CurrentDay;
			//_storage.SetValue("$" + _named + "TalkedToToday", new Yarn.Value((float)Me.LastTalkedToDay));
		}
		else
			this.gameObject.name = _myName;

	}
}
