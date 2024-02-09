using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform  gunPosition; 

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //Nos preparamos para utilizar un objeto.
            GameObject bullet = PoolManager.Instance.GetPooledObjects(gunPosition.position, gunPosition.rotation);
            //Activamos el objeto. 
            bullet.SetActive(true); 
        }
    }
}
