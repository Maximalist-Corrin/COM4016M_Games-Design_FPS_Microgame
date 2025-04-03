using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Game/ScoreData")]
public class MLScoreData : ScriptableObject
{
    public MLScoreEntry[] recentScores = new MLScoreEntry[3];
    public MLScoreEntry highScore;

    private const string HighScoreKey = "HighScore";
    private const string RecentScoreKey = "RecentScore";

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

        SaveScores();
    }

    public void SaveScores()
    {
        // Saves High Score
        PlayerPrefs.SetInt(HighScoreKey + "_Kills", highScore.kills);
        PlayerPrefs.SetInt(HighScoreKey + "_Pickups", highScore.pickups);
        PlayerPrefs.SetFloat(HighScoreKey + "_TimeAlive", highScore.timeAlive);

        // Saves recent scores into PlayerPrefs
        for (int i = 0; i < recentScores.Length; i++)
        {
            PlayerPrefs.SetInt(RecentScoreKey + i + "_Kills", recentScores[i].kills);
            PlayerPrefs.SetInt(RecentScoreKey + i + "_Pickups", recentScores[i].pickups);
            PlayerPrefs.SetFloat(RecentScoreKey + i + "_TimeAlive", recentScores[i].timeAlive);
        }
        PlayerPrefs.Save();
    }

    public void LoadScores()
    {
        highScore.kills = PlayerPrefs.GetInt(HighScoreKey + "_Kills", 0);
        highScore.pickups = PlayerPrefs.GetInt(HighScoreKey + "_Pickups", 0);
        highScore.timeAlive = PlayerPrefs.GetFloat(HighScoreKey + "_TimeAlive", 0f);

        for (int i = 0;i < recentScores.Length; i++)
        {
            int kills = PlayerPrefs.GetInt(RecentScoreKey + i + "_Kills", 0);
            int pickups = PlayerPrefs.GetInt(RecentScoreKey + i + "_Pickups", 0);
            float timeAlive = PlayerPrefs.GetFloat(RecentScoreKey + i + "_TimeAlive", 0f);

            recentScores[i] = new MLScoreEntry(kills, pickups, timeAlive);
        }

    }
}
