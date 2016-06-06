using UnityEngine;
using System.Collections;

public class SpinningCube : MainBehaviour {

	public Vector3 RotateSpeed = new Vector3(1,1,1);

	protected override void GameUpdate(){

		transform.Rotate(RotateSpeed * DeltaTime);

	}

}
