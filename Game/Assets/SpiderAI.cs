using UnityEngine;
using System.Collections;

public class SpiderAI : MonoBehaviour {

	public Vector2 direction = new Vector2(-1,0);
	public int changeDirProbability = 100;
	public float moveForce = 1000f;
	public float rotationSpeed = 360f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

				int rand = Random.Range (0, changeDirProbability);

				if (rand == 0) {
						direction.x = Random.Range (0.1f, 1.0f);
						direction.y = Random.Range (0.1f, 1.0f);
						direction.Normalize ();
				}

		rigidbody2D.AddForce (direction * Time.fixedDeltaTime * moveForce);
		float aimAngle = (float) (((Mathf.Atan2(direction.y, direction.x) * 180.0)) / (((double)Mathf.PI)));
		transform.rotation = Quaternion.RotateTowards(
			transform.rotation, Quaternion.Euler(0, 0, aimAngle + 90), rotationSpeed*Time.fixedDeltaTime);
		}


}
