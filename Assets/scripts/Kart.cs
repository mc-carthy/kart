using UnityEngine;
using System.Collections;

public class Kart : MonoBehaviour {

	private Rigidbody rb;
	private float forwardSpeed = 10f;
	private float rotateSpeed = 100f;

	private void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	private void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		transform.RotateAround (transform.position, Vector3.up, h * rotateSpeed * Time.deltaTime);

		float v = Input.GetAxisRaw ("Vertical");
		rb.velocity =  transform.forward * v * forwardSpeed;
	}
}