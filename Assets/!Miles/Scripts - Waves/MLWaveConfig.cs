using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaveConfig", menuName = "Wave")]
public class MLWaveConfig : ScriptableObject
{
    public List<GameObject> enemies; // List of enemies spawning in the wave
    public int enemyCount = 10; // Base number of enemies to be modified by difficulty
}
   