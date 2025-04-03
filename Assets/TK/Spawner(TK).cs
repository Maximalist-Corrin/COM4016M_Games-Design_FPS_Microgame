using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnObjectPrafab;
    private GameObject SpawnObjectInstance;
    private bool isrespawn;
    // Start is called before the first frame update
    void Start()
    {
        isrespawn = false;
        SpawnObjectInstance = Instantiate(SpawnObjectPrafab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnObjectInstance == null && isrespawn == false)
        {
            StartCoroutine(RespawnTime()); 
        }
    }
    IEnumerator RespawnTime()
    {
        isrespawn = true;
        yield return new WaitForSeconds(5f);
        SpawnObjectInstance = Instantiate(SpawnObjectPrafab, transform.position, transform.rotation);
        isrespawn = false;
    }
}
