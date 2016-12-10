using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLook : MainBehaviour {

	public PlayerMovement MyMovement;

	public Vector3 LookAt = new Vector3();

	void Start(){

		LookAt = transform.position;

	}

	// Update is called once per frame
	protected override void FixedGameUpdate() {
		
		if(MyMovement.PlayerInput != Vector2.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(MyMovement.PlayerInput.x, 0, MyMovement.PlayerInput.y)), 5f * Time.deltaTime);

	}
}
