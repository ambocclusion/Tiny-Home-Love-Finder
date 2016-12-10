using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLook : MonoBehaviour {

	public PlayerMovement MyMovement;

	public Vector3 LookAt = new Vector3();

	void Start(){

		LookAt = transform.position;

	}

	// Update is called once per frame
	void Update () {

		/*LookAt = new Vector3(MyMovement.PlayerInput.x * 10f, 0f, MyMovement.PlayerInput.y * 10f);
		float angle = Vector3.Angle(transform.position, transform.InverseTransformDirection(LookAt));
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.eulerAngles.y, angle, 90.0f * Time.deltaTime), transform.eulerAngles.z);
		*/

		if(MyMovement.PlayerInput != Vector2.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(MyMovement.PlayerInput.x, 0, MyMovement.PlayerInput.y)), 5f * Time.deltaTime);

	}
}
