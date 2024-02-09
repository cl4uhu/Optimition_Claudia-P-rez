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
            //Solución error al tamaño del pool demasiado pequeño. 
            if (bullet != null)
            {
                //Activamos la esfera.
                bullet.SetActive(true); 
            }
            else
            {
                Debug.LogError("Pool demasidado pequeño");
            }
        }
    }
}
