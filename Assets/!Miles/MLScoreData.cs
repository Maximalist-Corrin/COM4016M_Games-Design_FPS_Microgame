using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Game/ScoreData")]
public class MLScoreData : ScriptableObject
{
    public MLScoreEntry[] recentScores = new MLScoreEntry[3];
    public MLScoreEntry highScore;

    public void AddScore(MLScoreEntry newScore)
    {
        //Adds new score to recent scores and overwrites oldest
        recentScores[2] = recentScores[1];
        recentScores[1] = recentScores[0];
        recentScores[0] = newScore;


        //Updates high score
        if (newScore.GetTotalScore() > highScore.GetTotalScore())
        { 
            highScore = newScore;
        }
    }
}
