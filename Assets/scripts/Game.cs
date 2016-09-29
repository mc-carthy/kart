using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private Camera mainCam;
	[SerializeField]
	private Kart kart;
	[SerializeField]
	private Vector3 cameraOffset;
	private float forwardOffset = 1;

	private void Start () {
		mainCam = Camera.main;
		cameraOffset = mainCam.transform.position - kart.transform.position;
	}

	private void Update () {
		mainCam.transform.position = new Vector3(
			kart.transform.position.x - kart.transform.forward.x * 2,
			kart.transform.position.y + cameraOffset.y,
			kart.transform.position.z - kart.transform.forward.z * 2
		);
		mainCam.transform.LookAt (kart.transform.position + kart.transform.forward * forwardOffset);
	}
}
