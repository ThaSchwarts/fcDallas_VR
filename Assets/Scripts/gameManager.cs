using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public Text scoreText;
    public int score;
    

	void Start ()
    {
        score = 0;
        
	}
	
	void Update ()
    {
        updateScore();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        updateScore();
    }

    public void SubtractScore(int newScore)
    {
        score -= newScore;
        updateScore();
    }

    public void updateScore()
    {
        scoreText.text = "Score = " + score; 
    }

    
}
