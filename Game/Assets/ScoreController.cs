using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{

		public int winScore = 10;
		public int startScore = 0;
		public int score = 0;
		public string text = "Score: ";

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (score >= winScore) {
						guiText.text = "You win!";
				} else {
						guiText.text = text + score;
				}
		}

		public void addPoint ()
		{
				score++;
		}
}
