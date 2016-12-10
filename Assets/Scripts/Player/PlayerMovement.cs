using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MainBehaviour {

	public float PlayerSpeed = 5f;
	public float SprintSpeed = 10f;
	public Vector2 PlayerInput = new Vector2();

	private Rigidbody _rigid;

	void Awake(){

		_rigid = GetComponent<Rigidbody>();

	}
 
	protected override void FixedGameUpdate() {

		PlayerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		float currentSpeed = Input.GetAxis("Sprint") == 0 ? PlayerSpeed : SprintSpeed;

		_rigid.velocity = new Vector3(PlayerInput.x * (currentSpeed), 0, PlayerInput.y * (currentSpeed));

	}
	
}
