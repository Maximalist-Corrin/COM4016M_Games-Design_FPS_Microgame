using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MLScoreEntry
{
    public int kills;
    public int pickups;
    public float timeAlive;


    public MLScoreEntry(int kills, int pickups, float timeAlive)
    {
        this.kills = kills;
        this.pickups = pickups;
        this.timeAlive = timeAlive;
    }

    public int GetTotalScore()
    {
        return (kills * 100 + Mathf.FloorToInt(timeAlive * 100) / 10); //Algorithm for calculating total score
    }
}
