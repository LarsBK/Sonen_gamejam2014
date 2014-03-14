using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int controllerNum = 1;
	public float moveForce = 10;
	public float maxSpeed = 10;
	public float rotationSpeed = 360;

	private Vector2 moveVector = new Vector2(0,0);
	private Vector2 aimVector = new Vector2(0,0);
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string inputPrefix = "Player" + controllerNum + " ";

		moveVector.x = Input.GetAxis (inputPrefix + "move x");
		moveVector.y = Input.GetAxis (inputPrefix + "move y");
		aimVector.x = (float) (Input.GetAxis (inputPrefix + "aim x") * -1.0);
		aimVector.y = Input.GetAxis(inputPrefix + "aim y");

	}

	void FixedUpdate() {

		//Limit speed
		if (Mathf.Abs (rigidbody2D.velocity.x) >= maxSpeed && ((rigidbody2D.velocity.x * moveVector.x) > 0))
			moveVector.x = 0;
		if (Mathf.Abs (rigidbody2D.velocity.y) >= maxSpeed && ((rigidbody2D.velocity.y * moveVector.y) > 0))
			moveVector.y = 0;

		//Apply move force
		rigidbody2D.AddForce (moveVector * (moveForce * Time.fixedDeltaTime));

		//Rotate accoring to aim
		if (aimVector.magnitude > 0.5) {
			aimVector.Normalize ();
			float aimAngle = (float) (((Mathf.Atan2(aimVector.x, aimVector.y) * 180.0)) / (((double)Mathf.PI)));
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, aimAngle), rotationSpeed*Time.fixedDeltaTime);
		}

	}
}
