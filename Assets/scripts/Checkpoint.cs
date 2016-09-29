using UnityEngine;
using System;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public Action<int> onHitByPlayer;

	[SerializeField]
	private int checkpointId;

	private void OnTriggerEnter (Collider trig) {
		if (trig.tag == "Player") {
			onHitByPlayer (checkpointId);
		}
	}
}
