using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	private Camera mainCam;
	[SerializeField]
	private Kart kart;
	[SerializeField]
	private Text timeText;
	private Vector3 cameraOffset;
	private float forwardOffset = 3;
	private float gameTimer;

	private void Start () {
		mainCam = Camera.main;
		cameraOffset = mainCam.transform.position - kart.transform.position;
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
}
