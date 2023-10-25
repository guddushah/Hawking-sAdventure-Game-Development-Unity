using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    // Use this for initialization
    public float score;
    public float highScore;
    public Text scoreText;
    public Text highscoreText;
    public float frames;
    public playercontrol target;
    public bool scoreIncrease;
	void Start () {
        scoreIncrease = true;
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
     
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        target = FindObjectOfType<playercontrol>();
        if(target.rb2d.velocity.x>0)
        {
            scoreIncrease = true;
            score += frames * Time.deltaTime;
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetFloat("HighScore", highScore);
            }
        }
        else
        {
            scoreIncrease = false;
        }
       
        scoreText.text = "Score:" + Mathf.Round(score) + " m";
        highscoreText.text = "HighScore:" + Mathf.Round(highScore) + " m";
		
	}
}
