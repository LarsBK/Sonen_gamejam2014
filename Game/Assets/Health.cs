using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

		public float health = 1.0f;
		public bool isDead = false;
		public AudioClip[] hurtSounds;
	public AudioClip deathSound;
	public static int playersLeft = 2;
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
		Time.timeScale = 0.01f;
				yield return new WaitForSeconds (0.05f);
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
						if(deathSound != null) {
							audio.PlayOneShot(deathSound);
						}
			if(gameObject.CompareTag("Player")) {playersLeft--; print ("Player died!");}
			if(playersLeft == 0) {
				StartCoroutine (gameOver ());
			} if(gameObject.CompareTag("Chain")) {
				GameObject[] gm = GameObject.FindGameObjectsWithTag("Player");
				foreach( var g in gm) {
					g.GetComponent<Health>().hurt(100);
				}
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
