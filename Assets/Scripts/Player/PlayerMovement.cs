using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MainBehaviour {

	public float PlayerSpeed = 5f;
	public Vector2 PlayerInput = new Vector2();

	public Animator anim;

	private DialogueRunner _dialogue;
	private Rigidbody _rigid;

	void Awake() {

		_rigid = GetComponent<Rigidbody>();

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

		if(PlayerInput == Vector2.zero)
			anim.SetBool("walking", false);
		else if(PlayerInput != Vector2.zero)
			anim.SetBool("walking", true);

	}
	
}
