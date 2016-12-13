using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStart : MonoBehaviour {

	public Transform player;
	public GameObject cam;
	public AudioSource music;

	public void StartGame(){

		player.SetParent(null);
		player.GetComponent<Rigidbody>().isKinematic = false;
		StartCoroutine("RotatePlayer");
		cam.GetComponent<CameraSmoothFollow>().enabled = true;

	}

	public IEnumerator RotatePlayer(){

		float timer = 0.0f;

		player.GetComponent<PlayerMovement>().enabled = false;

		while(player.eulerAngles != Vector3.zero){

			player.rotation = Quaternion.Slerp(player.rotation, Quaternion.Euler(new Vector3()), 4.0f * Time.deltaTime);
			timer += Time.deltaTime;
			if(timer >= 2.0f)
				player.eulerAngles = Vector3.zero;

			yield return null;

		}

		player.GetComponent<PlayerMovement>().enabled = true;
		music.Play();

	}

}
