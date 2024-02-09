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
            //Nos preparamos para utilizar un objeto rellenandola e informandole desde donde queremos que se dispare la esfera. 
            GameObject bullet = PoolManager.Instance.GetPooledObjects(gunPosition.position, gunPosition.rotation);
            //Activamos la esfera. 
            bullet.SetActive(true); 
        }
    }
}
