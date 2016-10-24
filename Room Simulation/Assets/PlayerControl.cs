using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour {

	private Rigidbody thing;
	public float speed = 8.0f;
	private bool isGrounded = true;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		thing = GetComponent<Rigidbody>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (isMoving()) {
			thing.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			float rotateY = Input.GetAxis ("Horizontal");
			float moveZ = Input.GetAxis ("Vertical");

			transform.Rotate(0, rotateY, 0);

			Vector3 move = new Vector3 (0.0f, 0.0f, moveZ);
			move *= speed;
			transform.Translate(move*Time.deltaTime);

			if (Input.GetButtonDown ("Jump") && isGrounded) {
				Vector3 moveJump = new Vector3 (0.0f, 300.0f, moveZ);
				thing.AddForce(moveJump);
			}
		} 

		else {
			thing.constraints = RigidbodyConstraints.FreezeRotation;
		}
			
	}

	bool isMoving () {
		bool moving = false;
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetButtonDown ("Jump")) {
			moving = true;
		}
		return moving;
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Plane")
		{
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject.name == "Plane")
		{
			isGrounded = false;
		}
	}
}
