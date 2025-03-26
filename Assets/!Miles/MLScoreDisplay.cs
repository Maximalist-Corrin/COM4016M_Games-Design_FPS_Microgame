using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MLScoreDisplay : MonoBehaviour
{
    public MLScoreData scoreData;
    public TMP_Text recentScoresTotalText;
    public TMP_Text recentScoresDataText;
    public TMP_Text highScoreTotalText;
    public TMP_Text highScoreDataText;
    void Start()
    {
        DisplayScores();
    }

    public void DisplayScores()
    {

        // Displays Recent Scores
        for (int i = 0; i <scoreData.recentScores.Length; i++)
        {
            MLScoreEntry entry = scoreData.recentScores[i];
            int totalScore = entry.GetTotalScore();
            recentScoresDataText.text += $"#{i + 1}: Kills: {entry.kills} \nPickups: {entry.pickups} \nTime:{entry.timeAlive:F2}s ";
            recentScoresTotalText.text += totalScore;
        }

        // Displays High Score
        MLScoreEntry high = scoreData.highScore;
        int highTotalScore = high.GetTotalScore() ;
        highScoreDataText.text = $"Kills: {high.kills} \nPickups: {high.pickups} \nTime: {high.timeAlive:F2}s ";

    }
}
