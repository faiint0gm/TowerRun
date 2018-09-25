using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rigidBody;

	float xRotation;
	float zMove;
	bool isJump;

	public LayerMask groundLayer;
	public float rotationSpeed = 150.0f;
	public float moveSpeed = 3.0f;
	public Vector3 jumpForce = new Vector3(0,1,0);
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
	}

	void Update () {
		Move ();
		CheckJump ();
	}

	void Move()
	{
		xRotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
		zMove = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;

		transform.Rotate (0, xRotation, 0);
		transform.Translate (0, 0, zMove);
	}

	void CheckJump()
	{
		Debug.Log ("isGrounded : " + IsGrounded ());
		Debug.Log ("isJump : " + isJump);
		if (Input.GetKeyDown (KeyCode.Space) && !isJump && IsGrounded())
		{
			rigidBody.AddForce (jumpForce, ForceMode.Impulse);
		}
	}

	bool IsGrounded()
	{
		Vector3 position = transform.position;
		Vector3 direction = Vector3.down;
		float distance = 1.0f;

		RaycastHit hit;
		Physics.Raycast(position, direction, out hit, distance, groundLayer);
		if (hit.collider != null) {
			isJump = false;
			return true;
		} else {
			isJump = true;
			return false;
		}
	}
}
