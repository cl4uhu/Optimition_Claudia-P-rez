using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5; 

    void Start()
    {
        
    }

    void Update()
    {
        //Movimiento hacia adelante.
        transform.position += transform.forward * bulletSpeed * Time.deltaTime; 
    }

    void OnCollisionEnter(Collision collision)
    {
        //Si se choca con algo debe destruirse. 
        Destroy(this.gameObject);
    }
}
