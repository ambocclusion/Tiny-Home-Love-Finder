using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveTarget : MonoBehaviour {

	public Lover Me;

	public void AddLove(int amt){

		Me.PlayerRating += amt;

	}
}
