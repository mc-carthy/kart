using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	private Camera mainCam;
	[SerializeField]
	private Kart kart;
	[SerializeField]
	private GameObject checkpointContainer;
	[SerializeField]
	private Text timeText;
	private Vector3 cameraOffset;
	private Checkpoint[] checkpoints;
	private float forwardOffset = 3;
	private float gameTimer;
	private int currentCheckpoint = -1;

	private void Start () {
		mainCam = Camera.main;
		cameraOffset = mainCam.transform.position - kart.transform.position;

		checkpoints = checkpointContainer.GetComponentsInChildren<Checkpoint> ();
		foreach (Checkpoint checkpoint in checkpoints) {
			checkpoint.onHitByPlayer = (int checkpointId) => {
				OnHitCheckpoint (checkpointId);
			};
		}
	}

	private void Update () {
		CameraFollow (kart);
		UpdateTime ();
	}

	private void CameraFollow (Kart target) {
		mainCam.transform.position = new Vector3(
			target.transform.position.x - target.transform.forward.x * forwardOffset,
			target.transform.position.y + cameraOffset.y,
			target.transform.position.z - target.transform.forward.z * forwardOffset
		);
		mainCam.transform.LookAt (target.transform.position + target.transform.forward * forwardOffset);
	}

	private void UpdateTime () {
		gameTimer += Time.deltaTime;
		timeText.text = "Lap: " + gameTimer.ToString ("0");
	}

	private void OnHitCheckpoint (int checkpointId) {
		if (checkpointId == currentCheckpoint + 1) {
			currentCheckpoint++;
		}
		if (checkpointId == 0 && currentCheckpoint == checkpoints.Length - 1) {
			Debug.Log ("Lap finished!");
			currentCheckpoint = 0;
		};
	}
}
