using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
						Application.LoadLevel(level);
				}
	}
}
