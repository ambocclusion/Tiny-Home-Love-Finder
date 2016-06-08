using UnityEngine;
using System.Collections;

public static class VectorExtensions {

	public static Vector3 ToVector3(this Vector2 target){
		return new Vector3(target.x, target.y, 0);
	}

	public static Vector2 ToVector2(this Vector3 target){
		return new Vector2(target.x, target.y);
	}
	
}