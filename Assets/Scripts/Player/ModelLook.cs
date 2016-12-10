using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLook : MainBehaviour {

	public PlayerMovement MyMovement;
	
	protected override void FixedGameUpdate() {
		
		if(MyMovement.PlayerInput != Vector2.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(MyMovement.PlayerInput.x, 0, MyMovement.PlayerInput.y)), 5f * Time.deltaTime);

	}
}
