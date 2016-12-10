using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class PlayerInteraction : MonoBehaviour {

	public float interactionRadius = 2.0f;

		public float movementFromButtons {get;set;}

		private DialogueRunner _dialogue;

		void Start() {

			_dialogue = FindObjectOfType<DialogueRunner>();

		}

		void Update(){

			if (_dialogue.isDialogueRunning == true) {
				return;
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				CheckForNearbyNPC ();
			}

		}

		public void CheckForNearbyNPC ()
		{
			// Find all DialogueParticipants, and filter them to
			// those that have a Yarn start node and are in range; 
			// then start a conversation with the first one
			var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
			var target = allParticipants.Find (delegate (NPC p) {
				return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
				(p.transform.position - this.transform.position)// is in range?
				.magnitude <= interactionRadius;
			});
			if (target != null) {
				// Kick off the dialogue at this node.
				FindObjectOfType<DialogueRunner> ().StartDialogue (target.talkToNode);
				CameraSmoothFollow.Instance.ZoomToTarget(target.transform);
			}
		}
	
}
