using UnityEngine;
using System.Collections;
using System.IO;

public class ScoreController : MonoBehaviour
{

		public int winScore = 10;
		public int startScore = 0;
		public int score = 0;
		public string text = "Stars left: ";
	public AudioClip sound = null;
	private float winTime = 0;
	private bool isBest = false;
	
		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (score >= winScore) {
			string text = "You win! ";
			if (isBest) {
				text += "HIGHSCORE! ";
			}
			text += "Time: " + winTime;
			guiText.text = text;
				} else {
			guiText.text = text + (winScore - score) + " Time: " + string.Format("{0:0.00}",Time.timeSinceLevelLoad);
				}
		}

		public void addPoint ()
		{
			audio.PlayOneShot(sound);
			score++;
		if (score >= winScore) {
						winTime = Time.timeSinceLevelLoad;
						guiText.color = Color.green;
						string path = Application.loadedLevelName + "_HIGHSCORE.txt";
						float best = float.MaxValue;
						if (File.Exists (path)) {
								string high = File.ReadAllText (path);
								best = float.Parse (high);
						}

						if (winTime < best) {
								isBest = true;
								File.WriteAllText (path, "" + winTime);
			
						}
				}
		}
}
