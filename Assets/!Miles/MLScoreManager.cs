using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLScoreManager : MonoBehaviour
{
    public MLScoreData scoreData;
    private MLScoreEntry currentScore;

   void Start()
    {
        scoreData.LoadScores();
        ResetScore();
    }

    public void AddKill()
    {
        currentScore.kills++;
    }
    public void AddPickup()
    {
        currentScore.pickups++;
    }

    public void SubmitScore(int kills, int pickups, float timeAlive)
    {
        scoreData.AddScore(currentScore);
        scoreData.SaveScores();
        FindObjectOfType<MLScoreDisplay>().DisplayScores(); //updates UI with new scores
    }

    public void ResetScore()
    {
        currentScore = new MLScoreEntry(0, 0, 0f); // resets game starts at game start
    }
    public void DebugAddTestScores()
    {
        scoreData.AddScore(new MLScoreEntry(Random.Range(1, 10), Random.Range(1, 5), Random.Range(5f, 120f)));
        FindObjectOfType<MLScoreDisplay>().DisplayScores(); // Update UI
    }
}



// When player character dies, the following needs to be called:
//FindObjectOfType<MLScoreManager>().SubmitScore(kills, pickups, timeAlive);
//.ResetScore will need to be run at the start of every game also, and AddKill and AddPickup respectively.
