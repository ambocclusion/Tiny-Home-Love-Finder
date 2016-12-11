using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotato : MonoBehaviour {

	public Vector3 RotateSpeed = new Vector3();

	void FixedUpdate () {

		transform.Rotate(RotateSpeed, Space.World);
		
	}
}
