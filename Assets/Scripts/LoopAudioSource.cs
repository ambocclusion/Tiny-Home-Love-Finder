using UnityEngine;

public class LoopAudioSource : MonoBehaviour {

	public float startLoopTime;
	public float endLoopTime;

	private AudioSource source;

	void Start() {
		this.source = this.gameObject.GetComponent<AudioSource>();
	}

	void FixedUpdate() {
		if(source.time >= endLoopTime){
			source.time = startLoopTime;
		}
	}
}
