﻿using UnityEngine;
using System.Collections;

public class GIveScore : MonoBehaviour {

	private ScoreController scoreObject = null;
	public float life = 0.1f;


	// Use this for initialization
	void Start () {
		scoreObject = (ScoreController) GameObject.Find("Score").GetComponent( typeof(ScoreController));
	
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			col.gameObject.GetComponent<Health>().giveLife(life);

						scoreObject.addPoint ();
						Destroy (gameObject);
				}
	}
}
