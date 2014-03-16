using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

		public float health = 1.0f;
		public bool isDead = false;
		public AudioClip[] hurtSounds;
	public int playersLeft = 2;
	public GameObject blood;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer> ();
				foreach (var s in sp) {

						s.color = Color.Lerp (Color.red, Color.white, health);
						if (isDead) {
								s.color = Color.Lerp (Color.black, Color.red, 0.5f);
						}
				}
	
		}

		IEnumerator gameOver ()
		{
		Time.timeScale = 0;
				yield return new WaitForSeconds (5);
		Time.timeScale = 1;
				Application.LoadLevel (Application.loadedLevel);
		}

		public void giveLife(float l) {
		if ((health + l) <= 1.0f)
				health += l;
		}
	
		public void hurt (float dm)
		{
				health -= dm;

				if (blood != null) {
			Instantiate(blood, gameObject.transform.position, gameObject.transform.rotation);
				}
				


				if (health <= 0) {
						isDead = true;
			if(gameObject.CompareTag("Player")) {playersLeft--; print ("Player died!");}
			if(playersLeft == 0 || gameObject.CompareTag("Chain")) {
				print ("Game Over!");
						StartCoroutine (gameOver ());
			} else if(gameObject.CompareTag("Enemy")) {
				print ("Enemy Died!");
				GameObject.Destroy(gameObject);
			}
				} else {
						if (hurtSounds.Length > 0) {
								int i = Random.Range (0, hurtSounds.Length);
								audio.PlayOneShot (hurtSounds [i]);
						}
				}
		}
}
