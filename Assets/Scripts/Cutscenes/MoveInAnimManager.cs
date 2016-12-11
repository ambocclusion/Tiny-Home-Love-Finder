using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInAnimManager : MonoBehaviour {

	public GameObject CitizenSprite;
	public GameObject PlayerModel;
	public Transform CitizenGoal;
	public GameObject cam;

	public ParticleSystem ExplodeParticle;
	public ParticleSystem SecondExplodeParticle;

	public AudioClip moan;

	private bool _played = false;

	public void Init(LoveTarget target){

		CitizenSprite.GetComponent<SpriteRenderer>().sprite = target.transform.FindChild("Char Sprite").GetComponent<SpriteRenderer>().sprite;
		StateManager.Instance.SetState(GameStates.CUTSCENE);

	}
	
	void Update () {

		if(Vector3.Distance(CitizenSprite.transform.position, CitizenGoal.transform.position) <= .15f){
			CitizenSprite.SetActive(false);
			if(!_played){
				ExplodeParticle.Play();
				SecondExplodeParticle.Play();
				PlayMoan();
				Invoke("DisableCam", 1.5f);
				Invoke("BringBackGame", 2f);
				Invoke("DestroyMe", 10f);
				_played = true;
			}
		}
		
	}

	private void DisableCam(){

		cam.SetActive(false);

	}

	private void BringBackGame(){

		StateManager.Instance.SetState(GameStates.RUNNING);

	}

	private void DestroyMe(){

		Destroy(this.gameObject);

	}

	private void PlayMoan(){

		AudioSource.PlayClipAtPoint(moan, transform.position);

	}
}
