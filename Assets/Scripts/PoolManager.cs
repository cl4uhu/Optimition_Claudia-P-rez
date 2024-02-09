using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; 

    //Para acceder facilmente a la variable. 
    //Para nombrar el empty donde se guardaran nuestros prefabs.
    [SerializeField] string parentName;
    //Colocar el prefab.
    [SerializeField] GameObject prefab; 
    //Tamaño pool.
    [SerializeField] int poolSize; 
    //Instanciar todos los objetos que tengamos.
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
        
        //Se repite el número de veces del tamaño de nuestro pool. 
        for (int i = 0; i < poolSize; i ++)
        {
            //Instanciamos el objeto.
            obj = Instantiate(prefab);
            //Lo metemos dentro del empty.
            obj.transform.SetParent(parent.transform); 
            //Lo desactivamos.
            obj.SetActive(false);
            //Lo metemos dentro de la lista.
            pooledObjects.Add(obj); 
        }
    }

    //Buscar en la lista de nuestro bool y ver si puedo utilizar ese objeto o no.
    public GameObject GetPooledObjects(Vector3 position, Quaternion rotation)
    {
        //Revisa la lista.
        for (int i = 0; i < poolSize; i++)
        {
            //Detectar objeto desactivado de la lista.
            if(!pooledObjects[i].activeInHierarchy)
            {
                //Asignar el objeto desactivado a la variable.
                GameObject objectToSpawn;
                //Asignar el objeto.
                objectToSpawn = pooledObjects[i]; 
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
