using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [System.Serializable]
    public class numberAndEnemy
    {
        public string name;
        public float initWait;
        public int howManyToSpawn;
        public float secondsBetweenSpawn;
        public GameObject enemyToSpawn;
    }
    public List<numberAndEnemy> waves = new List<numberAndEnemy>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnStuff());
    }

    bool keepSpawning = true;
    float secondsBetweenSpawn;
    // Update is called once per frame
    IEnumerator spawnStuff()
    {
        for (int i = 0; i < 1; i++)
        {
            for(int v = 0; v < waves[i].howManyToSpawn; v++)
            {
                yield return new WaitForSeconds(waves[i].secondsBetweenSpawn);
                GameObject enemySpawned = Instantiate(waves[i].enemyToSpawn);
                enemySpawned.transform.position = transform.position;
            }
            
        }
        
    }
}
