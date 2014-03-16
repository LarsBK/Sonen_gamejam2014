using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{

		public int winScore = 10;
		public int startScore = 0;
		public int score = 0;
		public string text = "Stars left: ";
	public AudioClip sound = null;
	private float winTime = 0;
	
		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (score >= winScore) {
			if (winTime == 0) winTime = Time.timeSinceLevelLoad;
			guiText.color = Color.green;
						guiText.text = "You win! Time: " + winTime;
				} else {
			guiText.text = text + (winScore - score) + " Time: " + string.Format("{0:0.00}",Time.timeSinceLevelLoad);
				}
		}

		public void addPoint ()
		{
			audio.PlayOneShot(sound);
			score++;
		}
}
