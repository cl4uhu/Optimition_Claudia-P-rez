using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; 

    [System.Serializable]
    public class Pool
    {
    //Para acceder facilmente a la variable. 
    //Para nombrar el empty donde se guardaran nuestros prefabs.
    public string parentName;
    //Colocar el prefab.
    public GameObject prefab; 
    //Tamaño pool.
    public int poolSize; 
    //Instanciar todos los objetos que tengamos.
    public List<GameObject> pooledObjects; 
    }

    //Nos permite tener la cantidad de pools que queramos.
    [SerializeField] List<Pool> pools; 

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
        //Rellenar el Empty con todos los prefabs que queramos.
        GameObject obj; 

        foreach (Pool pool in pools)
        {
            //Creación de un Empty.
            GameObject parent = new GameObject(pool.parentName);

            //Se repite el número de veces del tamaño de nuestro pool. 
            for (int i = 0; i < pool.poolSize; i ++)
            {
                //Instanciamos el objeto.
                obj = Instantiate(pool.prefab);
                //Lo metemos dentro del empty.
                obj.transform.SetParent(parent.transform); 
                //Lo desactivamos.
                obj.SetActive(false);
                //Lo metemos dentro de la lista.
                pool.pooledObjects.Add(obj); 
            }
        }
    }

    //Buscar en la lista de nuestro bool y ver si puedo utilizar ese objeto o no.
    public GameObject GetPooledObjects(int selectedPool, Vector3 position, Quaternion rotation)
    {
        //Revisa la lista.
        for (int i = 0; i < pools[selectedPool].poolSize; i++)
        {
            //Detectar objeto desactivado de la lista.
            if(!pools[selectedPool].pooledObjects[i].activeInHierarchy)
            {
                //Asignar el objeto desactivado a la variable.
                GameObject objectToSpawn;
                //Asignar el objeto.
                objectToSpawn = pools[selectedPool].pooledObjects[i]; 
                //Asignar posición.
                objectToSpawn.transform.position = position;
                //Asignar rotación. 
                objectToSpawn.transform.rotation = rotation;
                //Decolcer el objeto que ha encontrado que podemos utilizar. 
                return objectToSpawn;
            }
        }
    //Avisar si no encuentra ningún objeto desactivado. 
    return null; 
    }
}