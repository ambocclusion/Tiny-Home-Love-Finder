using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MainBehaviour {

	public float PlayerSpeed = 5f;
	public Vector2 PlayerInput = new Vector2();

	public Animator anim;

	public ParticleSystem smoke;

	private DialogueRunner _dialogue;
	private Rigidbody _rigid;

	private Vector3 _defaultPos;

	void Awake() {

		_rigid = GetComponent<Rigidbody>();
		_defaultPos = transform.position;

	}

	void Start() {

		_dialogue = FindObjectOfType<DialogueRunner>();

	}
 
	protected override void FixedGameUpdate() {

		if (_dialogue.isDialogueRunning){
			anim.SetBool("walking", false);
			return;
		}

		PlayerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		_rigid.velocity = new Vector3(PlayerInput.x * (PlayerSpeed), _rigid.velocity.y, PlayerInput.y * (PlayerSpeed));

		if(PlayerInput == Vector2.zero){
			anim.SetBool("walking", false);
			smoke.Stop();
		}
		else if(PlayerInput != Vector2.zero){
			anim.SetBool("walking", true);
			smoke.Play();
		}

		if(transform.position.y < -10f)
			transform.position = _defaultPos + (Vector3.up * 15f);

	}
	
}
