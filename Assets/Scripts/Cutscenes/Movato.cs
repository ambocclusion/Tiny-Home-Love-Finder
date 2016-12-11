using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movato : MonoBehaviour {

	public Transform MoveTo;
	public float Speed = 1.0f;

	void FixedUpdate () {

		transform.position = Vector3.MoveTowards(transform.position, MoveTo.position, Speed);
		
	}
}
