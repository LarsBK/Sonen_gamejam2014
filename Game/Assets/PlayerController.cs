using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int controllerNum = 1;
	public float moveForce = 10;
	public float slowDownForce = 10;
	public float maxSpeed = 10;
	public float rotationSpeed = 360;

	private Vector2 moveVector = new Vector2(0,0);
	private Vector2 aimVector = new Vector2(0,0);

	private Health hpCmp;
	

	// Use this for initialization
	void Start () {
		hpCmp = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		string inputPrefix = "Player" + controllerNum + " ";

		moveVector.x = Input.GetAxis (inputPrefix + "move x");
		moveVector.y = Input.GetAxis (inputPrefix + "move y");
		aimVector.x = (float) (Input.GetAxis (inputPrefix + "aim x") * -1.0);
		aimVector.y = (float) (Input.GetAxis(inputPrefix + "aim y") * -1.0);

	}

	void FixedUpdate() {
		if (hpCmp.isDead) {
						return;
				}

		Vector2 forceVector = moveVector;

		if (moveVector.magnitude > 0.6) { //speed up
			//Limit speed
			if (Mathf.Abs (rigidbody2D.velocity.x) >= maxSpeed && ((rigidbody2D.velocity.x * moveVector.x) > 0))
				forceVector.x = 0;
			if (Mathf.Abs (rigidbody2D.velocity.y) >= maxSpeed && ((rigidbody2D.velocity.y * moveVector.y) > 0))
				forceVector.y = 0;
			forceVector *= moveForce;
			float aimAngle = (float) (((Mathf.Atan2(rigidbody2D.velocity.x, rigidbody2D.velocity.y) * 180.0)) / (((double)Mathf.PI)));
			transform.rotation = Quaternion.RotateTowards(
				transform.rotation, Quaternion.Euler(0, 0, aimAngle - 90), rotationSpeed*Time.fixedDeltaTime);
		} else { //Slow down
			forceVector = rigidbody2D.velocity * (float) -1.0;
			forceVector.Normalize();
			forceVector *= slowDownForce;
		}

		//Apply move force
		rigidbody2D.AddForce (forceVector * Time.fixedDeltaTime);

		//Rotate accoring to aim
		/*
		if (aimVector.magnitude > 0.6) {
			aimVector.Normalize ();
			float aimAngle = (float) (((Mathf.Atan2(aimVector.x, aimVector.y) * 180.0)) / (((double)Mathf.PI)));
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, aimAngle), rotationSpeed*Time.fixedDeltaTime);
		} 
		*/

	}
}
