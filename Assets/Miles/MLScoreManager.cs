using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLScoreManager : MonoBehaviour
{
    public MLScoreData scoreData;
    private MLScoreEntry currentScore;

    private void Start()
    {
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
        MLScoreEntry newScore = new MLScoreEntry(kills, pickups, timeAlive);
        scoreData.AddScore(newScore);
    }

    public void ResetScore()
    {
        currentScore = new MLScoreEntry(0, 0, 0f); // resets game starts at game start
    }
}



// When player character dies, the following needs to be called:
//FindObjectOfType<MLScoreManager>().SubmitScore(kills, pickups, timeAlive);
//.ResetScore will need to be run at the start of every game also, and AddKill and AddPickup respectively.
