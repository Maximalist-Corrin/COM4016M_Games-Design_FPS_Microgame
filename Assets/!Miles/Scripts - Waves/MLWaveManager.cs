using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MLWaveManager : MonoBehaviour
{
    public List<MLWaveConfig> waveConfigs;
    public GameObject bossEnemy;
    public Transform[] spawnPoints;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    private int currentWave = 0;
    private float difficultyMultiplier = 1.0f;
    private float timer = 0f;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool waveActive = false;

}
