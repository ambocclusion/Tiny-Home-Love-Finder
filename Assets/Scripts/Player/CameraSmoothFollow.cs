using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MainBehaviour {

	public Transform FollowTarget;
	public float FollowSpeed = 5.0f;
	public Vector3 offset = Vector3.zero;

	protected override void FixedGameUpdate(){

		transform.position = Vector3.Lerp(transform.position, FollowTarget.position + offset, FollowSpeed);

	}

}
