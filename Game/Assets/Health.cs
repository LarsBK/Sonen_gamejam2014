using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

		public float health = 1.0f;
		public bool isDead = false;
		public AudioClip[] hurtSounds;

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
				yield return new WaitForSeconds (5);
				Application.LoadLevel (Application.loadedLevel);
		}
	
		public void hurt (float dm)
		{
				health -= dm;
				


				if (health <= 0) {
						isDead = true;
						StartCoroutine (gameOver ());
				} else {
						if (hurtSounds.Length > 0) {
								int i = Random.Range (0, hurtSounds.Length);
								audio.PlayOneShot (hurtSounds [i]);
						}
				}
		}
}
