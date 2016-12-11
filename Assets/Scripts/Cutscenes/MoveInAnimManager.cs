using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInAnimManager : MonoBehaviour {

	public GameObject CitizenSprite;
	public GameObject PlayerModel;
	public Transform CitizenGoal;

	public ParticleSystem ExplodeParticle;
	public ParticleSystem SecondExplodeParticle;

	void Start () {
		
	}
	
	void Update () {

		if(Vector3.Distance(CitizenSprite.transform.position, CitizenGoal.transform.position) <= .15f){
			CitizenSprite.SetActive(false);
			ExplodeParticle.Play();
			SecondExplodeParticle.Play();
		}
		
	}
}
