using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : SingletonMainBehaviour<CameraSmoothFollow> {

	public Transform PlayerTarget;
	public Transform FollowTarget;
	public float FollowSpeed = 5.0f;
	public Vector3 offset = Vector3.zero;
	public Vector3 ZoomOffset = Vector3.zero;
	public float ZoomAngle = 45f;

	private Vector3 _currentOffset;
	private float _currentAngle;

	void Start(){

		_currentOffset = offset;
		_currentAngle = 0.0f;

	}

	protected override void FixedGameUpdate(){

		transform.position = Vector3.Lerp(transform.position, FollowTarget.position + transform.TransformVector(_currentOffset), FollowSpeed);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.LerpAngle(transform.eulerAngles.y, _currentAngle, .1f), transform.eulerAngles.z);

	}

	public void ZoomToTarget(Transform target){

		SetTarget(target);
		_currentOffset = ZoomOffset;
		_currentAngle = ZoomAngle;

	}

	public void SetTarget(Transform target){

		FollowTarget = target;

	}

	public void ResetTargetToPlayer(){

		SetTarget(PlayerTarget);
		_currentOffset = offset;
		_currentAngle = 0.0f;

	}

}
