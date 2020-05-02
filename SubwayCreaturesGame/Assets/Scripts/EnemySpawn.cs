using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnpoint;
    private int spawnOffset = 12;
    private Vector3 playerpos;
    private Vector3 spawnpos;

    private bool wasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        wasSpawned = false;
        spawnpos = spawnpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    //spawns enemy when its right outside the line of sight;
    void Spawn()
    {
        playerpos = player.transform.position;
        if (!wasSpawned)
        {
            if (playerpos.x > (spawnpos.x - spawnOffset))
            {
                Debug.Log(playerpos.x+"  "+spawnpos.x);
                Instantiate(enemyPrefab, spawnpos,spawnpoint.transform.rotation);
                wasSpawned = true;
                Destroy(spawnpoint);
            }
        }
        
    }
}
