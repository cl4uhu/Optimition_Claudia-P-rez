using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform  gunPosition; 

    [SerializeField] GameObject bulletPrefab; 

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, gunPosition.position, gunPosition.rotation);
        }
    }
}
