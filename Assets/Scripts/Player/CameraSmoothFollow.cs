using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : SingletonMainBehaviour<CameraSmoothFollow> {

	public Transform PlayerTarget;
	public Transform FollowTarget;
	public float FollowSpeed = 5.0f;
	public Vector3 offset = Vector3.zero;
	public Vector3 ZoomOffset = Vector3.zero;
	//public float ZoomAngle = 45f;
	public Vector3 DefaultRot = new Vector3();
	public Vector3 ZoomRot = new Vector3();

	private Vector3 _currentOffset;
	private Vector3 _currentAngle;

	void Start(){

		_currentOffset = offset;
		_currentAngle = DefaultRot;

	}

	protected override void FixedGameUpdate(){

		transform.position = Vector3.Lerp(transform.position, FollowTarget.position + transform.TransformVector(_currentOffset), FollowSpeed);
		transform.eulerAngles = new Vector3(Mathf.LerpAngle(transform.eulerAngles.x, _currentAngle.x, .035f), Mathf.LerpAngle(transform.eulerAngles.y, _currentAngle.y, .035f), transform.eulerAngles.z);

	}

	public void ZoomToTarget(Transform target){

		SetTarget(target);
		_currentOffset = ZoomOffset;
		_currentAngle = ZoomRot;

	}

	public void SetTarget(Transform target){

		FollowTarget = target;

	}

	public void ResetTargetToPlayer(){

		SetTarget(PlayerTarget);
		_currentOffset = offset;
		_currentAngle = DefaultRot;

	}

}
