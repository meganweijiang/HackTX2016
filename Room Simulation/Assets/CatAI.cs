using UnityEngine;
using System.Collections;

public class CatAI : MonoBehaviour {

	public float speed = 4.0f;
	private bool isCollided = false;
	private Rigidbody cat;
	private int catDirection; 

	// Use this for initialization
	void Start () {
		cat = GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cat.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		transform.position += transform.forward*speed*Time.deltaTime;

		speed += 0.1f;

		if (speed > 8.0f) {
			speed = 4.0f;
		}

		if (isCollided) {
			transform.Rotate(0, 15, 0);
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2" || col.gameObject.name == "Wall3" || col.gameObject.name == "Wall4")
		{
			isCollided = true;
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2" || col.gameObject.name == "Wall3" || col.gameObject.name == "Wall4")
		{
			isCollided = false;
		}
	}
}
