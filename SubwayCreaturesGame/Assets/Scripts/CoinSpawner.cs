using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    void Start()
    {
        GameObject coin = Instantiate(coinPrefab, new Vector3(13,0,0), transform.rotation);
        GameObject coin2 = Instantiate(coinPrefab, new Vector3(11,0,0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
