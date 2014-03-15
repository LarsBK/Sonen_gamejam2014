using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject follow = null;
	public float deadZone = 10;
	public float stopZone = 4;
	public float moveSpeed = 10;

	private bool moving = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			Vector2 moveTo = follow.transform.position;
			Vector2 current = transform.position;
			float distance = (moveTo - current).magnitude;
			if (distance <= stopZone) {
				moving = false;
			} else if (moving || distance > deadZone) {
				moving = true;
				Vector3 l = Vector3.Lerp(current, moveTo, Time.deltaTime*moveSpeed);
				l.z = transform.position.z;
				transform.position = l;
			} 

		}
	}
}
