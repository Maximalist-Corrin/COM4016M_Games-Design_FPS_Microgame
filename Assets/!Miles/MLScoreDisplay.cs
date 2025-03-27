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

        // Clears and Displays Recent Scores
        recentScoresDataText.text = "";
        recentScoresTotalText.text = "";
        for (int i = 0; i < scoreData.recentScores.Length; i++)
        {
            MLScoreEntry entry = scoreData.recentScores[i];
            int totalScore = entry.GetTotalScore();
            recentScoresDataText.text += $"Kills: {entry.kills} \nPickups: {entry.pickups} \nTime: {entry.timeAlive:F2}s \n\n\n";
            recentScoresTotalText.text += $"Score: \n{totalScore} \n\n\n\n";
        }

        // Displays High Score
        MLScoreEntry high = scoreData.highScore;
        int highTotalScore = high.GetTotalScore();
        highScoreDataText.text = $"Kills: {high.kills} \nPickups: {high.pickups} \nTime: {high.timeAlive:F2}s ";
        highScoreTotalText.text = $"{highTotalScore}";

    }
}
