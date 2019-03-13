using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float score = 0.0f;
    private int difficultyLevel = 1;
    public Text scoreText;
    private int MaxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    private bool isDead = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(isDead)
        {
            return;
        }
        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
	}

    void LevelUp()
    {
        if ( difficultyLevel  == MaxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed (difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
    }
}
