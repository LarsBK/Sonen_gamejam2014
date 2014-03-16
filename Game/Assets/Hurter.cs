using UnityEngine;
using System.Collections;

public class Hurter : MonoBehaviour {

	public float damage = 0.1f;
	public float cooldownTime = 1.0f;

	private float lastTime = 0.0f;
	private bool timerStarted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timerStarted && (lastTime + cooldownTime) <= Time.realtimeSinceStartup) {
						timerStarted = false;
				}
	}
	
	void doHurt(GameObject gm) {
		if (gm.CompareTag (gameObject.tag))
						return;
		if (timerStarted == false) {
						Health hp = gm.GetComponent<Health> ();
						if (hp != null && ! hp.isDead) {
								hp.hurt (damage);
								lastTime = Time.realtimeSinceStartup ;
				timerStarted = true;
						}
				}
	}

	public void OnTriggerStay2D(Collider2D col) {
				doHurt (col.gameObject);
		}
	public void OnCollisionStay2D(Collision2D col) {
				doHurt (col.gameObject);
		}

}
