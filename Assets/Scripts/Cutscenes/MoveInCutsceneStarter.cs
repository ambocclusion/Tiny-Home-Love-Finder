using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCutsceneStarter : MonoBehaviour {

	public GameObject Cutscene;

	public void StartCutscene(LoveTarget target){

		GameObject obj = Instantiate(Cutscene, transform.position, Quaternion.identity) as GameObject;

		obj.GetComponent<MoveInAnimManager>().Init(target);

	}
}
