using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; 

    [SerializeField] string parentName; 
    [SerializeField] GameObject prefab; 
    [SerializeField] int poolSize; 
    [SerializeField] List<GameObject> pooledObjects; 

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this; 
        }
    }

    void Start()
    {
        //Creación de un Empty.
        GameObject parent = new GameObject(parentName);
        //Rellenar el Empty con todos los prefabs que queramos.
        GameObject obj; 
        
        for (int i = 0; i < poolSize; i ++)
        {
            obj = Instantiate(prefab);
            obj.transform.SetParent(parent.transform); 
            obj.SetActive(false);
            pooledObjects.Add(obj); 
        }
    }

    public GameObject GetPooledObjects(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < poolSize; i++)
        {
            //Detectar objeto desactivado de la lista.
            if(!pooledObjects[i].activeInHierarchy)
            {
                //Asignar el objeto desactivado a la variable.
                GameObject objectToSpawn;
                objectToSpawn = pooledObjects[i]; 
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                return objectToSpawn;
            }
        }
    //Avisar si no encuentra ningún objeto desactivado. 
    return null; 
    }
}
