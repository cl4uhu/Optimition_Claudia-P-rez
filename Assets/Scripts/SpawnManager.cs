using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] int mineType = 1;
    GameObject currentAlien;
    
    void Start()
    {
        SpawnAlien();
    }

    void Update()
    {
        if (currentAlien == null || !currentAlien.activeSelf)
        {
            SpawnAlien();
        }
    }

    void SpawnAlien()
    {
        currentAlien = PoolManagerNave.Instance.GetPooledObjects(mineType, spawnPosition.position, spawnPosition.rotation);
        {
        if(currentAlien != null)
            {
                currentAlien.SetActive(true);
            }
        else
            {
                Debug.LogError("Pool es demasiado pequeño");
            }
        }
    }
}
