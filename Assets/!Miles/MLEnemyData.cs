using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/EnemyData")]
public class MLEnemyData : ScriptableObject
{
    // Stores base data for different enemy types that can be called when spawning waves
   
    public int Health;
    public int Damage;
    public List<Transform> Spawnpoints;
}
